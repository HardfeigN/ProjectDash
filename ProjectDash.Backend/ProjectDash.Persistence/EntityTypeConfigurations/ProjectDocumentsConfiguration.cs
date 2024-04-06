using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDash.Domain;

namespace ProjectDash.Persistence.EntityTypeConfigurations
{
    public class ProjectDocumentsConfiguration : IEntityTypeConfiguration<ProjectDocument>
    {
        public void Configure(EntityTypeBuilder<ProjectDocument> builder)
        {
            builder.HasKey(projectDocument => projectDocument.Id);
            builder.HasIndex(projectDocument => projectDocument.Id).IsUnique();
            builder.HasOne(projectDocument => projectDocument.Project)
                .WithMany(project => project.ProjectDocuments)
                .HasForeignKey(project => project.ProjectId)
                .OnDelete(DeleteBehavior.Cascade); //if someone is trying to delete the Project, all the ProjectDocuments must be deleted
            builder.Property(projectDocument => projectDocument.Name).HasMaxLength(80).IsRequired();
            builder.Property(projectDocument => projectDocument.Extension).IsRequired();
            builder.Property(projectDocument => projectDocument.ProjectId).IsRequired();
        }
    }
}
