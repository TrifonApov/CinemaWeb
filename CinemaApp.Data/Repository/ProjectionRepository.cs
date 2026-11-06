namespace CinemaApp.Data.Repository
{
    using System.Linq.Expressions;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ProjectionRepository : BaseRepository, IProjectionRepository
    {
        public ProjectionRepository(CinemaAppDbContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<IEnumerable<Projection>> GetAllProjectionAsync(Expression<Func<Projection, bool>>? filterQuery = null)
        {
            IQueryable<Projection> projectionFetchQuery = DbContext
                .Projections
                .AsNoTracking();

            if (filterQuery != null)
            {
                projectionFetchQuery = projectionFetchQuery.Where(filterQuery);
            }

            IEnumerable<Projection> projections = await projectionFetchQuery
                .ToArrayAsync();

            return projections;
        }

        public async Task<Projection?> GetByIdAsync(Guid id)
        {
            return await DbContext
                .Projections
                .FindAsync(id);
        }

        public async Task<bool> UpdateProjectionAsync(Projection projection)
        {
            DbContext.Projections.Update(projection);
            int resultCount = await DbContext.SaveChangesAsync();

            return resultCount == 1;
        }
    }
}