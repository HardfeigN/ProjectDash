using MediatR;

namespace ProjectDash.Application.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQuery : IRequest<EmployeeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
