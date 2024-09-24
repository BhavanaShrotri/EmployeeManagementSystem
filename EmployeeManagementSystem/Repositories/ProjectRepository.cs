using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories
{
    public class ProjectRepository : IProject
    {
        private readonly EmployeeDbContext _context;

        public ProjectRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task CreateProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task<Project?> GetProjectAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task DeleteProjectAsync(Project project)
        {

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
