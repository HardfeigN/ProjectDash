using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, ProjectListVm>
    {
        private readonly IProjectDashDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProjectListQueryHandler(IProjectDashDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProjectListVm> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateBuilder.New<Project>(true);
            if(!string.IsNullOrEmpty(request.Name))
                predicate = predicate.And(project =>
                    EF.Functions.Like(project.Name.ToLower(), $"%{request.Name.ToLower()}%"));
            if (!string.IsNullOrEmpty(request.Performer))
                predicate = predicate.And(project =>
                    EF.Functions.Like(project.Performer.ToLower(), $"%{request.Performer.ToLower()}%"));
            if (!string.IsNullOrEmpty(request.Customer))
                predicate = predicate.And(project =>
                    EF.Functions.Like(project.Customer.ToLower(), $"%{request.Customer.ToLower()}%"));
            if (request.StartDateLeft != default && request.StartDateRight != default)
                predicate = predicate.And(project =>
                    project.StartDate >= request.StartDateLeft && 
                    project.StartDate <= request.StartDateRight);
            if (request.EndDateLeft != default && request.EndDateRight != default)
                predicate = predicate.And(project => 
                    project.EndDate >= request.EndDateLeft && 
                    project.EndDate <= request.EndDateRight);
            if (request.Priority != default)
                predicate = predicate.And(project => 
                    project.Priority == request.Priority);
            if (request.ProjectLeaderId != default)
            {
                var employee = await _dbContext.Employees
                    .FirstOrDefaultAsync(project =>
                        project.Id == request.ProjectLeaderId, cancellationToken);
                if (employee == null)
                {
                    throw new NotFoundException(nameof(Employee), request.EmployeeId);
                }
                predicate = predicate.And(project => 
                    project.ProjectLeaderId == request.ProjectLeaderId);
            }
            if (request.EmployeeId != default)
            {
                var employee = await _dbContext.Employees
                    .FirstOrDefaultAsync(project =>
                        project.Id == request.EmployeeId, cancellationToken);
                if (employee == null)
                {
                    throw new NotFoundException(nameof(Employee), request.EmployeeId);
                }
                predicate = predicate.And(project => 
                    project.Employees.Any(projectEmployees => projectEmployees.EmployeeId == request.EmployeeId));
            }

            var projectQuery = await _dbContext.Projects
                .Where(predicate)
                .ProjectTo<ProjectLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProjectListVm { Projects = projectQuery };
        }
    }
}
