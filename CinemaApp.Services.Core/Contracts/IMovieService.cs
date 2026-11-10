namespace CinemaApp.Services.Core.Contracts
{
    using CinemaApp.Web.ViewModels.Movie;
    using CinemaApp.Services.Models.Movie;
    using static GCommon.ApplicationConstants;

    public interface IMovieService
    {
        Task<IEnumerable<MovieAllDto>> GetAllMoviesOrderedByTitleAsync(
            string? userId = null,
            string? searchQuery = null,
            int pageNumber = 1,
            int moviesPerPage = DefaultEntitiesPerPage);

        Task<int> GetMoviesCountAsync(string? searchQuery = null);

        Task CreateMovieAsync(MovieDetailsDto movieFormViewModel);

        Task<MovieDetailsDto?> GetMovieDetailsByIdAsync(Guid id);

        Task<MovieDetailsDto?> GetMovieFormModelByIdAsync(Guid id);

        Task<bool> ExistsByIdAsync(Guid id);

        Task EditMovieAsync(Guid id, MovieDetailsDto movieDetailsDto);

        Task SoftDeleteMovieAsync(Guid id);

        Task HardDeleteMovieAsync(Guid id);
    }
}
