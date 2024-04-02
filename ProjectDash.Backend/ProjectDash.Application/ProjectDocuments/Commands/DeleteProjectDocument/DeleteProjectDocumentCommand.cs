using MediatR;

namespace ProjectDash.Application.ProjectDocuments.Commands.DeleteProjectDocument
{
    public class DeleteProjectDocumentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
