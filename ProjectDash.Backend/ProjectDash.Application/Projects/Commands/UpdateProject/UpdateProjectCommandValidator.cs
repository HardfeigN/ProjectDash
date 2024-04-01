using FluentValidation;

namespace ProjectDash.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator() 
        {
            RuleFor(updateProjectCommand =>
                updateProjectCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateProjectCommand =>
                updateProjectCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(updateProjectCommand =>
                updateProjectCommand.Performer).NotEmpty().MaximumLength(80);
            RuleFor(updateProjectCommand =>
                updateProjectCommand.Customer).NotEmpty().MaximumLength(80);
            RuleFor(updateProjectCommand =>
                updateProjectCommand.CreationDate).NotEqual(default(DateTime));
            RuleFor(updateProjectCommand =>
                updateProjectCommand.Priority).NotEqual(default(int));
            RuleFor(updateProjectCommand =>
                updateProjectCommand.ProjectLeaderId).NotEqual(Guid.Empty);

        }
    }
}
