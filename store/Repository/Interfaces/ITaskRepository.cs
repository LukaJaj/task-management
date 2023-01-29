using Microsoft.EntityFrameworkCore.ChangeTracking;
using task_management_system.Models;
using Task = System.Threading.Tasks.Task;

namespace task_management_system.Repository;

public interface ITaskRepository
{
    Task<List<Models.Task?>> GetAllTasks();
    Task DeleteTask(Models.Task? task);
    Task UpdateTask(Models.Task? task);
    Task CreateTask(Models.Task? task);
    Task<Models.Task?> GetTask (string id);
}