using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories
{
    public class EmployeeDbContext : DbContext
    {
        #region Tables
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        #endregion

        public EmployeeDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            modelBuilder.Entity<Employee>().Property(_ => _.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Project>().HasKey(e => e.Id);
            modelBuilder.Entity<Project>().Property(_ => _.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<ProjectTask>().HasKey(e => e.Id);
            modelBuilder.Entity<ProjectTask>().Property(_ => _.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
