namespace CinemaApp.Services.Core
{
    using CinemaApp.Data.Repository.Contracts;
    using CinemaApp.Services.Core.Contracts;
    using AutoMapper;
    using CinemaApp.Data.Models;
    using CinemaApp.Services.Models.Cinema;

    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository cinemaRepository;

        private readonly IMapper mapper;

        public CinemaService(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            this.cinemaRepository = cinemaRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CinemaAllDto>> GetAllCinemasOrderedByLocationAsync()
        {
            IEnumerable<Cinema> allCinemas = (await cinemaRepository
                .GetAllCinemas(
                    filterQuery: null,
                    projectionQuery: c => new Cinema
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Location = c.Location
                    },
                    includeProjections: false
                ))
                .OrderBy(c => c.Location)
                .ToArray();

            IEnumerable<CinemaAllDto> allCinemasDtos = mapper
                .Map<IEnumerable<CinemaAllDto>>(allCinemas);

            return allCinemasDtos;
        }

        public async Task<CinemaProgramDetailsDto?> GetCinemaProgramByIdTask(Guid cinemaId)
        {
            Cinema? cinema = await cinemaRepository
                .GetCinemaByIdAsyncIncludeMovies(cinemaId);

            if (cinema == null)
            {
                return null;
            }

            CinemaProgramDetailsDto cinemaProgramDto = mapper
                .Map<CinemaProgramDetailsDto>(cinema);

            return cinemaProgramDto;
        }
    }
}
