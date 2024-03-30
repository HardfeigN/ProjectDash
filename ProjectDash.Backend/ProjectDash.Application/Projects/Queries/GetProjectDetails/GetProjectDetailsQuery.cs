using MediatR;

namespace ProjectDash.Application.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQuery : IRequest<ProjectDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
