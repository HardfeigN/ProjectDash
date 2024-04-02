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
            RuleFor(project => project.CreationDateStart).NotEqual(default(DateTime));
            RuleFor(project => project.CreationDateEnd).NotEqual(default(DateTime));
            RuleFor(project => project.CompletionDateStart).NotEqual(default(DateTime));
            RuleFor(project => project.CompletionDateEnd).NotEqual(default(DateTime));
            RuleFor(project => project.Priority).NotEqual(default(int));
            RuleFor(project => project.ProjectLeaderId).NotEqual(Guid.Empty);
            RuleFor(project => project.EmployeeId).NotEqual(Guid.Empty);
        }
    }
}
