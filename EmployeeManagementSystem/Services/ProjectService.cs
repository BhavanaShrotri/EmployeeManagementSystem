using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public class ProjectService
    {
        private readonly IProject _project;
        public ProjectService(IProject project)
        {
            _project = project;
        }

        public async Task CreateProject(Project project)
        {
            await _project.CreateProjectAsync(project);
        }

        public async Task<Project> GetProject(int id)
        {
            var project = await _project.GetProjectAsync(id);
            return project is null ? throw new Exception($"Project with id {id} not found") : project;
        }

        public async Task<List<Project>> GetProjects()
        {
            return await _project.GetProjectsAsync();
        }

        public async Task DeleteProject(int id)
        {
            var project = await _project.GetProjectAsync(id) ??
                throw new Exception($"Project with id {id} Not found");

            await _project.DeleteProjectAsync(project);
        }
    }
}
