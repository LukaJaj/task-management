using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using task_management_system.Models;
using Task = System.Threading.Tasks.Task;

namespace task_management_system.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;

    public UserRepository(ApplicationDbContext db, UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _db = db;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<User?> GetUserById(string id)
    {
        return await _db.Users.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IdentityResult> AddRoleTo(IdentityUser user, string roleName)
    {
        return await _userManager.AddToRoleAsync(user, roleName);
    }

    public async Task<IdentityResult> CreateIdentity(IdentityUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<IdentityUser?> FindIdentityByEmail(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<bool> RoleExists(string roleName)
    {
        return await _roleManager.RoleExistsAsync(roleName);
    }

    public async Task CreateUser(User user)
    {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public string? RoleIdByName(string name)
    {
        return _roleManager.FindByNameAsync(name).Result?.Id;
    }

    public async Task<IdentityRole?> GetRoleById(string? roleId)
    {
        return await _roleManager.Roles.FirstOrDefaultAsync(o => o.Id == roleId);
    }

    public async Task CreateAdmin(User? user)
    {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public string? GetRoleNameByUserId(string userId)
    {
        var roleId = GetRoleIdByUserId(userId);
        return roleId != null ? _roleManager.FindByIdAsync(roleId).Result?.Name : null;
    }

    private string? GetRoleIdByUserId(string userId)
    {
        return _db?.Users?.FirstOrDefault(o => o.Id == userId)?.RoleId;
    }
}