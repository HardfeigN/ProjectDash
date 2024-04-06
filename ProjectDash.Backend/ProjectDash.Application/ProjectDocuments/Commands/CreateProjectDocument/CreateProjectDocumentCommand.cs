using MediatR;

namespace ProjectDash.Application.ProjectDocuments.Commands.CreateProjectDocument
{
    public class CreateProjectDocumentCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid ProjectId { get; set; }
        public string Extension { get; set; }
    }
}
