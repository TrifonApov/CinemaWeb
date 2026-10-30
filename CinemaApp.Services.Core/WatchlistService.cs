namespace CinemaApp.Services.Core
{
    using AutoMapper;
    using CinemaApp.Services.Core.Contracts;
    using CinemaApp.Services.Models.Watchlist;
    using CinemaApp.Data.Models;
    using CinemaApp.Data.Repository.Contracts;
    using CinemaApp.GCommon.Exceptions;

    public class WatchlistService : IWatchlistService
    {
        private readonly IWatchlistRepository watchlistRepository;
        private readonly IMovieRepository movieRepository;
        private readonly IMapper mapper;

        public WatchlistService(IWatchlistRepository watchlistRepository, IMovieRepository movieRepository, IMapper mapper)
        {
            this.watchlistRepository = watchlistRepository;
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }

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

        public async Task<bool> MovieIsInUserWatchlistAsync(string userId, Guid movieId)
        {
            try
            {
                bool userWatchlistEntryExists = await watchlistRepository
                    .ExistAsync(userId, movieId);

                return userWatchlistEntryExists;
            }
            catch (NullReferenceException nullReferenceException)
            {
                throw new EntityKeyNullOrEmpty(nullReferenceException.Message);
            }
        }

        public async Task AddMovieToUserWatchlistAsync(string userId, Guid movieId)
        {
            UserMovie? userMovie = await watchlistRepository
                .GetUserMovieIncludeDeletedAsync(userId, movieId);

            if (userMovie != null && !userMovie.IsDeleted)
            {
                throw new EntityAlreadyExistsException();
            }

            bool movieExists = await movieRepository
                .ExistsByIdAsync(movieId);

            if (!movieExists)
            {
                throw new EntityNotFoundException();
            }

            bool successPersist;

            if (userMovie == null)
            {
                UserMovie newUserMovie = new UserMovie()
                {
                    MovieId = movieId,
                    UserId = userId
                };

                successPersist = await watchlistRepository.AddUserMovieAsync(newUserMovie);
            }
            else
            {
                userMovie.IsDeleted = false;
                successPersist = await watchlistRepository.UpdateUserMovieAsync(userMovie);
            }

            if (!successPersist)
            {
                throw new EntityPersistFailureException();
            }
        }

        public async Task RemoveFromUserWatchlist(string userId, Guid movieId)
        {
            UserMovie? userMovie = await watchlistRepository
                .GetUserMovieAsync(userId, movieId);

            if (userMovie == null)
            {
                throw new EntityNotFoundException();
            }

            bool successRemove = await watchlistRepository.SoftDeleteUserMovieAsync(userMovie);

            if (!successRemove)
            {
                throw new EntityPersistFailureException();
            }
        }
    }
}
