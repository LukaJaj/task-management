using Microsoft.EntityFrameworkCore;
using task_management_system.Models;
using Task = System.Threading.Tasks.Task;

namespace task_management_system.Repository;

public class PermissionRepository : IPermissionRepository
{
    private readonly ApplicationDbContext _db;

    public PermissionRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AddPermissionToExistingUser(User? existingUser, string permission)
    {
        var p = existingUser?.Permissions?.Any(o => o == permission);
        if (p is true) throw new Exception("duplicate permission");

        existingUser?.Permissions?.Add(permission);
        _db.Users.Update(existingUser);
        await _db.SaveChangesAsync();
    }

    public async Task<Permission?> PermissionByName(string permissionName)
    {
        return await _db.Permissions.FirstOrDefaultAsync(p => p.Name == permissionName);
    }
}