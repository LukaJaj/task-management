namespace task_management_system;

public class PermissionDoesNotExistException : Exception
{
    public PermissionDoesNotExistException()
    {
    }

    public PermissionDoesNotExistException(string message) : base(message)
    {
    }
}