using MediatR;

namespace ProjectDash.Application.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQuery : IRequest<EmployeeListVm>
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
    }
}
