using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces
{
    public interface ITask
    {
        Task CreateTaskAsync(ProjectTask task);
        Task<ProjectTask?> FetchTaskAsync(int id);
        Task<List<ProjectTask>> FetchTasksByProjectAsync(int projectId);
        Task DeleteTaskAsync(ProjectTask task);
        Task UpdateStatus(ProjectTask task);
    }
}
