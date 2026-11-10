namespace CinemaApp.Data.Repository.Contracts
{
    using System.Linq.Expressions;
    using Models;

    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUserAsync(Expression<Func<ApplicationUser, bool>>? filterQuery = null,
            Expression<Func<ApplicationUser,ApplicationUser>>? projectionQuery = null);

        Task<IEnumerable<string>> GetUserRolesAsync(ApplicationUser user);
    }
}
