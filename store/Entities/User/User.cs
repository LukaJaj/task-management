using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_management_system.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("user_id")]
    public string Id { get; set; }

    [Column("role_id")] // 
    public string? RoleId { get; set; }

    [Column("permissions", TypeName = "text[]")]
    public List<string> Permissions { get; set; }
}