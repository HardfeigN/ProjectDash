using MediatR;

namespace ProjectDash.Application.ProjectEmployees.Commands.CreateProjectEmployee
{
    public class CreateProjectEmployeeCommand : IRequest
    {
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
