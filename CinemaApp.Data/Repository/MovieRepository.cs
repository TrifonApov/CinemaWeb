namespace CinemaApp.Data.Repository
{
    using System.Linq.Expressions;
    using CinemaApp.Data.Models;
    using CinemaApp.Data.Repository.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class MovieRepository : BaseRepository, IMovieRepository
    {
        public MovieRepository(CinemaAppDbContext dbContext) :base(dbContext) { }

        public async Task<IEnumerable<Movie>> GelAllMoviesNoTrackingWithProjectionAsync(
            Expression<Func<Movie, Movie>>? projectFunc = null,
            Expression<Func<Movie, bool>>? filterQuery = null,
            int? skipCount = null,
            int? takeCount = null)
        {
            IQueryable<Movie> moviesFetchQuery = DbContext
                .Movies
                .AsNoTracking()
                .OrderBy(m => m.Title)
                .ThenBy(m => m.Id);

            if (filterQuery != null)
            {
                moviesFetchQuery = moviesFetchQuery
                    .Where(filterQuery)
                    .AsQueryable();
            }

            if (projectFunc != null)
            {
                moviesFetchQuery = moviesFetchQuery
                    .Select(projectFunc)
                    .AsQueryable();
            }

            if (skipCount.HasValue && skipCount.Value > 0)
            {
                moviesFetchQuery = moviesFetchQuery
                    .Skip(skipCount.Value)
                    .AsQueryable();
            }

            if (takeCount.HasValue && takeCount.Value > 0)
            {
                moviesFetchQuery = moviesFetchQuery
                    .Take(takeCount.Value)
                    .AsQueryable();
            }

            return await moviesFetchQuery.ToArrayAsync();
        }

        public async Task<IEnumerable<Movie>> GelAllMoviesAsync()
        {
            return await DbContext
                .Movies
                .AsNoTracking()
                .OrderBy(m => m.Title)
                .ToArrayAsync();
        }

        public async Task<bool> AddMovieAsync(Movie movie)
        {
            await DbContext.Movies.AddAsync(movie);
            int resultSuccess = await SaveChangesAsync();

            return resultSuccess == 1;
        }

        public async Task<Movie?> GetMovieByIdAsync(Guid id)
        {
            return await DbContext
                .Movies
                .FindAsync(id);
        }

        public async Task<bool> ExistsByIdAsync(Guid id)
        {
            return await DbContext
                .Movies
                .AnyAsync(m => m.Id == id);
        }

        public async Task<bool> EditMovieAsync(Movie movie)
        {
            DbContext.Movies.Update(movie);
            int resultCount = await SaveChangesAsync();

            return resultCount == 1;
        }

        public async Task<bool> SoftDeleteMovieAsync(Movie movie)
        {
            movie.IsDeleted = true;
            DbContext.Movies.Update(movie);

            int resultCount = await SaveChangesAsync();

            return resultCount == 1;
        }

        public async Task<bool> HardDeleteMovieAsync(Movie movie)
        {
            DbContext.Movies.Remove(movie);
            int resultCount = await SaveChangesAsync();

            return resultCount == 1;
        }

        public async Task<int> CountAsync(Expression<Func<Movie, bool>>? filterQuery = null)
        {
            IQueryable<Movie> moviesFetchQuery = DbContext
                .Movies
                .AsNoTracking();

            if (filterQuery != null)
            {
                moviesFetchQuery = moviesFetchQuery
                    .Where(filterQuery);
            }

            int movieCount = await moviesFetchQuery.CountAsync();
            return movieCount;
        }
    }
}