using MediatR;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain.Interfaces;
using ProjectDash.Domain;

namespace ProjectDash.Application.ProjectDocuments.Commands.CreateProjectDocument
{
    public class CreateProjectDocumentCommandHandler : IRequestHandler<CreateProjectDocumentCommand, Guid>
    {
        private readonly IProjectDashDbContext _dbContext;
        public CreateProjectDocumentCommandHandler(IProjectDashDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateProjectDocumentCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects
                .FindAsync(request.ProjectId);

            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.ProjectId);
            }

            var projectDocument = new ProjectDocument
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ProjectId = request.ProjectId,
                Extension = request.Extension
            };

            await _dbContext.ProjectDocument.AddAsync(projectDocument, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return projectDocument.Id;
        }
    }
}
