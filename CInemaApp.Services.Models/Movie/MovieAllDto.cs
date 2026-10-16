using System.Globalization;
using AutoMapper;

using static CinemaApp.GCommon.ApplicationConstants;

namespace CinemaApp.Services.Models.Movie
{
    using Data.Models;
    using AutoMapping;

    public class MovieAllDto : IMapFrom<Movie>, IHaveCustomMappings
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string ReleaseDate { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MovieAllDto>()
                .ForMember(d => d.ReleaseDate,
                    y => y.MapFrom(s => s.ReleaseDate
                        .ToString(DefaultDateFormat, CultureInfo.InvariantCulture)));
        }
    }
}
