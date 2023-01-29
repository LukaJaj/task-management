
namespace task_management_system
{
    public class UserCreationFailedException : Exception
    {
        public UserCreationFailedException() : base() { }
        public UserCreationFailedException(string message) : base(message) { }

    }
}

