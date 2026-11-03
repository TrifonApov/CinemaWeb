namespace CinemaApp.Services.Core.Contracts
{
    using CinemaApp.Services.Models.Cinema;

    public interface ICinemaService
    {
        Task<IEnumerable<CinemaAllDto>> GetAllCinemasOrderedByLocationAsync();
    }
}
