namespace task_management_system;

public class RoleNotFoundException : Exception
{
    public RoleNotFoundException()
    {
    }

    public RoleNotFoundException(string message) : base(message)
    {
    }
}