namespace CinemaApp.GCommon.Exceptions
{
    public class EntityKeyNullOrEmpty : Exception
    {
        public EntityKeyNullOrEmpty()
        {

        }

        public EntityKeyNullOrEmpty(string message) 
            : base(message)
        {
            
        }
    }
}
