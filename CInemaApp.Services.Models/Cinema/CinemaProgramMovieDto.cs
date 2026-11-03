namespace CinemaApp.Services.Models.Cinema
{
    using CinemaApp.Services.AutoMapping;
    using CinemaApp.Data.Models;

    public class CinemaProgramMovieDto : IMapFrom<Movie>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        
    }
}
