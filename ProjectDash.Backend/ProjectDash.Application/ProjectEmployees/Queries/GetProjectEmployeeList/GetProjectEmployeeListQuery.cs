using MediatR;

namespace ProjectDash.Application.ProjectEmployees.Queries.GetProjectEmployeeList
{
    public class GetProjectEmployeeListQuery : IRequest<ProjectEmployeeListVm>
    {
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
