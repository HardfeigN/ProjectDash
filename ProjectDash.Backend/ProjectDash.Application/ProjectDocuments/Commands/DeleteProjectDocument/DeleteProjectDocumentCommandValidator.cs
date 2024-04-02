using FluentValidation;

namespace ProjectDash.Application.ProjectDocuments.Commands.DeleteProjectDocument
{
    public class DeleteProjectDocumentCommandValidator : AbstractValidator<DeleteProjectDocumentCommand>
    {
        public DeleteProjectDocumentCommandValidator() 
        {
            RuleFor(deleteProjectDocumentCommandValidator =>
                deleteProjectDocumentCommandValidator.Id).NotEqual(Guid.Empty);
        }
    }
}
