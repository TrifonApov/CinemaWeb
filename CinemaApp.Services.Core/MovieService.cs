using CinemaApp.Data.Repository;
using CinemaApp.Data.Repository.Contracts;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;
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
            IEnumerable<AllMoviesIndexViewModel> allMovies = await movieRepository
                .GelAllMoviesNoTracking()
                .Select(m => new AllMoviesIndexViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    Genre = m.Genre,
                    ImageUrl = m.ImageUrl ?? DefaultImageUrl,
                    ReleaseDate = m.ReleaseDate.ToString(DefaultDateFormat)
                })
                .OrderBy(m => m.Title)
                .ThenBy(m => m.Genre)
                .ToListAsync();

            return allMovies;
        }
    }
}
