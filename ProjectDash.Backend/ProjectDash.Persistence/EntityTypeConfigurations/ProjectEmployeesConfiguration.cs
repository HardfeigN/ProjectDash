using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDash.Domain;

namespace ProjectDash.Persistence.EntityTypeConfigurations
{
    public class ProjectEmployeesConfiguration : IEntityTypeConfiguration<ProjectEmployees>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployees> builder)
        {
            builder.HasKey(pe => new { pe.EmployeeId, pe.ProjectId });
            builder.HasIndex(pe => pe.EmployeeId);
            builder.HasIndex(pe => pe.ProjectId);
            builder.HasOne(pe => pe.Project)
                .WithMany(project => project.ProjectEmployees)
                .HasForeignKey(pe => pe.ProjectId);
            builder.HasOne(pe => pe.Employee)
                .WithMany(project => project.ProjectEmployees)
                .HasForeignKey(pe => pe.EmployeeId);
        }
    }
}
