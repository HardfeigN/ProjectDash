using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
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

            var predicate = PredicateBuilder.New<Employee>(true);

            if (!string.IsNullOrEmpty(request.Name))
                predicate = predicate.And(employee =>
                    EF.Functions.Like(employee.Name, $"%{request.Name}%"));
            if (!string.IsNullOrEmpty(request.Surname))
                predicate = predicate.And(employee =>
                    EF.Functions.Like(employee.Surname, $"%{request.Surname}%"));
            if (!string.IsNullOrEmpty(request.Patronymic))
                predicate = predicate.And(employee =>
                    EF.Functions.Like(employee.Patronymic, $"%{request.Patronymic}%"));
            if (!string.IsNullOrEmpty(request.Email))
                predicate = predicate.And(employee =>
                    EF.Functions.Like(employee.Email, $"%{request.Email}%"));
            if (request.ProjectId != Guid.Empty)
            {
                var project = await _dbContext.Projects
                    .FirstOrDefaultAsync(project =>
                        project.Id == request.ProjectId, cancellationToken);
                if (project == null)
                {
                    throw new NotFoundException(nameof(Project), request.ProjectId);
                }
                predicate = predicate.And(employee =>
                    employee.Projects.Any(projectEmplyees => projectEmplyees.ProjectId == request.ProjectId));
            }

            var employeesQuery = await _dbContext.Employees
                .Where(predicate)
                .ProjectTo<EmployeeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EmployeeListVm { Employees = employeesQuery };
        }
    }
}
