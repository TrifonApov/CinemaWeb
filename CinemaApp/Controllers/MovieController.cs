namespace CinemaApp.Web.Controllers
{
    using AutoMapper;
    using CinemaApp.GCommon.Exceptions;
    using CinemaApp.Services.Core.Contracts;
    using CinemaApp.Services.Models.Movie;
    using CinemaApp.Web.ViewModels.Movie;
    using GCommon;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static CinemaApp.GCommon.OutputMessages.Movie;
    using static CinemaApp.GCommon.ApplicationConstants;
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
        public async Task<IActionResult> Index(MoviesAllIndexViewModel moviesAllIndexInput)
        {
            string? userId = GetUserId();

            IEnumerable<MovieAllDto> movieAllDtos = await movieService
                .GetAllMoviesOrderedByTitleAsync(userId, moviesAllIndexInput.SearchQuery, moviesAllIndexInput.PageNumber);

            int moviesCount = await movieService.GetMoviesCountAsync(moviesAllIndexInput.SearchQuery);
            
            IEnumerable<MoviesIndexViewModel> allMovies = mapper
                .Map<IEnumerable<MoviesIndexViewModel>>(movieAllDtos);

            MoviesAllIndexViewModel allMoviesViewModel = new MoviesAllIndexViewModel
            {
                SearchQuery = moviesAllIndexInput.SearchQuery,
                PageNumber = moviesAllIndexInput.PageNumber,
                TotalPages = (int)Math.Ceiling(moviesCount / (double)DefaultEntitiesPerPage),
                ShowingPages = moviesAllIndexInput.ShowingPages,
                StartPageIndex = (moviesAllIndexInput.PageNumber/10) * 10,
                Movies = allMovies.ToArray()
            };

           
            return View(allMoviesViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            MovieDetailsDto? movieDetailsDto = await movieService
                .GetMovieDetailsByIdAsync(id);

            if (movieDetailsDto == null)
            {
                return NotFound();
            }

            MovieDetailsViewModel movieDetailsVm = mapper
                .Map<MovieDetailsViewModel>(movieDetailsDto);

            return View(movieDetailsVm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieFormViewModel movieFormVm)
        {
            if (!ModelState.IsValid)
            {
                return View(movieFormVm);
            }

            try
            {
                MovieDetailsDto movieDetailsDto = mapper.Map<MovieDetailsDto>(movieFormVm);

                await movieService.CreateMovieAsync(movieDetailsDto);
            }
            catch (EntityPersistFailureException exception)
            {
                logger.LogError(exception, CreateMovieFailureMessage);

                ModelState.AddModelError(string.Empty, CreateMovieFailureMessage);
                return View(movieFormVm);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, UnexpectedErrorMessage);
                TempData[ErrorTempDataKey] = UnexpectedErrorMessage;

                ModelState.AddModelError(string.Empty, UnexpectedErrorMessage);
                return View(movieFormVm);
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

            MovieDetailsDto? movieDetailsDto = await movieService
                .GetMovieFormModelByIdAsync(id);

            if (movieDetailsDto == null)
            {
                return NotFound();
            }

            MovieFormViewModel movieFormVm = mapper
                .Map<MovieFormViewModel>(movieDetailsDto);

            return View(movieFormVm);
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
                MovieDetailsDto movieDetailsDto = mapper
                    .Map<MovieDetailsDto>(movieModel);

                await movieService.EditMovieAsync(id, movieDetailsDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (EntityPersistFailureException exception)
            {
                logger.LogInformation(exception, EditMovieFailureMessage);
                Console.WriteLine(exception);

                return View(movieModel);
            }

            TempData[SuccessTempDataKey] = "Edited successfully";
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            MovieDetailsDto? movieDetailsDto = await movieService
                .GetMovieDetailsByIdAsync(id);

            if (movieDetailsDto == null)
            {
                return NotFound();
            }

            MovieDeleteViewModel movieDeleteVm = mapper
                .Map<MovieDeleteViewModel>(movieDetailsDto);

            return View(movieDeleteVm);
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
            catch (EntityNotFoundException)
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
