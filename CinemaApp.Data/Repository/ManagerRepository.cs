namespace CinemaApp.Data.Repository
{
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ManagerRepository : BaseRepository, IManagerRepository
    {
        public ManagerRepository(CinemaAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Manager?> GetManagerByUserIdAsync(Guid userId)
        {
            Manager? manager = await this.DbContext
                .Managers
                .SingleOrDefaultAsync(m => m.UserId == userId);
            
            return manager;
        }
    }
}
