namespace CinemaApp.Services.Core.Contracts
{
    using CinemaApp.Services.Models.Watchlist;
    public interface IWatchlistService
    {
        Task<IEnumerable<WatchlistMovieDto>> GetUserWatchlistByIdAsync(string userId);


    }
}
