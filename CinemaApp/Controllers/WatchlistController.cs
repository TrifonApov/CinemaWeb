namespace CinemaApp.Web.Controllers
{
    using CinemaApp.GCommon.Exceptions;
    using AutoMapper;
    using CinemaApp.Services.Core.Contracts;
    using CinemaApp.Services.Models.Watchlist;
    using CinemaApp.Web.ViewModels.Watchlist;
    using Microsoft.AspNetCore.Mvc;

    using static CinemaApp.GCommon.OutputMessages.Watchlist;

    public class WatchlistController : BaseController
    {
        private readonly IWatchlistService watchlistService;
        private readonly IMapper mapper;
        private readonly ILogger<WatchlistController> logger;

        public WatchlistController(IWatchlistService watchlistService, IMapper mapper, ILogger<WatchlistController> logger)
        {
            this.watchlistService = watchlistService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = GetUserId()!;

            IEnumerable<WatchlistMovieDto> watchlistDtos = await watchlistService
                .GetUserWatchlistByIdAsync(userId.ToString().ToLower()); ;

            IEnumerable<WatchlistViewModel> watchlistViewModels = mapper
                .Map<IEnumerable<WatchlistViewModel>>(watchlistDtos);

            return View(watchlistViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> AddToWatchlist([FromRoute(Name = "id")]Guid movieId)
        {
            string userId = GetUserId()!;

            try
            {
                await watchlistService.AddMovieToUserWatchlistAsync(userId, movieId);
            }
            catch (EntityAlreadyExistsException eaee)
            {
                logger.LogError(eaee, string.Format(MovieAlreadyInWatchlistMessage, movieId, userId));
                return BadRequest(string.Format(MovieAlreadyInWatchlistMessage, movieId, userId));
            }
            catch (EntityNotFoundException enfe)
            {
                return NotFound();
            }
            catch (EntityPersistFailureException epfe)
            {
                logger.LogError(epfe, string.Format(AddToWatchlistErrorMessage));

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid movieId)
        {
            string userId = GetUserId()!;

            try
            {
                await watchlistService.RemoveFromUserWatchlist(userId, movieId);
            }
            catch (EntityNotFoundException enfe)
            {
                return BadRequest();
            }
            catch (EntityPersistFailureException epfe)
            {
                logger.LogError(epfe, string.Format(RemoveFromWatchlistErrorMessage));

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
