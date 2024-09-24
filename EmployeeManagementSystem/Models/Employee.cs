namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public Employee(string name, int salary, string role)
        {
            Name = name;
            Salary = salary;
            Role = role;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Role { get; set; }

        public void SetRole(string role) 
        {
            Role = role;
        }
    }
}
