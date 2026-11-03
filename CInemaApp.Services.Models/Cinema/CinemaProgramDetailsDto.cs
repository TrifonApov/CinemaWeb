using AutoMapper;

namespace CinemaApp.Services.Models.Cinema
{
    using CinemaApp.Services.AutoMapping;
    using CinemaApp.Data.Models;

    public class CinemaProgramDetailsDto : IMapFrom<Cinema>, IHaveCustomMappings
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; } = null!;

        public ICollection<CinemaProgramMovieDto> ProjectionsMovies { get; set; } = null!;
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Cinema, CinemaProgramDetailsDto>()
                .ForMember(d => d.ProjectionsMovies,
                    opt => opt
                        .MapFrom(s => s.Projections.Select(p => p.Movie)));
        }
    }
}
