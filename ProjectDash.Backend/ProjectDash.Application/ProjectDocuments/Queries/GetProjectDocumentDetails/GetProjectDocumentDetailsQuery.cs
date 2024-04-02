using MediatR;

namespace ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentDetails
{
    public class GetProjectDocumentDetailsQuery : IRequest<ProjectDocumentDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
