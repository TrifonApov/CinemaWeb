using System.Globalization;
using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Contracts;
using CinemaApp.GCommon.Exceptions;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Web.ViewModels.Movie;
using static CinemaApp.GCommon.ApplicationConstants;

namespace CinemaApp.Services.Core
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesOrderedByTitleAsync()
        {
            // Fetch Data
            IEnumerable<Movie> allMoviesDb = await movieRepository
                .GelAllMoviesNoTrackingWithProjectionAsync(m => new Movie()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Genre = m.Genre,
                    ReleaseDate = m.ReleaseDate,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl
                });

            // Process Data
            IEnumerable<AllMoviesIndexViewModel> allMoviesViewModel = allMoviesDb
                .Select(m => new AllMoviesIndexViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Genre = m.Genre,
                    ReleaseDate = m.ReleaseDate.ToString(DefaultDateFormat, CultureInfo.InvariantCulture),
                    Director = m.Director,
                    ImageUrl = m.ImageUrl ?? DefaultImageUrl
                })
                .OrderBy(m => m.Title)
                .ThenBy(m => m.Genre)
                .ThenBy(m => m.Director)
                .ToArray();

            // Return Processed Data
            return allMoviesViewModel;

        }

        public async Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(Guid id)
        {
            Movie? movieDb = await movieRepository
                .GetMovieByIdAsync(id);

            if (movieDb == null)
            {
                return null;
            }

            return new MovieDetailsViewModel()
            {
                Id = movieDb.Id,
                Title = movieDb.Title,
                Description = movieDb.Description,
                Director = movieDb.Director,
                Duration = movieDb.Duration,
                Genre = movieDb.Genre,
                ImageUrl = movieDb.ImageUrl ?? DefaultImageUrl,
                ReleaseDate = movieDb.ReleaseDate.ToString(DefaultDateFormat, CultureInfo.InvariantCulture)
            };
        }

        public async Task CreateMovieAsync(MovieFormViewModel movieModel)
        {
            Movie movie = new Movie()
            {
                Title = movieModel.Title,
                Description = movieModel.Description,
                Director = movieModel.Director,
                Duration = movieModel.Duration,
                Genre = movieModel.Genre,
                ReleaseDate = movieModel.ReleaseDate,
                ImageUrl = movieModel.ImageUrl
            };

            bool successAdd = await movieRepository.AddMovieAsync(movie);
            if (!successAdd)
            {
                throw new DbEntityCreatePersistFailureException();
            }
        }
    }
}
