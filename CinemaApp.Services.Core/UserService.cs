namespace CinemaApp.Services.Core
{
    using AutoMapper;
    using Contracts;
    using Data.Models;
    using Data.Repository.Contracts;
    using Models.ApplicationUser;

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserManageAllDto>> GetAllManageableUsersAsync(string adminUserId)
        {
            IEnumerable<ApplicationUser> appUsersNoCurrentUser = await userRepository
                .GetAllUserAsync(filterQuery: u => u.Id.ToString() != adminUserId);

            IEnumerable<UserManageAllDto> userManageAllDtos = mapper
                .Map<IEnumerable<UserManageAllDto>>(appUsersNoCurrentUser);

            foreach (UserManageAllDto userDto in userManageAllDtos)
            {
                ApplicationUser appUser = appUsersNoCurrentUser
                    .First(u => u.Id.ToString() == userDto.Id.ToString());

                userDto.Roles = await userRepository
                    .GetUserRolesAsync(appUser);
            }

            return userManageAllDtos;
        }
    }
}
