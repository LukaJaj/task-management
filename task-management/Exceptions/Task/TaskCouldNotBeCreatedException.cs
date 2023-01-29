namespace task_management_system;

public class TaskCouldNotBeCreatedException : Exception
{
    public TaskCouldNotBeCreatedException()
    {
    }

    public TaskCouldNotBeCreatedException(string message) : base(message)
    {
    }
}