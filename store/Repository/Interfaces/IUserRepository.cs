using Microsoft.AspNetCore.Identity;
using task_management_system.Models;
using Task = System.Threading.Tasks.Task;

namespace task_management_system.Repository;

public interface IUserRepository
{
    Task<IdentityResult> AddRoleTo(IdentityUser user, string roleName);
    Task<IdentityResult> CreateIdentity(IdentityUser user, string password);
    Task<IdentityUser?> FindIdentityByEmail(string email);
    Task<bool> RoleExists(string roleName); 
    Task<IdentityRole?> GetRoleById(string? roleId);
    Task CreateUser(User user);
    Task<User?> GetUserById(string id);
    string? RoleIdByName(string name);
}