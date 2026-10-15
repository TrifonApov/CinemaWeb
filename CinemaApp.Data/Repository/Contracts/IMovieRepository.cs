using CinemaApp.Data.Models;

namespace CinemaApp.Data.Repository.Contracts
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GelAllMoviesNoTrackingWithProjectionAsync(Func<Movie,Movie>? projectFunc = null);
        
        Task<IEnumerable<Movie>> GelAllMoviesAsync();

        Task<bool> AddMovieAsync(Movie movie);
    }
}
