namespace task_management_system;

public class AdminIdNotFoundException : Exception
{
    public AdminIdNotFoundException()
    {
    }

    public AdminIdNotFoundException(string message) : base(message)
    {
    }
}