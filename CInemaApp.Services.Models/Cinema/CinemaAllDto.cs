namespace CinemaApp.Services.Models.Cinema
{
    using CinemaApp.Services.AutoMapping;
    using CinemaApp.Data.Models;
    public class CinemaAllDto : IMapFrom<Cinema>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}
