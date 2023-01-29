namespace task_management_system;

public class UserIdNotFoundException: Exception
{
    public UserIdNotFoundException() : base() {}
    public UserIdNotFoundException(string message) : base(message) { }
}