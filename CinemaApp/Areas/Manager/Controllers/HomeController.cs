namespace CinemaApp.Web.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Core.Contracts;

    public class HomeController : BaseManagerController
    {
        public HomeController(IManagerService managerService)
            : base(managerService)
        {
        }

        public async Task<IActionResult> Index()
        {
            string? userId = GetUserId()!;
            
            bool isUserManager = await IsUserManagerAsync(userId);

            if (!isUserManager)
            {
                return Unauthorized();
            }
            return View();
        }
    }
}
