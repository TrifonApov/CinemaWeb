using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaAppDbContext dbContext;
        
        public MovieRepository(CinemaAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Movie> GelAllMoviesNoTracking()
        {
            IQueryable<Movie> allMovies = this.dbContext
                .Movies
                .AsNoTracking();

            return allMovies;
        }

        public async Task<IEnumerable<Movie>> GelAllMoviesAsync()
        {
            return await this.dbContext
                .Movies
                .AsNoTracking()
                .OrderBy(m => m.Title)
                .ToArrayAsync();
        }
    }
}
