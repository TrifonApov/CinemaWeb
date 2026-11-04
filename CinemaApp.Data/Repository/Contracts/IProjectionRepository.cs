namespace CinemaApp.Data.Repository.Contracts
{
    using System.Linq.Expressions;
    using Models;

    public interface IProjectionRepository
    {
        Task<IEnumerable<Projection>> GetAllProjectionAsync(Expression<Func<Projection, bool>>? filterQuery = null);
    }
}