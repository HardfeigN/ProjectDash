using Microsoft.EntityFrameworkCore;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;
using ProjectDash.Persistence.EntityTypeConfigurations;

namespace ProjectDash.Persistence
{
    public class ProjectDashDbContext : DbContext, IProjectDashDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEmployees> ProjectEmployees { get; set; }

        public ProjectDashDbContext(DbContextOptions<ProjectDashDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
