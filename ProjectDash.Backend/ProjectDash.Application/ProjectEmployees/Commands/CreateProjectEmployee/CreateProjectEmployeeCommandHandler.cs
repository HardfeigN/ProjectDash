using MediatR;
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

        async Task IRequestHandler<CreateProjectEmployeeCommand>.Handle(CreateProjectEmployeeCommand request, CancellationToken cancellationToken)
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
                EmployeeId = request.EmployeeId,
                ProjectId = request.ProjectId
            };

            await _dbContext.ProjectEmployees.AddAsync(projectEmployee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
