using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDash.Domain;

namespace ProjectDash.Persistence.EntityTypeConfigurations
{
    public class ProjectEmployeesConfiguration : IEntityTypeConfiguration<ProjectEmployee>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
        {
            builder.HasKey(pe => new { pe.EmployeeId, pe.ProjectId });
            builder.HasIndex(pe => pe.EmployeeId);
            builder.HasIndex(pe => pe.ProjectId);
            builder.HasOne(pe => pe.Project)
                .WithMany(project => project.Employees)
                .HasForeignKey(pe => pe.ProjectId)
                .OnDelete(DeleteBehavior.Cascade); //if someone is trying to delete the Project, all the ProjectEmployees must be deleted
            builder.HasOne(pe => pe.Employee)
                .WithMany(project => project.Projects)
                .HasForeignKey(pe => pe.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict); //The Employee cannot be deleted iF there are ProjectEmployee(s) with this Employee
        }
    }
}
