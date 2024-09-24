using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IProject 
    {
        Task CreateProjectAsync(Project project);
        Task<Project?> GetProjectAsync(int id);
        Task<List<Project>> GetProjectsAsync();
        Task DeleteProjectAsync(Project project);
    }
}
