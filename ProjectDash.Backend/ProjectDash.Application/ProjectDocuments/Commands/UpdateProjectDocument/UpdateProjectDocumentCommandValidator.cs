using FluentValidation;

namespace ProjectDash.Application.ProjectDocuments.Commands.UpdateProjectDocument
{
    public class UpdateProjectDocumentCommandValidator : AbstractValidator<UpdateProjectDocumentCommand>
    {
        public UpdateProjectDocumentCommandValidator() 
        {
            RuleFor(updateProjectDocumentCommand =>
               updateProjectDocumentCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateProjectDocumentCommand =>
                updateProjectDocumentCommand.Name).NotEmpty().MaximumLength(50);
        }
    }
}
