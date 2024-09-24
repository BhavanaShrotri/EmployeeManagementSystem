namespace EmployeeManagementSystem.Models
{
    public class ProjectTask
    {
        public ProjectTask(
            string title, 
            string description, 
            string status,
            DateTime dueDate, 
            int employeeId,
            int projectId)
        {
           
            Title = title;
            Description = description;
            Status = status;
            DueDate = dueDate;
            EmployeeId = employeeId;
            ProjectId = projectId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } 
        public DateTime DueDate { get; set; }
        public int EmployeeId { get; set; } 
        public int ProjectId { get; set; } 

        public void SetStatus(string status)
        {
            Status = status;
        }
    }
}
