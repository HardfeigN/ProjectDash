using MediatR;

namespace ProjectDash.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQuery : IRequest<ProjectListVm>
    {
        public string? Name { get; set; }
        public string? Performer { get; set; }
        public string? Customer { get; set; }
        public DateOnly? StartDateLeft { get; set; }
        public DateOnly? StartDateRight { get; set; }
        public DateOnly? EndDateLeft { get; set; }
        public DateOnly? EndDateRight { get; set; }
        public int? Priority { get; set; }
        public Guid? ProjectLeaderId { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}
