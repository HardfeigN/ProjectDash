using MediatR;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IProjectDashDbContext _dbContext;
        public DeleteProjectCommandHandler(IProjectDashDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Projects
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            _dbContext.Projects.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
