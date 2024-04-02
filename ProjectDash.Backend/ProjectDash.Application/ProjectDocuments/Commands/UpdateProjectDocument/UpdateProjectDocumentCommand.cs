using MediatR;
using ProjectDash.Domain;

namespace ProjectDash.Application.ProjectDocuments.Commands.UpdateProjectDocument
{
    public class UpdateProjectDocumentCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}
