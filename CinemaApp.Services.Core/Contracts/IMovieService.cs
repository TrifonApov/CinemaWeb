namespace CinemaApp.Services.Core.Contracts
{
    using CinemaApp.Web.ViewModels.Movie;
    using CinemaApp.Services.Models.Movie;

    public interface IMovieService
    {
        Task<IEnumerable<MovieAllDto>> GetAllMoviesOrderedByTitleAsync();
        
        Task CreateMovieAsync(MovieFormViewModel movieFormViewModel);

        Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(Guid id);

        Task<MovieFormViewModel?> GetMovieFormModelByIdAsync(Guid id);

        Task<bool> ExistsByIdAsync(Guid id);

        Task EditMovieAsync(Guid id, MovieFormViewModel movieFormViewModel);

        Task SoftDeleteMovieAsync(Guid id);

        Task HardDeleteMovieAsync(Guid id);
    }
}
