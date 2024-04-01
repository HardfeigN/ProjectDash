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

        public ProjectDashDbContext(DbContextOptions<ProjectDashDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.Entity<Project>()
                .HasMany(e => e.Employee)
                .WithMany(e => e.Project)
                .UsingEntity<Dictionary<string, object>>(
                "ProjectEmployees",
                j => j
                    .HasOne<Employee>()
                    .WithMany()
                    .HasForeignKey("EmployeeId"),
                j => j
                    .HasOne<Project>()
                    .WithMany()
                    .HasForeignKey("ProjectId"));
            base.OnModelCreating(builder);
        }
    }
}
