using System.Globalization;
using AutoMapper;
using CinemaApp.Services.AutoMapping;
using CinemaApp.Services.Models.Movie;
using static CinemaApp.GCommon.ApplicationConstants;

namespace CinemaApp.Web.ViewModels.Movie
{
    public class MovieDetailsViewModel : IMapFrom<MovieDetailsDto>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string ReleaseDate { get; set; } = null!;

        public string Director { get; set; } = null!;

        public int Duration { get; set; }

        public string Description { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<MovieAllDto, AllMoviesIndexViewModel>()
                .ForMember(d => d.ReleaseDate,
                    y => y.MapFrom(s => s.ReleaseDate.ToString(DefaultDateFormat, CultureInfo.InvariantCulture)));
        }
    }
}
