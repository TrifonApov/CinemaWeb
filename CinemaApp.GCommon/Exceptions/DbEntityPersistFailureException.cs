namespace CinemaApp.GCommon.Exceptions
{
    public class DbEntityPersistFailureException : Exception
    {
        public DbEntityPersistFailureException()
        {
            
        }

        public DbEntityPersistFailureException(string message)
            : base(message)
        {
            
        }
    }
}
