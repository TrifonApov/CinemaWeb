namespace CinemaApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Core.Contracts;

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MovieApiController : ControllerBase
    {
        private readonly IProjectionService projectionService;

        public MovieApiController(IProjectionService projectionService)
        {
            this.projectionService = projectionService;
        }

        [Route("GetShowTimes")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public async Task<ActionResult<IEnumerable<string>>> GetShowtimes(Guid movieId, Guid cinemaId)
        {
            IEnumerable<DateTime> showtimes = await projectionService
                .GetProjectionAvailableShowtimesAsync(movieId, cinemaId);

            IEnumerable<string> showtimesTimeResult = showtimes
                .Select(st => st.ToString("g"));

            return Ok(showtimesTimeResult);
        }
    }
}
