using FluentValidation;

namespace ProjectDash.Application.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQueryValidator : AbstractValidator<GetEmployeeListQuery>
    {
        public GetEmployeeListQueryValidator() 
        {
            RuleFor(employee => employee.ProjectId).NotEqual(Guid.Empty);
            RuleFor(employee => employee.Name).NotEmpty().MaximumLength(30);
            RuleFor(employee => employee.Surname).NotEmpty().MaximumLength(30);
            RuleFor(employee => employee.Patronymic).NotEmpty().MaximumLength(30);
            RuleFor(employee => employee.Email).NotEmpty().MaximumLength(50);
        }
    }
}
