using task_management_system.Models;
using Task = System.Threading.Tasks.Task;

namespace task_management_system.Services;

public interface ITaskService
{

    List<TaskResponse> GetAllTasks();
    Task DeleteTaskById(string id, string userId);
    Task UpdateTask(TaskRequest? task);
    Task CreateTask(TaskRequest? task);
    Task<TaskResponse> GetTaskById(string id);
}