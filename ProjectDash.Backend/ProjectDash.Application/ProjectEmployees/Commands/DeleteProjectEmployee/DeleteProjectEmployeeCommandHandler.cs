using MediatR;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.ProjectEmployees.Commands.DeleteProjectEmployee
{
    public class DeleteProjectEmployeeCommandHandler : IRequestHandler<DeleteProjectEmployeeCommand>
    {
        private readonly IProjectDashDbContext _dbContext;
        public DeleteProjectEmployeeCommandHandler(IProjectDashDbContext dbContext) =>
            _dbContext = dbContext;


        public async Task Handle(DeleteProjectEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProjectEmployee
                .FindAsync(new object[] { request.EmployeeId, request.ProjectId }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(ProjectEmployee), new object[] { request.EmployeeId, request.ProjectId });
            }
            var project = await _dbContext.Projects
                .FindAsync(new object[] { request.ProjectId }, cancellationToken);
            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.ProjectId );
            }
            if (project.ProjectLeaderId == request.EmployeeId)
            {
                throw new Exception("Cannot remove a project leader from a team.");
            }
            _dbContext.ProjectEmployee.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
