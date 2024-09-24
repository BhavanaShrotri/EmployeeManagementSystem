using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [Authorize(Policy = "AdminAndProjectManager")]
        [HttpPost("Create")]
        public async Task CreateTaskAsync(
            string title,
            string description,
            string status,
            DateTime dueDate,
            int employeeId, int projectId)
        {
            var isStatusAvailable = Enum.TryParse<StatusTypes>(status, true, out var statusType);

            if (!isStatusAvailable)
                throw new Exception($"Status {status} not available.");

            await _taskService.CreateTask(
                new ProjectTask(
                    title,
                    description,
                    statusType.ToString(),
                    dueDate, employeeId, projectId));
        }

        [HttpGet("{id}")]
        public async Task<ProjectTask> GetTaskAsync(int id)
        {
            return await _taskService.GetTaskAsync(id);
        }

        [HttpGet("project/{projectId}")]
        public async Task GetTasksByProjectAsync(int projectId)
        {
            await _taskService.GetTasksByProjectAsync(projectId);
        }

        [Authorize(Policy = "AdminAndProjectManager")]
        [HttpDelete("delete/{id}")]
        public async Task DeleteTaskAsync(int id)
        {
            await _taskService.DeleteTaskAsync(id);
        }

        [Authorize(Policy = "AdminAndDeveloper")]
        [HttpDelete("update-status/{id}")]
        public async Task UpdateStatusAsync(int id, string status)
        {
            var isStatusAvailable = Enum.TryParse<StatusTypes>(status, true, out var statusType);

            if (!isStatusAvailable)
                throw new Exception($"Status {status} not available.");

            await _taskService.UpdateStatusAsync(id, statusType.ToString());
        }
    }
}
