namespace CinemaApp.Services.Models.Watchlist
{
    using AutoMapper;
    using CinemaApp.Data.Models;
    using CinemaApp.Services.AutoMapping;
    using CinemaApp.Services.Models.Movie;
    using static CinemaApp.GCommon.ApplicationConstants;

    public class WatchlistMovieDto : IMapFrom<Movie>, IHaveCustomMappings
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;
        
        public string? ImageUrl { get; set; }

        public DateTime ReleaseDate { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MovieDetailsDto>()
                .ForMember(d => d.ImageUrl,
                    y => y.MapFrom(s => s.ImageUrl ?? DefaultImageUrl));
        }
    }
}
