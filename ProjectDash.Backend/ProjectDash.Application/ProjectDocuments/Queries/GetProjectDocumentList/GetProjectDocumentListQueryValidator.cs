using FluentValidation;

namespace ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentList
{
    public class GetProjectDocumentListQueryValidator : AbstractValidator<GetProjectDocumentListQuery>
    {
        public GetProjectDocumentListQueryValidator()
        {
            RuleFor(projectDocument => projectDocument.ProjectId).NotEqual(Guid.Empty);
            RuleFor(projectDocument => projectDocument.Name).NotEmpty().MaximumLength(80);
        }
    }
}
