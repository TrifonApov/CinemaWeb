namespace CinemaApp.GCommon
{
    public static class ExceptionMessages
    {
        public const string RoleSeedingErrorMessage = "An error occured while seeding the role {0}. Please see inner exception for details.";
        public const string AdminUserSeedingEmailNotFoundMessage = "Admin email is not configured.";
        public const string AdminUserSeedingPasswordNotFoundMessage = "Admin password is not configured.";
        public const string AdminUserSeedingErrorMessage = "An error occured while seeding the admin user. Please see inner exception for details.";
    }
}
