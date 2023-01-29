using Microsoft.AspNetCore.Mvc;
using task_management_system.Models;
using task_management_system.Models.Registration;
using task_management_system.Services;

namespace task_management_system.Controllers;

[Route("api/user")]
public class UserController : Controller
{
    private readonly IUserService _userService;


    public UserController(IConfiguration configuration, IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("create-user-with-role")]
    public async Task<IActionResult> CreateUserWithRole([FromBody] IdentityRegistration userBody)
    {
        string userId;
        try
        {
            userId = await _userService.CreateUserWithRole(userBody);
        }
        catch (UserAlreadyExistsException ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden,
                new Response
                {
                    StatusCode = 403,
                    Status = "error",
                    Message = ex.Message
                });
        }
        catch (UserCreationFailedException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response
                {
                    StatusCode = 500,
                    Status = "error",
                    Message = ex.Message
                });
        }
        catch (RoleNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new Response
            {
                StatusCode = 404,
                Status = "error",
                Message = ex.Message
            });
        }

        return StatusCode(StatusCodes.Status201Created, new Response
        {
            StatusCode = 201,
            Status = "created",
            Message = userId
        });
    }


    [HttpPost("give-permission")]
    public async Task<IActionResult> GivePermission([FromBody] PermissionAuth permissionData)
    {
        try
        {
            await _userService.GivePermission(permissionData);
        }
        catch (AdminIdNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new Response
            {
                Status = "error",
                StatusCode = 404,
                Message = ex.Message
            });
        }
        catch (UserIdNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new Response
            {
                Status = "error",
                StatusCode = 404,
                Message = ex.Message
            });
        }
        catch (PermissionDoesNotExistException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new Response
            {
                Status = "error",
                StatusCode = 404,
                Message = ex.Message
            });
        }

        return StatusCode(StatusCodes.Status201Created, new Response
        {
            Status = "created",
            StatusCode = 201,
            Message = "Permission has been successfully given"
        });
    }
}