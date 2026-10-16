namespace CinemaApp.Web.ViewModels.Movie
{
    using CinemaApp.Services.Models.Movie;
    using CinemaApp.Services.AutoMapping;
    public class AllMoviesIndexViewModel : IMapFrom<MovieAllDto>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string ReleaseDate { get; set; } = null!;
    }
}
