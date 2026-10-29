using CinemaApp.Data.Models;

namespace CinemaApp.Data.Repository.Contracts
{
    public interface IWatchlistRepository
    {
        Task<IEnumerable<UserMovie>> GetAllUserMoviesAsync();

        Task<bool> ExistAsync(string userId, Guid movieId);

        Task<bool> AddUserMovieAsync(UserMovie userMovie);
    }
}
