namespace CinemaApp.Services.Core.Contracts
{
    public interface IProjectionService
    {
        Task<IEnumerable<DateTime>> GetProjectionAvailableShowtimesAsync(Guid movieId, Guid cinemaId);
    }
}
