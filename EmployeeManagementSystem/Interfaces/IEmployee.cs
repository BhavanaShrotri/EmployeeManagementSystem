using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IEmployee
    {
        Task PersistEmployeeAsync(Employee employee);
        Employee? FetchEmployeeById(int id);
        List<Employee> FetchAllEmployee();
        Task DeleteEmployeeAsync(Employee employee);
        Task UpdateRoleAsync(Employee emp);
    }
}