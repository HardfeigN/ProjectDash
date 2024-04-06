using FluentValidation;

namespace ProjectDash.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQueryValidator : AbstractValidator<GetProjectListQuery>
    {
        public GetProjectListQueryValidator() 
        {
            RuleFor(project => project.Name).NotEmpty().MaximumLength(50);
            RuleFor(project => project.Performer).NotEmpty().MaximumLength(80);
            RuleFor(project => project.Customer).NotEmpty().MaximumLength(80);
            RuleFor(project => project.StartDateLeft).NotEqual(default(DateOnly));
            RuleFor(project => project.StartDateRight).NotEqual(default(DateOnly));
            RuleFor(project => project.EndDateLeft).NotEqual(default(DateOnly));
            RuleFor(project => project.EndDateRight).NotEqual(default(DateOnly));
            RuleFor(project => project.Priority).NotEqual(default(int));
            RuleFor(project => project.ProjectLeaderId).NotEqual(Guid.Empty);
            RuleFor(project => project.EmployeeId).NotEqual(Guid.Empty);
        }
    }
}
