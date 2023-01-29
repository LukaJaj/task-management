using task_management_system.Models;
using task_management_system.Models.Registration;
using Task = System.Threading.Tasks.Task;

namespace task_management_system.Services;

public interface IUserService
{
    Task<string> CreateUserWithRole(IdentityRegistration identityRegistration);
    Task GivePermission(PermissionAuth permission);
}