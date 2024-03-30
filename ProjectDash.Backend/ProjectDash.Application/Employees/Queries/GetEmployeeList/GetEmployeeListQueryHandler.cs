using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, EmployeeListVm>
    {
        private readonly IProjectDashDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetEmployeeListQueryHandler(IProjectDashDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EmployeeListVm> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var employeesQuery = await _dbContext.Employees
                .ProjectTo<EmployeeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EmployeeListVm { Employees = employeesQuery };
        }
    }
}
