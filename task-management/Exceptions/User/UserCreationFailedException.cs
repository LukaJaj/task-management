namespace task_management_system;

public class UserCreationFailedException : Exception
{
    public UserCreationFailedException()
    {
    }

    public UserCreationFailedException(string message) : base(message)
    {
    }
}