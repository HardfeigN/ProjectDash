using MediatR;

namespace ProjectDash.Application.ProjectEmployees.Commands.DeleteProjectEmployee
{
    public class DeleteProjectEmployeeCommand : IRequest
    {
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
