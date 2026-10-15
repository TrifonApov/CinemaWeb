using CinemaApp.Data.Models;

namespace CinemaApp.Data.Repository.Contracts
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GelAllMoviesNoTrackingWithProjectionAsync(Func<Movie,Movie>? projectFunc = null);
        
        Task<IEnumerable<Movie>> GelAllMoviesAsync();

        Task<bool> AddMovieAsync(Movie movie);

        Task<Movie?> GetMovieByIdAsync(Guid id);

        Task<bool> ExistsByIdAsync(Guid id);

        Task<bool> EditMovieAsync(Movie movie);

        Task<bool> SoftDeleteMovieAsync(Movie movie);
        Task<bool> HardDeleteMovieAsync(Movie movie);
    }
}
