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
            catch (DbEntityCreatePersistFailureException exception)
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
    }
}
