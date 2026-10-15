namespace CinemaApp.GCommon.Exceptions
{
    public class DbEntityCreatePersistFailureException : Exception
    {
        public DbEntityCreatePersistFailureException()
        {
            
        }

        public DbEntityCreatePersistFailureException(string message)
            : base(message)
        {
            
        }
    }
}
