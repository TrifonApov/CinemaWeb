namespace CinemaApp.Web.ViewModels.Cinema
{
    using CinemaApp.Services.AutoMapping;
    using CinemaApp.Services.Models.Cinema;

    public class CinemaProgramMoviesViewModel : IMapFrom<CinemaProgramMovieDto>
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;
        
        public string Director { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

    }
}
