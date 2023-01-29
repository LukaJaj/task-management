namespace task_management_system;

public class TaskCouldNotBeDeleted:Exception
{
    public TaskCouldNotBeDeleted() : base() {}
    public TaskCouldNotBeDeleted(string message) : base(message) { }
}