using System.Globalization;
using AutoMapper;

using static CinemaApp.GCommon.ApplicationConstants;

namespace CinemaApp.Services.Models.Movie
{
    using Data.Models;
    using AutoMapping;

    public class MovieAllDto : IMapFrom<Movie>, IMapTo<Movie>, IHaveCustomMappings
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public DateTime ReleaseDate { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MovieDetailsDto>()
                .ForMember(d => d.ImageUrl,
                    y => y.MapFrom(s => s.ImageUrl ?? DefaultImageUrl));

            configuration.CreateMap<MovieAllDto, Movie>()
                .ForMember(d => d.Id, option => option.Ignore());
        }
    }
}
