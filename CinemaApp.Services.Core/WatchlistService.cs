using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Contracts;

namespace CinemaApp.Services.Core
{
    using AutoMapper;
    using CinemaApp.Services.Core.Contracts;
    using CinemaApp.Services.Models.Watchlist;

    public class WatchlistService : IWatchlistService
    {
        private readonly IWatchlistRepository watchlistRepository;
        private readonly IMapper mapper;

        public WatchlistService(IWatchlistRepository watchlistRepository, IMapper mapper)
        {
            this.watchlistRepository = watchlistRepository;
            this.mapper = mapper;
        }

        //public async Task<IEnumerable<WatchlistMovieDto>> GetUserWatchlistByIdAsync(string userId)
        //{

        //}
        public async Task<IEnumerable<WatchlistMovieDto>> GetUserWatchlistByIdAsync(string userId)
        {
            IEnumerable<Movie> userWatchlistMovies = watchlistRepository
                .GetAllUserMoviesAsync()
                .GetAwaiter()
                .GetResult()
                .Where(um => um.UserId.ToLower() == userId.ToLower())
                .Select(um => um.Movie)
                .ToArray();

            IEnumerable<WatchlistMovieDto> watchlistMovieDtos = mapper
                .Map<IEnumerable<WatchlistMovieDto>>(userWatchlistMovies);

            return watchlistMovieDtos;
        }
    }
}
