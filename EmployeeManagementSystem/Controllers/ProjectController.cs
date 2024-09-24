using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [Authorize(Policy = "AdminAndProjectManager")]
        [HttpPost("add")]
        public async Task AddProjectAsync(
            string name, 
            string description, 
            DateTime startdate,
            DateTime endDate)
        {
            await _projectService.CreateProject(new Project(name, description,startdate,endDate ));
        }

        [HttpGet("{id}")]
        public async Task GetProjectAsync(int id)
        {
            await _projectService.GetProject(id);
        }

        [Authorize(Policy = "AdminAndProjectManager")]
        [HttpGet("display-all-projects")]
        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _projectService.GetProjects();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task DeleteProjectAsync(int id)
        {
            await _projectService.DeleteProject(id);
        }
    }
}
