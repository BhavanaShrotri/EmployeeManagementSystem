using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task DeleteEmployeeAsync(Employee emp)
        {
           _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
        }

        public List<Employee> FetchAllEmployee()
        {
            return _context.Employees.ToList();
        }

        public Employee? FetchEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id);
        }

        public async Task PersistEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task  UpdateRoleAsync(Employee emp)
        {
             _context.Employees.Update(emp);
            await _context.SaveChangesAsync();
        }
    }
}
