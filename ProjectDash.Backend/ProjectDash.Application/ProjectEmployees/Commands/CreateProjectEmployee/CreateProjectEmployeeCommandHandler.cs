using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.ProjectEmployees.Commands.CreateProjectEmployee
{
    public class CreateProjectEmployeeCommandHandler : IRequestHandler<CreateProjectEmployeeCommand>
    {
        private readonly IProjectDashDbContext _dbContext;
        public CreateProjectEmployeeCommandHandler(IProjectDashDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(CreateProjectEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees
                .FindAsync(request.EmployeeId);
            var project = await _dbContext.Projects
                .FindAsync(request.ProjectId);

            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeId);
            }
            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.ProjectId);
            }

            var projectEmployee = new ProjectEmployee
            {
                ProjectId = request.ProjectId,
                EmployeeId = request.EmployeeId
            };

            await _dbContext.ProjectEmployee.AddAsync(projectEmployee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
