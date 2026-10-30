namespace CinemaApp.Data.Repository.Contracts
{
    using CinemaApp.Data.Models;

    public interface IWatchlistRepository
    {
        Task<IEnumerable<UserMovie>> GetAllUserMoviesAsync();

        Task<UserMovie?> GetUserMovieAsync(string userId, Guid movieId);

        Task<UserMovie?> GetUserMovieIncludeDeletedAsync(string userId, Guid movieId);

        Task<bool> ExistAsync(string userId, Guid movieId);

        Task<bool> AddUserMovieAsync(UserMovie userMovie);

        Task<bool> SoftDeleteUserMovieAsync(UserMovie userMovie);

        Task<bool> UpdateUserMovieAsync(UserMovie userMovie);
    }
}
