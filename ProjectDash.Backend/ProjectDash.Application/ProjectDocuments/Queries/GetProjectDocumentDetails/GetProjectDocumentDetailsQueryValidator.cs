using FluentValidation;

namespace ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentDetails
{
    public class GetProjectDocumentDetailsQueryValidator : AbstractValidator<GetProjectDocumentDetailsQuery>
    {
        public GetProjectDocumentDetailsQueryValidator() 
        {
            RuleFor(projectDocument => projectDocument.Id).NotEqual(Guid.Empty);
        }
    }
}
