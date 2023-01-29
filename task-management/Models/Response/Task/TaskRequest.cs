namespace task_management_system.Models;

public class TaskRequest
{
    public string? Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public string AttachedFiles { get; set; }
    public string AssignedTo { get; set; }
    public string UserId { get; set; }
}