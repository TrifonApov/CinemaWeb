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
        private readonly IWatchlistRepository watchlistRepository;
        private readonly IMapper mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper, IWatchlistRepository watchlistRepository)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
            this.watchlistRepository = watchlistRepository;
        }

        public async Task<IEnumerable<MovieAllDto>> GetAllMoviesOrderedByTitleAsync(string? userId = null)
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
            IEnumerable<MovieAllDto> allMoviesDto = mapper
                .Map<IEnumerable<MovieAllDto>>(allMoviesDb)
                .OrderBy(m => m.Title)
                .ThenBy(m => m.Genre)
                .ThenBy(m => m.Director)
                .ToArray();

            if (!string.IsNullOrWhiteSpace(userId))
            {
                foreach (MovieAllDto movieAllDto in allMoviesDto)
                {
                    movieAllDto.IsInUserWatchlist = await watchlistRepository
                        .ExistAsync(userId, movieAllDto.Id);
                }
            }
            // Return Processed Data
            return allMoviesDto;

        }

        public async Task<MovieDetailsDto?> GetMovieDetailsByIdAsync(Guid id)
        {
            Movie? movieDb = await movieRepository
                .GetMovieByIdAsync(id);

            if (movieDb == null)
            {
                return null;
            }

            return mapper.Map<MovieDetailsDto>(movieDb);
        }

        public async Task<MovieDetailsDto?> GetMovieFormModelByIdAsync(Guid id)
        {
            Movie? movieDb = await movieRepository
                .GetMovieByIdAsync(id);

            if (movieDb == null)
            {
                return null;
            }

            return mapper.Map<MovieDetailsDto>(movieDb);
        }

        public async Task<bool> ExistsByIdAsync(Guid id)
        {
            return await movieRepository.ExistsByIdAsync(id);
        }

        public async Task EditMovieAsync(Guid id, MovieDetailsDto movieDetailsDto)
        {
            Movie? movieDb = await movieRepository
                .GetMovieByIdAsync(id);
            if (movieDb == null)
            {
                throw new EntityNotFoundException();
            }

            movieDb.Title = movieDetailsDto.Title;
            movieDb.Description = movieDetailsDto.Description;
            movieDb.Director = movieDetailsDto.Director;
            movieDb.Genre = movieDetailsDto.Genre;
            movieDb.ReleaseDate = movieDetailsDto.ReleaseDate;
            movieDb.ImageUrl = movieDetailsDto.ImageUrl ?? DefaultImageUrl;
            movieDb.Duration = movieDetailsDto.Duration;

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

        public async Task CreateMovieAsync(MovieDetailsDto movieDetailsDto)
        {
            Movie movie = mapper
                .Map<Movie>(movieDetailsDto);

            bool successAdd = await movieRepository.AddMovieAsync(movie);
            
            if (!successAdd)
            {
                throw new EntityPersistFailureException();
            }
        }
    }
}
