using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.ProjectEmployees.Queries.GetProjectEmployeeList
{
    public class GetProjectEmployeeListQueryHandler : IRequestHandler<GetProjectEmployeeListQuery, ProjectEmployeeListVm>
    {
        private readonly IProjectDashDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProjectEmployeeListQueryHandler(IProjectDashDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProjectEmployeeListVm> Handle(GetProjectEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateBuilder.New<ProjectEmployee>(true);

            if (request.ProjectId != Guid.Empty)
            {
                var project = await _dbContext.Projects
                .FirstOrDefaultAsync(project =>
                    project.Id == request.ProjectId, cancellationToken);
                    if (project == null)
                    {
                        throw new NotFoundException(nameof(Project), request.ProjectId);
                    }
                predicate = predicate.And(projectEmployee =>
                    projectEmployee.ProjectId == request.ProjectId);
            }

            if (request.EmployeeId != Guid.Empty)
            {
                var employee = await _dbContext.Employees
                    .FirstOrDefaultAsync(employee =>
                        employee.Id == request.EmployeeId, cancellationToken);
                if (employee == null)
                {
                    throw new NotFoundException(nameof(Employee), request.EmployeeId);
                }
                predicate = predicate.And(projectEmployee =>
                    projectEmployee.EmployeeId == request.EmployeeId);
            }

            var projectEmployeesQuery = await _dbContext.ProjectEmployee
                .Where(predicate)
                .Include(projectEmployee => projectEmployee.Employee)
                .Include(projectEmployee => projectEmployee.Project)
                .ProjectTo<ProjectEmployeeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProjectEmployeeListVm { ProjectEmployees = projectEmployeesQuery };
        }
    }
}
