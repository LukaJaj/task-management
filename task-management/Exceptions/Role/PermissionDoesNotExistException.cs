namespace task_management_system;

public class PermissionDoesNotExistException: Exception
{
    public PermissionDoesNotExistException() : base() {}
    public PermissionDoesNotExistException(string message) : base(message) { }
}