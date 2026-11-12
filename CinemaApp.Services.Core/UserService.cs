namespace CinemaApp.Services.Core
{
    using AutoMapper;
    using CinemaApp.GCommon.Exceptions;
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

        public async Task<bool> AssignRoleToUserAsync(Guid userId, string role)
        {
            if (userId == Guid.Empty || string.IsNullOrWhiteSpace(role))
            {
                throw new EntityInputDataFormatException();
            }

            bool result = await userRepository
                .UpdateUserRoleAsync(userId, role);

            return result;
        }

        public async Task<bool> RemoveRoleFromUserAsync(Guid userId, string role)
        {
            if (userId == Guid.Empty || string.IsNullOrWhiteSpace(role))
            {
                throw new EntityInputDataFormatException();
            }

            bool result = await userRepository
                .UpdateUserRoleAsync(userId, role, removingRole: true);

            return result;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new EntityInputDataFormatException();
            }

            bool result = await userRepository
                .DeleteUserAsync(userId);

            return result;
        }
    }
}
