using AutoMapper;
using CinemaApp.GCommon.Exceptions;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Models.Movie;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CinemaApp.GCommon.OutputMessages.Movie;
using static CinemaApp.GCommon.ApplicationConstants;
namespace CinemaApp.Web.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IMovieService movieService;
        private readonly ILogger<MovieController> logger;
        private readonly IMapper mapper;

        public MovieController(IMovieService movieService, ILogger<MovieController> logger, IMapper mapper)
        {
            this.movieService = movieService;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<MovieAllDto> movieAllDtos = await movieService
                .GetAllMoviesOrderedByTitleAsync();

            IEnumerable<AllMoviesIndexViewModel> allMovies = mapper
                .Map<IEnumerable<AllMoviesIndexViewModel>>(movieAllDtos);

            return View(allMovies);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            MovieDetailsViewModel? movie = await movieService.GetMovieDetailsByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieFormViewModel movieModel)
        {
            if (!ModelState.IsValid)
            {
                return View(movieModel);
            }

            try
            {
                await movieService.CreateMovieAsync(movieModel);
            }
            catch (EntityPersistFailureException exception)
            {
                logger.LogError(exception, CreateMovieFailureMessage);

                ModelState.AddModelError(string.Empty, CreateMovieFailureMessage);
                return View(movieModel);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, UnexpectedErrorMessage);

                ModelState.AddModelError(string.Empty, UnexpectedErrorMessage);
                return View(movieModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            MovieFormViewModel? movie = await movieService
                .GetMovieFormModelByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync([FromRoute] Guid id, MovieFormViewModel movieModel)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            if (!await movieService.ExistsByIdAsync(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return ViewBag(movieModel);
            }

            try
            {
                await movieService.EditMovieAsync(id, movieModel);
            }
            catch (EntityNotFoundException exception)
            {
                return NotFound();
            }
            catch (EntityPersistFailureException exception)
            {
                logger.LogInformation(exception, EditMovieFailureMessage);
                Console.WriteLine(exception);

                return View(movieModel);
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            MovieDetailsViewModel? movieToDelete = await movieService.GetMovieDetailsByIdAsync(id);
            if (movieToDelete == null)
            {
                return NotFound();
            }

            return View(movieToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, MovieDetailsViewModel? movieDetailsViewModel)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                await movieService.SoftDeleteMovieAsync(id);
            }
            catch (EntityNotFoundException exception)
            {
                return NotFound();
            }
            catch (EntityPersistFailureException exception)
            {
                logger.LogInformation(exception, EditMovieFailureMessage);
                Console.WriteLine(exception);

                return View(movieDetailsViewModel);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
