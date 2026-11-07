namespace CinemaApp.Web.Areas.Admin.Controllers
{
    using System.Collections;
    using AutoMapper;
    using Data.Seeding;
    using Microsoft.AspNetCore.Mvc;
    using Services.Core.Contracts;
    using Services.Models.ApplicationUser;
    using ViewModels.Admin.User;

    public class UserManagementController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserManagementController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            string userId = this.GetAdminUserId()!;
            
            IEnumerable<UserManageAllDto> userManageDtos = await userService
                .GetAllManageableUsersAsync(userId);

            IEnumerable<AdminManageUserViewModel> userManageViewModels = mapper
                .Map<IEnumerable<AdminManageUserViewModel>>(userManageDtos);

            ViewData["AllRoles"] = IdentitySeeder.ApplicationRoles;

            return View(userManageViewModels);
        }

        public Task<IActionResult> AssignRole()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> RemoveRole()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteUser()
        {
            throw new NotImplementedException();
        }
    }
}
