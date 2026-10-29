namespace CinemaApp.Services.Core.Contracts
{
    using CinemaApp.Services.Models.Watchlist;
    public interface IWatchlistService
    {
        Task<IEnumerable<WatchlistMovieDto>> GetUserWatchlistByIdAsync(string userId);

        Task<bool> MovieIsInUserWatchlistAsync(string userId, Guid movieId);

        Task AddMovieToUserWatchlistAsync(string userId, Guid movieId);
    }
}
