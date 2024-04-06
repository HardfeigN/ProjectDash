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
            if (request.ProjectLeaderId != Guid.Empty)
            {
                var projectLeader = await _dbContext.Employees
                .FirstOrDefaultAsync(employee =>
                    employee.Id == request.ProjectLeaderId, cancellationToken);
                if (projectLeader == null)
                {
                    throw new NotFoundException(nameof(Employee), request.ProjectLeaderId);
                }
                var newProjectLeader = await _dbContext.ProjectEmployee
                    .FindAsync(new object[] { request.ProjectLeaderId, request.Id }, cancellationToken);
                if (newProjectLeader == null)
                {
                    newProjectLeader = new ProjectEmployee
                    {
                        ProjectId = request.Id,
                        EmployeeId = request.ProjectLeaderId
                    };
                    var oldProjectLeader = new ProjectEmployee
                    {
                        ProjectId = entity.Id,
                        EmployeeId = entity.ProjectLeaderId
                    };

                    _dbContext.ProjectEmployee.Remove(oldProjectLeader);
                    await _dbContext.ProjectEmployee.AddAsync(newProjectLeader, cancellationToken);
                }

                entity.ProjectLeaderId = request.ProjectLeaderId;
            }
            if (request.StartDate != default)
            {
                entity.StartDate = request.StartDate;
            }
            if (request.EndDate != default)
            {
                entity.EndDate = request.EndDate;
            }
            if (entity.StartDate > entity.EndDate)
            {
                throw new ArgumentException("The Start Project Date cannot be greater than End Project Date.");
            }

            entity.Name = request.Name ?? entity.Name;
            entity.Performer = request.Performer ?? entity.Performer;
            entity.Customer = request.Customer ?? entity.Customer;
            if (request.Priority != default)
            {
                entity.Priority = request.Priority;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
