using AutoMapper;

namespace CinemaApp.Services.Core
{
    using System.Globalization;
    using CinemaApp.Data.Models;
    using CinemaApp.Data.Repository.Contracts;
    using CinemaApp.GCommon.Exceptions;
    using CinemaApp.Services.Core.Contracts;
    using CinemaApp.Services.Models.Movie;
    using CinemaApp.Web.ViewModels.Movie;
    using static CinemaApp.GCommon.ApplicationConstants;

    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        private readonly IMapper mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MovieAllDto>> GetAllMoviesOrderedByTitleAsync()
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
                    ImageUrl = m.ImageUrl ?? DefaultImageUrl
                });

            // Process Data
            IEnumerable<MovieAllDto> allMoviesViewModel = mapper
                .Map<IEnumerable<MovieAllDto>>(allMoviesDb)
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

        public async Task<MovieFormViewModel?> GetMovieFormModelByIdAsync(Guid id)
        {
            Movie? movieDb = await movieRepository
                .GetMovieByIdAsync(id);

            if (movieDb == null)
            {
                return null;
            }

            return new MovieFormViewModel()
            {
                Id = movieDb.Id,
                Title = movieDb.Title,
                Description = movieDb.Description,
                Director = movieDb.Director,
                Duration = movieDb.Duration,
                Genre = movieDb.Genre,
                ImageUrl = movieDb.ImageUrl,
                ReleaseDate = movieDb.ReleaseDate
            };
        }

        public async Task<bool> ExistsByIdAsync(Guid id)
        {
            return await movieRepository.ExistsByIdAsync(id);
        }

        public async Task EditMovieAsync(Guid id, MovieFormViewModel movieFormViewModel)
        {
            Movie? movieDb = await movieRepository
                .GetMovieByIdAsync(id);
            if (movieDb == null)
            {
                throw new EntityNotFoundException();
            }

            movieDb.Title = movieFormViewModel.Title;
            movieDb.Description = movieFormViewModel.Description;
            movieDb.Director = movieFormViewModel.Director;
            movieDb.Genre = movieFormViewModel.Genre;
            movieDb.ReleaseDate = movieFormViewModel.ReleaseDate;
            movieDb.ImageUrl = movieFormViewModel.ImageUrl;
            movieDb.Duration = movieFormViewModel.Duration;

            bool editSuccess = await movieRepository.EditMovieAsync(movieDb);

            if (!editSuccess)
            {
                throw new EntityPersistFailureException();
            }
        }

        public async Task SoftDeleteMovieAsync(Guid id)
        {
            Movie? movieDb = await movieRepository
                .GetMovieByIdAsync(id);
            if (movieDb == null)
            {
                throw new EntityNotFoundException();
            }

            bool deleteSuccess = await movieRepository.SoftDeleteMovieAsync(movieDb);

            if (!deleteSuccess)
            {
                throw new EntityPersistFailureException();
            }
        }

        public async Task HardDeleteMovieAsync(Guid id)
        {
            Movie? movieDb = await movieRepository
                .GetMovieByIdAsync(id);
            if (movieDb == null)
            {
                throw new EntityNotFoundException();
            }

            bool deleteSuccess = await movieRepository.HardDeleteMovieAsync(movieDb);

            if (!deleteSuccess)
            {
                throw new EntityPersistFailureException();
            }
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
                throw new EntityPersistFailureException();
            }
        }
    }
}
