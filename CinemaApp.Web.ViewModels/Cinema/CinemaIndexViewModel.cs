namespace CinemaApp.Web.ViewModels.Cinema
{
    using CinemaApp.Services.AutoMapping;
    using CinemaApp.Services.Models.Cinema;

    public class CinemaIndexViewModel : IMapFrom<CinemaAllDto> 
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}
