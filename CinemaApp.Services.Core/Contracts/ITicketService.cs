namespace CinemaApp.Services.Core.Contracts
{
    public interface ITicketService
    {
        Task<bool> BuyTicketAsync(Guid projectionId, string userId, int quantity);
    }
}
