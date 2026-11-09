namespace CinemaApp.Web.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Core.Contracts;
    using ViewModels.Ticket;
    using CinemaApp.GCommon.Exceptions;
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TicketApiController : ControllerBase
    {
        private readonly IProjectionService projectionService;
        private readonly ITicketService ticketService;

        public TicketApiController(IProjectionService projectionService, ITicketService ticketService)
        {
            this.projectionService = projectionService;
            this.ticketService = ticketService;
        }

        [Route("BuyTicket")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> BuyTicket(BuyTicketInputModel inputModel)
        {
            try
            {
                Guid? projectionId = await projectionService
                    .GetProjectionIdByMovieCinemaAndShowtimeAsync(
                        inputModel.MovieId,
                        inputModel.CinemaId, 
                        inputModel.Showtime);
            
                if (projectionId == null)
                {
                    return NotFound("Invalid projection.");
                }

                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

                bool isTicketBought = await ticketService
                    .BuyTicketAsync(projectionId.Value, userId, inputModel.Quantity);

                if (!isTicketBought)
                {
                    return BadRequest("Failed to buy ticket.");
                }

                 
                return Ok();
            }
            catch (EntityInputDataFormatException eidfe)
            {
                return BadRequest(eidfe.Message);
            }
        }
    }
}
