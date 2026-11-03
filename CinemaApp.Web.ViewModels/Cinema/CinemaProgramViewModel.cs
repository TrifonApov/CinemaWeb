namespace CinemaApp.Web.ViewModels.Cinema
{
    using CinemaApp.Services.AutoMapping;
    using CinemaApp.Services.Models.Cinema;

    public class CinemaProgramViewModel : IMapFrom<CinemaProgramDetailsDto>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<CinemaProgramMoviesViewModel> ProjectionsMovies { get; set; } = new List<CinemaProgramMoviesViewModel>();
    }
}
