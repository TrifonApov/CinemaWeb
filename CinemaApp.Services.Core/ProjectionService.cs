namespace CinemaApp.Services.Core
{
    using Contracts;
    using Data.Models;
    using Data.Repository.Contracts;

    public class ProjectionService : IProjectionService
    {
        private readonly IProjectionRepository projectionRepository;

        public ProjectionService(IProjectionRepository projectionRepository)
        {
            this.projectionRepository = projectionRepository;
        }

        public async Task<IEnumerable<DateTime>> GetProjectionAvailableShowtimesAsync(Guid movieId, Guid cinemaId)
        {
            IEnumerable<Projection> projections = await projectionRepository
                .GetAllProjectionAsync(p => p.MovieId == movieId 
                                            && p.CinemaId == cinemaId
                                            && p.AvailableTickets > 0);

            IEnumerable<DateTime> projectionShowtimes = projections
                .Select(p => p.Showtime)
                .Distinct()
                .ToArray();

            return projectionShowtimes;
        }    
    }
}
