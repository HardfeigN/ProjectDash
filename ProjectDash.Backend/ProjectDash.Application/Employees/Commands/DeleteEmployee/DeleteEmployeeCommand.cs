using MediatR;

namespace ProjectDash.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
