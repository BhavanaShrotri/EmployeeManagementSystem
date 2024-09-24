using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public class TaskService
    {
        private readonly ITask _task;
        public TaskService(ITask task)
        {
            _task = task;
        }

        public async Task CreateTask(ProjectTask task)
        {
            await _task.CreateTaskAsync(task);
        }

        public async Task<ProjectTask> GetTaskAsync(int id)
        {
            var task = await _task.FetchTaskAsync(id);
            return task is null ? throw new Exception($"Task with id {id} not found") : task;
        }

        public async Task<List<ProjectTask>> GetTasksByProjectAsync(int projectId)
        {
            return await _task.FetchTasksByProjectAsync(projectId);
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _task.FetchTaskAsync(id)
                ?? throw new Exception($"task with Id {id} not found");

            await _task.DeleteTaskAsync(task);
        }

        public async Task UpdateStatusAsync(int id, string status)
        {
            var task = await _task.FetchTaskAsync(id)
                ?? throw new Exception($"task with Id {id} not found");

            task.SetStatus(status);
            await _task.UpdateStatus(task);
        }
    }
}