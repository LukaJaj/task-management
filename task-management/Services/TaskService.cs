using task_management_system;
using task_management_system.Models;
using task_management_system.Repository;
using Task = System.Threading.Tasks.Task;

namespace task_management_system.Services;

public class TaskService:ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;
    

    public TaskService(ITaskRepository taskRepository, IUserRepository userRepository)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
    }

    public async Task<TaskResponse> GetTaskById(string id)
    {
        var task = await _taskRepository.GetTask(id);
        return TaskEntityToTaskResponse(task);
    }

    private async Task ValidateTaskRequestBody(Models.Task? task, string permissionName)
    {
        var user = await _userRepository.GetUserById(task.UserId);
        var assignedTo = _userRepository.GetUserById(task.AssignedTo);
        if (!user.Permissions.Contains(permissionName) || assignedTo == null)
        {
            throw new TaskCouldNotBeCreatedException("task couldn't be created");
        }
    }
    
    public async Task CreateTask(TaskRequest? taskReq)
    {
        var task = TaskRequestToTaskEntity(taskReq);
        await ValidateTaskRequestBody(task,"Task-Create");
        await _taskRepository.CreateTask(task);
    }

    public async Task UpdateTask(TaskRequest? taskReq)
    {
        var task = TaskRequestToTaskEntity(taskReq);
        await ValidateTaskRequestBody(task,"Task-Update");
        await _taskRepository.UpdateTask(task);
    }

    public List<TaskResponse> GetAllTasks()
    {
        var tasks = new List<TaskResponse>();
        var tasksFromDb = _taskRepository.GetAllTasks().Result;

        foreach (var task in tasksFromDb)
        {
            tasks.Add(TaskEntityToTaskResponse(task));
        }

        return tasks;
    }

    public async Task DeleteTaskById(string id, string userId)
    {
        var user = await _userRepository.GetUserById(userId);
        if (!user.Permissions.Contains("Task-Delete"))
        {
            throw new TaskCouldNotBeDeleted("task couldn't be deleted");
        }
        
        var task = await _taskRepository.GetTask(id);
        await _taskRepository.DeleteTask(task);
    }

    private Models.Task TaskRequestToTaskEntity(TaskRequest? taskReq)
    {
        return new Models.Task
        {
            Id = Guid.NewGuid().ToString(),
            Title = taskReq.Title,
            ShortDescription = taskReq.ShortDescription,
            Description = taskReq.Description,
            AttachedFiles = taskReq.AttachedFiles,
            AssignedTo = taskReq.AssignedTo,
            UserId = taskReq.UserId
        };
    }
    
    
    private TaskResponse TaskEntityToTaskResponse(Models.Task? task)
    {
        return new Models.TaskResponse
        {
            Title = task.Title,
            ShortDescription = task.ShortDescription,
            Description = task.Description,
            AttachedFiles = task.AttachedFiles,
            AssignedTo = task.AssignedTo,
        };
    }


}