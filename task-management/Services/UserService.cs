using Microsoft.AspNetCore.Identity;
using task_management_system.Models;
using task_management_system.Models.Registration;
using task_management_system.Repository;
using task_management_system.Services;
using Task = System.Threading.Tasks.Task;

namespace task_management_system.Interfaces;

public class UserService : IUserService
{
    private readonly IPermissionRepository _permissionRepo;
    private readonly IUserRepository _userRepository;

    public UserService(IPermissionRepository permissionRepo, IUserRepository userRepository)
    {
        _permissionRepo = permissionRepo;
        _userRepository = userRepository;
    }

    public async Task<string> CreateUserWithRole(IdentityRegistration identityRegistration)
    {
        var userFromDb = await _userRepository.FindIdentityByEmail(identityRegistration.Email);
        if (userFromDb is not null) throw new UserAlreadyExistsException("User already exists with given email");

        var identityUser = new IdentityUser
        {
            Email = identityRegistration.Email, UserName = identityRegistration.Username,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        if (!await _userRepository.RoleExists(identityRegistration.RoleName))
            throw new RoleNotFoundException("Role was not found");

        var result = await _userRepository.CreateIdentity(identityUser, identityRegistration.Password);
        if (!result.Succeeded) throw new UserCreationFailedException("Failed to create user");

        await _userRepository.AddRoleTo(identityUser, identityRegistration.RoleName);

        var user = DetermineUserRole(identityRegistration);
        await _userRepository.CreateUser(user);
        return user.Id;
    }


    public async Task GivePermission(PermissionAuth permission)
    {
        var admin = await _userRepository.GetUserById(permission.AdminId);

        var isProvidedIdAdmin = _userRepository.GetRoleById(admin.RoleId);
        if (isProvidedIdAdmin.Result?.Name != RoleName.Admin)
            throw new AdminIdNotFoundException("provided id is not admin id");

        if (await _permissionRepo.PermissionByName(permission.PermissionName) == null)
            throw new PermissionDoesNotExistException("permission does not exists");

        var user = await _userRepository.GetUserById(permission.UserId);
        var isProvidedIdUser = _userRepository.GetRoleById(user?.RoleId);
        if (isProvidedIdUser.Result?.Name != RoleName.User)
            throw new UserIdNotFoundException("provided id is not user id");

        await _permissionRepo.AddPermissionToExistingUser(user, permission.PermissionName);
    }


    private User DetermineUserRole(IdentityRegistration identityRegistration)
    {
        var user = new User { Id = Guid.NewGuid().ToString() };

        if (identityRegistration.RoleName == RoleName.Admin)
        {
            user.RoleId = _userRepository?.RoleIdByName(RoleName.Admin);
            user.Permissions = new List<string> { "Task-Create", "Task-Delete", "Task-Update" };
        }
        else
        {
            user.RoleId = _userRepository?.RoleIdByName(RoleName.User);
            user.Permissions = new List<string>();
        }

        return user;
    }
}