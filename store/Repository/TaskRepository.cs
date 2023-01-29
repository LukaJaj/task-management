using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using task_management_system.Models;
using Task = System.Threading.Tasks.Task;

namespace task_management_system.Repository;

public class TaskRepository:ITaskRepository
{
    private readonly ApplicationDbContext _db;

    public TaskRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task UpdateTask(Models.Task? task)
    {
        if (task != null) _db.Tasks.Update(task);
        await _db.SaveChangesAsync();
    }

    public async Task CreateTask(Models.Task? task)
    {
        if (task != null) await _db.Tasks.AddAsync(task);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Models.Task?>> GetAllTasks()
    {
        return await _db.Tasks.ToListAsync();
    }

    public async Task DeleteTask(Models.Task? task)
    {
        if (task != null) _db.Tasks.Remove(task);
        await _db.SaveChangesAsync();
    }

    public async Task<Models.Task?> GetTask(string id)
    {
        return await _db.Tasks.FirstOrDefaultAsync(o => o.Id == id);
    }
}