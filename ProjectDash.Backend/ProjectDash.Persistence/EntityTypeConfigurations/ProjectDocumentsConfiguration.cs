using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDash.Domain;

namespace ProjectDash.Persistence.EntityTypeConfigurations
{
    public class ProjectDocumentsConfiguration : IEntityTypeConfiguration<ProjectDocument>
    {
        public void Configure(EntityTypeBuilder<ProjectDocument> builder)
        {
            builder.HasKey(projectDocument => new { projectDocument.Id, projectDocument.ProjectId });
            builder.HasIndex(projectDocument => projectDocument.Id).IsUnique();
            builder.HasOne(projectDocument => projectDocument.Project)
                .WithMany(project => project.ProjectDocuments)
                .HasForeignKey(projectDocument => projectDocument.ProjectId);
        }
    }
}
