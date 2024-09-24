using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService
    {
        private readonly IEmployee _employee;
        public EmployeeService(IEmployee employee)
        {
            _employee = employee;
        }

        public async Task SaveEmployeeAsync(Employee emp)
        {
            await _employee.PersistEmployeeAsync(emp);
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _employee.FetchEmployeeById(id);

            return employee is null ?
                throw new Exception($"Employee with Id {id} not exists") :
                employee;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employee.FetchAllEmployee();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = _employee.FetchEmployeeById(id);

            if (employee is null)
            {
                throw new Exception($"Employee with id {id} not present.");
            }

            await _employee.DeleteEmployeeAsync(employee);
        }

        public async Task UpdateEmployeeAsync(int id, string role)
        {
            var employee = _employee.FetchEmployeeById(id);

            if (employee is null)
            {
                throw new Exception($"Employee with id {id} not present.");
            }

            employee.SetRole(role);
            await _employee.UpdateRoleAsync(employee);
        }
    }
}
