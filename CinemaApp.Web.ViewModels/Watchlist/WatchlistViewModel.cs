
using System.Globalization;

namespace CinemaApp.Web.ViewModels.Watchlist
{
    using CinemaApp.Data.Models;
    using CinemaApp.Services.AutoMapping;
    using CinemaApp.Services.Models.Movie;
    using static CinemaApp.GCommon.ApplicationConstants;
    using AutoMapper;
    using CinemaApp.Services.Models.Watchlist;

    public class WatchlistViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public Guid MovieId { get; set; }

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;
        
        public string ImageUrl { get; set; } = null!;

        public string ReleaseDate { get; set; } = null!;
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MovieDetailsDto>()
                .ForMember(d => d.ImageUrl,
                    y => y.MapFrom(s => s.ImageUrl ?? DefaultImageUrl));
            configuration.CreateMap<WatchlistMovieDto, WatchlistViewModel>()
                .ForMember(d => d.MovieId, option => option.MapFrom(s => s.Id))
                .ForMember(d => d.ReleaseDate, option => option.MapFrom(s => s.ReleaseDate.ToString(DefaultDateFormat, CultureInfo.InvariantCulture)));
        }
    }
}
