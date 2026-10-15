using CinemaApp.Data.Models;

namespace CinemaApp.Data.Repository.Contracts
{
    public interface IMovieRepository
    {
        IQueryable<Movie> GelAllMoviesNoTracking();
        Task<IEnumerable<Movie>> GelAllMoviesAsync();
    }
}
