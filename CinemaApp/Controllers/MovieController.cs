using CinemaApp.GCommon.Exceptions;
using CinemaApp.Services.Core.Contracts;
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

        public MovieController(IMovieService movieService, ILogger<MovieController> logger)
        {
            this.movieService = movieService;
            this.logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllMoviesIndexViewModel> allMovies = await movieService
                .GetAllMoviesOrderedByTitleAsync();

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
            catch (DbEntityPersistFailureException exception)
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
            catch (DbEntityPersistFailureException exception)
            {
                logger.LogInformation(exception, EditMovieFailureMessage);
                Console.WriteLine(exception);

                return View(movieModel);
            }

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
