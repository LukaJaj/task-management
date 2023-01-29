using System.Text.Json.Serialization;

namespace task_management_system.Models;

public class PermissionAuth
{
    [JsonPropertyName("AdminId")] public string AdminId { get; set; }

    [JsonPropertyName("UserId")] public string UserId { get; set; }

    [JsonPropertyName("PermissionName")] public string PermissionName { get; set; }
}