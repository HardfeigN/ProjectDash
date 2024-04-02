using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain.Interfaces;
using ProjectDash.Domain;
using MediatR;

namespace ProjectDash.Application.ProjectDocuments.Commands.DeleteProjectDocument
{
    public class DeleteProjectDocumentCommandHandler : IRequestHandler<DeleteProjectDocumentCommand>
    {
        private readonly IProjectDashDbContext _dbContext;
        public DeleteProjectDocumentCommandHandler(IProjectDashDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteProjectDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProjectDocuments
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(ProjectDocument), request.Id);
            }

            _dbContext.ProjectDocuments.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
