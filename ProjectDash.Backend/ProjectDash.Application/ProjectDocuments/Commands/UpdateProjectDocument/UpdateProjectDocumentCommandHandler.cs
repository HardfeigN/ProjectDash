using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.ProjectDocuments.Commands.UpdateProjectDocument
{
    public class UpdateProjectDocumentCommandHandler : IRequestHandler<UpdateProjectDocumentCommand>
    {
        private readonly IProjectDashDbContext _dbContext;
        public UpdateProjectDocumentCommandHandler(IProjectDashDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateProjectDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProjectDocuments
                .FirstOrDefaultAsync(projectDocument =>
                    projectDocument.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProjectDocument), request.Id);
            }

            entity.Name = request.Name;
            entity.ProjectId = request.ProjectId;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
