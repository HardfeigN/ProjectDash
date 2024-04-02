using FluentValidation;

namespace ProjectDash.Application.ProjectDocuments.Commands.CreateProjectDocument
{
    public class CreateprojectDocumentCommandValidator : AbstractValidator<CreateProjectDocumentCommand>
    {
        public CreateprojectDocumentCommandValidator() 
        {
            RuleFor(createProjectDocumentCommand =>
               createProjectDocumentCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(createProjectDocumentCommand =>
                createProjectDocumentCommand.ProjectId).NotEqual(Guid.Empty);
        }
    }
}
