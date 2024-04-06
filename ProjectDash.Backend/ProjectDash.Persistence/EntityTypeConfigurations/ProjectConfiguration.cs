using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDash.Domain;

namespace ProjectDash.Persistence.EntityTypeConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(project => project.Id);
            builder.HasIndex(project => project.Id).IsUnique();
            builder.Property(project => project.Name).HasMaxLength(50).IsRequired();
            builder.Property(project => project.Performer).HasMaxLength(80).IsRequired();
            builder.Property(project => project.Customer).HasMaxLength(80).IsRequired();
            builder.Property(project => project.StartDate).IsRequired();
            builder.Property(project => project.EndDate).IsRequired();
            builder.Property(project => project.Priority).IsRequired();
            builder.Property(project => project.ProjectLeaderId).IsRequired();
        }
    }
}
