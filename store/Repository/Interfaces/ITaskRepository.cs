using Task = task_management_system.Models.Task;

namespace task_management_system.Repository;

public interface ITaskRepository
{
    Task<List<Task?>> GetAllTasks();
    System.Threading.Tasks.Task DeleteTask(Task? task);
    System.Threading.Tasks.Task UpdateTask(Task? task);
    System.Threading.Tasks.Task CreateTask(Task? task);
    Task<Task?> GetTask(string id);
}