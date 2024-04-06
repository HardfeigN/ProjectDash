using FluentValidation;

namespace ProjectDash.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator() 
        {
            RuleFor(createProjectCommand =>
                createProjectCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(createProjectCommand =>
                createProjectCommand.Performer).NotEmpty().MaximumLength(80);
            RuleFor(createProjectCommand =>
                createProjectCommand.Customer).NotEmpty().MaximumLength(80);
            RuleFor(createProjectCommand =>
                createProjectCommand.Priority).NotEqual(default(int));
            RuleFor(createProjectCommand =>
                createProjectCommand.ProjectLeaderId).NotEqual(Guid.Empty);
        }
    }
}
