namespace task_management_system;

public class TaskCouldNotBeDeleted : Exception
{
    public TaskCouldNotBeDeleted()
    {
    }

    public TaskCouldNotBeDeleted(string message) : base(message)
    {
    }
}