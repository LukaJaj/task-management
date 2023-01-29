using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace task_management_system.Models;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Permission> Permissions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Task?> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedRoles(builder);
        SeedPermissions(builder);
    }

    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Name = RoleName.Admin, ConcurrencyStamp = "random-1", NormalizedName = "ADMIN" },
            new IdentityRole { Name = RoleName.User, ConcurrencyStamp = "random-2", NormalizedName = "USER" }
        );
    }

    private void SeedPermissions(ModelBuilder builder)
    {
        builder.Entity<Permission>().HasData(
            new Permission { Id = 1, Name = "Task-Create" },
            new Permission { Id = 2, Name = "Task-Delete" },
            new Permission { Id = 3, Name = "Task-Update" }
        );
    }
}