using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IProjectDashDbContext _dbContext;
        public UpdateEmployeeCommandHandler(IProjectDashDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees
                .FirstOrDefaultAsync(employee =>
                    employee.Id == request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            entity.Name = request.Name;
            entity.Surname = request.Surname;
            entity.Patronymic = request.Patronymic;
            entity.Email = request.Email;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
