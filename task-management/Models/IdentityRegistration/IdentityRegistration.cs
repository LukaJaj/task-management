using System.ComponentModel.DataAnnotations;

namespace task_management_system.Models.Registration;

public class IdentityRegistration
{
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Role Name is required")]
    public string RoleName { get; set; }
}