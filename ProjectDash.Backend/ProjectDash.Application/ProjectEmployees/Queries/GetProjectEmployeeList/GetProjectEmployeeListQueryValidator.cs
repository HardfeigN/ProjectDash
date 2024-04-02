using FluentValidation;

namespace ProjectDash.Application.ProjectEmployees.Queries.GetProjectEmployeeList
{
    public class GetProjectEmployeeListQueryValidator : AbstractValidator<GetProjectEmployeeListQuery>
    {
        public GetProjectEmployeeListQueryValidator() 
        {
            RuleFor(projectEmployee => projectEmployee.EmployeeId).NotEqual(Guid.Empty);
            RuleFor(projectEmployee => projectEmployee.ProjectId).NotEqual(Guid.Empty);
        }
    }
}
