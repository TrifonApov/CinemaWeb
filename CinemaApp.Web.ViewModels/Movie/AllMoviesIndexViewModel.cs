using System.Globalization;
using AutoMapper;

namespace CinemaApp.Web.ViewModels.Movie
{
    using CinemaApp.Services.Models.Movie;
    using CinemaApp.Services.AutoMapping;
    using static CinemaApp.GCommon.ApplicationConstants;
    public class AllMoviesIndexViewModel : IMapFrom<MovieAllDto>, IHaveCustomMappings
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string ReleaseDate { get; set; } = null!;

        public bool IsInUserWatchlist { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<MovieAllDto, AllMoviesIndexViewModel>()
                .ForMember(d => d.ReleaseDate,
                    y => y.MapFrom(s => s.ReleaseDate.ToString(DefaultDateFormat, CultureInfo.InvariantCulture)));
        }
    }
}
