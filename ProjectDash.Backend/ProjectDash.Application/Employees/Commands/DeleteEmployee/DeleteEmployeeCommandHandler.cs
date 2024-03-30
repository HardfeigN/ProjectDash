using MediatR;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IProjectDashDbContext _dbContext;
        public DeleteEmployeeCommandHandler(IProjectDashDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            _dbContext.Employees.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
