namespace task_management_system
{
    public class UserAlreadyExistsException:Exception
    {
        public UserAlreadyExistsException() : base() {}
        public UserAlreadyExistsException(string message) : base(message) { }

    }
}