using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectDashDbContext _dbContext;
        public UpdateProjectCommandHandler(IProjectDashDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Projects
                .FirstOrDefaultAsync(project =>
                    project.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            entity.Name = request.Name;
            entity.Performer = request.Performer;
            entity.Customer = request.Customer;
            if (request.CompletionDate != default(DateTime)) 
                entity.CompletionDate = request.CompletionDate;
            entity.ProjectLeaderId = request.ProjectLeaderId;
            entity.Priority = request.Priority;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
