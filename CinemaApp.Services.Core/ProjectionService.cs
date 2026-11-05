namespace CinemaApp.Services.Core
{
    using System.Globalization;
    using Contracts;
    using Data.Models;
    using Data.Repository.Contracts;
    using GCommon.Exceptions;

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

        public async Task<Guid?> GetProjectionIdByMovieCinemaAndShowtimeAsync(Guid movieId, Guid cinemaId, string showtime)
        {
            CultureInfo bgCulture = new CultureInfo("bg-BG");

            bool dateTimeValid = DateTime.TryParse(showtime, bgCulture, DateTimeStyles.None,
                out DateTime parsedShowtime);
            if (!dateTimeValid)
            {
                throw new EntityInputDataFormatException("Invalid showtime format.");
            }

            Projection? projection = (await projectionRepository
                .GetAllProjectionAsync(p => p.MovieId == movieId
                                            && p.CinemaId == cinemaId))
                .SingleOrDefault(p => p.Showtime.ToString("g") == parsedShowtime.ToString("g"));

            if (projection == null)
            {
                return null;
            }

            return projection.Id;
        }
    }
}
