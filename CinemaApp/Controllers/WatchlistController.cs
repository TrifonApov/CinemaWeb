using AutoMapper;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Models.Watchlist;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers
{
    public class WatchlistController : BaseController
    {
        private readonly IWatchlistService watchlistService;
        private readonly IMapper mapper;

        public WatchlistController(IWatchlistService watchlistService, IMapper mapper)
        {
            this.watchlistService = watchlistService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = GetUserId()!;

            IEnumerable<WatchlistMovieDto> watchlistDtos = await watchlistService
                .GetUserWatchlistByIdAsync(userId.ToString().ToLower());;

            IEnumerable<WatchlistViewModel> watchlistViewModels = mapper
                .Map<IEnumerable<WatchlistViewModel>>(watchlistDtos);

            return View(watchlistViewModels);
        }
    }
}
