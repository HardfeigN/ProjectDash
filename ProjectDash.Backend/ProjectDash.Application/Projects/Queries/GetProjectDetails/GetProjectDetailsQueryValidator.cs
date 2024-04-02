using FluentValidation;

namespace ProjectDash.Application.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQueryValidator : AbstractValidator<GetProjectDetailsQuery>
    {
        public GetProjectDetailsQueryValidator() 
        {
            RuleFor(project => project.Id).NotEqual(Guid.Empty);
        }
    }
}
