using MediatR;
using ProjectDash.Domain;

namespace ProjectDash.Application.ProjectDocuments.Commands.DeleteProjectDocument
{
    public class DeleteProjectDocumentCommand : IRequest<ProjectDocument>
    {
        public Guid Id { get; set; }
    }
}
