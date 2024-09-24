using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
  
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("add")]
        public async Task SaveEmployeeAsync(string name, int salary, string role)
        {
            var isRoleAvailable = Enum.TryParse<RoleTypes>(role, true, out var roleType);

            if (!isRoleAvailable)
            {
                throw new Exception($"Role {role} not available.");
            }

            await _employeeService.SaveEmployeeAsync(
                new Employee(name, salary, roleType.ToString()));
        }

        [HttpGet("{id}")]
        public Employee GetEmployee(int id)
        {
            return _employeeService.GetEmployeeById(id);
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("get-all-employees")]
        public List<Employee> GetEmployees()
        {
            return _employeeService.GetAllEmployees();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task GetEmployees(int id)
        {
             await _employeeService.DeleteEmployeeAsync(id);
        }


        [Authorize(Policy = "Admin")]
        [HttpPatch("update-role/{id}")]
        public async Task GetEmployeesAsync(int id, string role)
        {
            var isRoleAvailable = Enum.TryParse<RoleTypes>(role, true, out var roleType);

            if (!isRoleAvailable)
            {
                throw new Exception($"Role {role} not available.");
            }
            await _employeeService.UpdateEmployeeAsync(id, role);
        }

    }
}
