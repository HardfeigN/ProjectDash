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
            var entity = await _dbContext.ProjectEmployees
                .FindAsync(new ProjectEmployee { ProjectId = request.ProjectId, EmployeeId = request.EmployeeId }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(ProjectEmployee), new object[] { request.ProjectId, request.EmployeeId });
            }

            _dbContext.ProjectEmployees.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
