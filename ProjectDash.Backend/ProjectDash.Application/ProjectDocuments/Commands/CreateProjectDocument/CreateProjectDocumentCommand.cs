using MediatR;
using ProjectDash.Domain;

namespace ProjectDash.Application.ProjectDocuments.Commands.CreateProjectDocument
{
    public class CreateProjectDocumentCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}
