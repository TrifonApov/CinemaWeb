namespace CinemaApp.Data.Repository
{
    using CinemaApp.Data.Repository.Contracts;
    using System.Linq.Expressions;
    using CinemaApp.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CinemaRepository : BaseRepository, ICinemaRepository 
    {
        public CinemaRepository(CinemaAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Cinema>> GetAllCinemas(Expression<Func<Cinema, bool>>? filterQuery = null, 
            Expression<Func<Cinema, Cinema>>? projectionQuery = null,
            bool includeProjections = false)
        {
            IQueryable<Cinema> cinemasFetchQuery = this.DbContext
                .Cinemas
                .AsNoTracking();

            if (includeProjections)
            {
                cinemasFetchQuery = cinemasFetchQuery.Include(c => c.Projections);
            }

            if (filterQuery != null)
            {
                cinemasFetchQuery = cinemasFetchQuery.Where(filterQuery);
            }

            if (projectionQuery !=null)
            {
                cinemasFetchQuery = cinemasFetchQuery
                    .Select(projectionQuery);
            }

            IEnumerable<Cinema> cinemas = await cinemasFetchQuery.ToArrayAsync();

            return cinemas;
        }
    }
}
