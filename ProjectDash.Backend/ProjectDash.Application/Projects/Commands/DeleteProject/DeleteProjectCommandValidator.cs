using FluentValidation;

namespace ProjectDash.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator() 
        {
            RuleFor(deleteProjectCommand =>
                deleteProjectCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
