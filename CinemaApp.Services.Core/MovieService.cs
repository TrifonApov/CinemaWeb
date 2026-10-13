using CinemaApp.Data;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static CinemaApp.GCommon.ApplicationConstants;

namespace CinemaApp.Services.Core
{
    public class MovieService : IMovieService
    {
        private readonly CinemaAppDbContext cinemaAppDbContext;
        public MovieService(CinemaAppDbContext cinemaAppDbContext)
        {
            this.cinemaAppDbContext = cinemaAppDbContext;
        }

        public async Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesOrderedByTitleAsync()
        {
            IEnumerable<AllMoviesIndexViewModel> allMovies = await cinemaAppDbContext
                .Movies
                .AsNoTracking()
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
