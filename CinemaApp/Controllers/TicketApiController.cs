namespace CinemaApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Ticket;

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TicketApiController : ControllerBase
    {
        [Route("BuyTicket")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> BuyTicket(BuyTicketInputModel inputModel)
        {
            return Ok($"{inputModel.CinemaId} - {inputModel.MovieId} - {inputModel.Quantity} - {inputModel.Showtime}");
        }
    }
}
