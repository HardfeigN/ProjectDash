using MediatR;

namespace ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentList
{
    public class GetProjectDocumentListQuery : IRequest<ProjectDocumentListVm>
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
    }
}
