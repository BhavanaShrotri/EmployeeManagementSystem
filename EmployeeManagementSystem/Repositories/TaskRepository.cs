using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories
{
    public class TaskRepository : ITask
    {
        private readonly EmployeeDbContext _context;

        public TaskRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task CreateTaskAsync(ProjectTask task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task<ProjectTask?> FetchTaskAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<List<ProjectTask>> FetchTasksByProjectAsync(int projectId)
        {
            return await _context.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();
        }

        public async Task DeleteTaskAsync(ProjectTask task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatus(ProjectTask task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
