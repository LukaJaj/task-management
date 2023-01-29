using task_management_system.Models;
using Task = System.Threading.Tasks.Task;

namespace task_management_system.Repository;

public interface IPermissionRepository
{
    Task AddPermissionToExistingUser(User? existingUser, string permission);
    Task<Permission?> PermissionByName(string permissionName);
}