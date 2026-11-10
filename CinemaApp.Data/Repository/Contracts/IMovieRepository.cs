namespace CinemaApp.Data.Repository.Contracts
{
    using System.Linq.Expressions;
    using CinemaApp.Data.Models;

    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GelAllMoviesNoTrackingWithProjectionAsync(
            Expression<Func<Movie, Movie>>? projectFunc = null,
            Expression<Func<Movie, bool>>? filterQuery = null,
            int? skipCount = null,
            int? takeCount = null);
        Task<IEnumerable<Movie>> GelAllMoviesAsync();
        Task<bool> AddMovieAsync(Movie movie);
        Task<Movie?> GetMovieByIdAsync(Guid id);
        Task<bool> ExistsByIdAsync(Guid id);
        Task<bool> EditMovieAsync(Movie movie);
        Task<bool> SoftDeleteMovieAsync(Movie movie);
        Task<bool> HardDeleteMovieAsync(Movie movie);
        Task<int> CountAsync(Expression<Func<Movie, bool>>? filterQuery = null);
    }
}
