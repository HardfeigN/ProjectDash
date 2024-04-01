using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDash.Domain;

namespace ProjectDash.Persistence.EntityTypeConfigurations
{
    public class ProjectEmployeesConfiguration : IEntityTypeConfiguration<ProjectEmployees>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployees> builder)
        {
            builder.HasNoKey();
            builder.Property(project => project.ProjectId).IsRequired();
            builder.Property(project => project.EmployeeId).IsRequired();
        }
    }
}
