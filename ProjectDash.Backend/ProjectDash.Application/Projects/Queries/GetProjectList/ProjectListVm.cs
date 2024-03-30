using MediatR;

namespace ProjectDash.Application.Projects.Queries.GetProjectList
{
    public class ProjectListVm : IRequest
    {
        public IList<ProjectLookupDto> Projects { get; set; }
    }
}
