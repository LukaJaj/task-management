using Microsoft.AspNetCore.Mvc;
using task_management_system.Models;
using task_management_system.Services;

namespace task_management_system.Controllers;

[Route("api/task")]
public class TaskController : Controller
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTask([FromBody] TaskRequest? task)
    {
        try
        {
            await _taskService.CreateTask(task);
        }
        catch (TaskCouldNotBeCreatedException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                StatusCode = 500,
                Status = "error",
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                StatusCode = 500,
                Status = "error",
                Message = ex.Message
            });
        }

        return StatusCode(StatusCodes.Status201Created, new Response
        {
            StatusCode = 201,
            Status = "created",
            Message = "task created successfully"
        });
    }


    [HttpPut("update")]
    public async Task<IActionResult> UpdateTask([FromBody] TaskRequest? task)
    {
        try
        {
            await _taskService.UpdateTask(task);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                StatusCode = 500,
                Status = "error",
                Message = ex.Message
            });
        }

        return StatusCode(StatusCodes.Status200OK, new Response
        {
            StatusCode = 200,
            Status = "ok",
            Message = "task updated successfully"
        });
    }


    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery(Name = "task_id")] string taskId,
        [FromQuery(Name = "user_id")] string userId)
    {
        try
        {
            await _taskService.DeleteTaskById(taskId, userId);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                StatusCode = 500,
                Status = "error",
                Message = ex.Message
            });
        }

        return StatusCode(StatusCodes.Status204NoContent, new Response
        {
            StatusCode = 204,
            Status = "no content",
            Message = "task deleted successfully"
        });
    }

    [HttpGet]
    public IActionResult Tasks()
    {
        List<TaskResponse> tasks;
        try
        {
            tasks = _taskService.GetAllTasks();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                StatusCode = 500,
                Status = "error",
                Message = ex.Message
            });
        }

        return StatusCode(StatusCodes.Status200OK, tasks);
    }
}