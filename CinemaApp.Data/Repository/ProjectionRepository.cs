using CinemaApp.Data.Repository.Contracts;

namespace CinemaApp.Data.Repository
{
    public class ProjectionRepository : BaseRepository, IProjectionRepository
    {
        public ProjectionRepository(CinemaAppDbContext dbContext) 
            : base(dbContext)
        {
            
        }
    }
}
