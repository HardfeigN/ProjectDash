using MediatR;

namespace ProjectDash.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQuery : IRequest<ProjectListVm>
    {
        public string Name { get; set; }
        public string Performer { get; set; }
        public string Customer { get; set; }
        public DateTime CreationDateStart { get; set; }
        public DateTime CreationDateEnd { get; set; }
        public DateTime CompletionDateStart { get; set; }
        public DateTime CompletionDateEnd { get; set; }
        public int Priority { get; set; }
        public Guid ProjectLeaderId { get; set; }
    }
}
