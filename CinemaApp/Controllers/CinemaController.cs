namespace CinemaApp.Web.Controllers
{
    using AutoMapper;
    using CinemaApp.Services.Core.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using CinemaApp.Services.Models.Cinema;
    using CinemaApp.Web.ViewModels.Cinema;

    public class CinemaController : BaseController
    {
        private readonly ICinemaService cinemaService;
        private readonly ILogger<CinemaController> logger;
        private readonly IMapper mapper;

        public CinemaController(ICinemaService cinemaService, ILogger<CinemaController> logger, IMapper mapper)
        {
            this.cinemaService = cinemaService;
            this.logger = logger;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CinemaAllDto> cinemasDtos = await cinemaService.GetAllCinemasOrderedByLocationAsync();

            IEnumerable<CinemaIndexViewModel> cinemaViewModels = mapper
                .Map<IEnumerable<CinemaIndexViewModel>>(cinemasDtos);

            return View(cinemaViewModels);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Program(Guid id)
        {
            // Implementation for viewing cinema program
            return this.NoContent();
        }
    }
}
