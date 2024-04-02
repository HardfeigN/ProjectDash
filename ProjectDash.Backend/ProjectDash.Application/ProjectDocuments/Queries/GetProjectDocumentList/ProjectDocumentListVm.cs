using MediatR;

namespace ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentList
{
    public class ProjectDocumentListVm : IRequest
    {
        public IList<ProjectDocumentLookupDto> ProjectDocuments { get; set; }
    }
}
