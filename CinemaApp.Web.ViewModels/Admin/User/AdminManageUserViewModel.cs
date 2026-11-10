namespace CinemaApp.Web.ViewModels.Admin.User
{
    using Services.AutoMapping;
    using Services.Models.ApplicationUser;

    public class AdminManageUserViewModel : IMapFrom<UserManageAllDto>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }
            = new List<string>();
    }
}
