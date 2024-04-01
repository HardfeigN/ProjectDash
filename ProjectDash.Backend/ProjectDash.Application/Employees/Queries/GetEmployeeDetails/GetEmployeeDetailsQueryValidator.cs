using FluentValidation;

namespace ProjectDash.Application.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQueryValidator : AbstractValidator<GetEmployeeDetailsQuery>
    {
        public GetEmployeeDetailsQueryValidator() 
        {
            RuleFor(getEmployeeCommand =>
                getEmployeeCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
