using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsVm>
    {
        private readonly IProjectDashDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetEmployeeDetailsQueryHandler(IProjectDashDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EmployeeDetailsVm> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees
                .FirstOrDefaultAsync(employee =>
                    employee.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            return _mapper.Map<EmployeeDetailsVm>(entity);
        }
    }
}
