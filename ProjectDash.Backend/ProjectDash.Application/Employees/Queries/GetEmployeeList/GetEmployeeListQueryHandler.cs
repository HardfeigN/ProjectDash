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

            if( request.TextField != string.Empty && request.TextField != null)
            {
                foreach (var word in request.TextField.Split(' ')) 
                {  
                    predicate = predicate.Or(employee =>
                        EF.Functions.Like(employee.Name.ToLower(), $"%{word.ToLower()}%"));
                    predicate = predicate.Or(employee =>
                        EF.Functions.Like(employee.Surname.ToLower(), $"%{word.ToLower()}%"));
                    predicate = predicate.Or(employee =>
                        EF.Functions.Like(employee.Patronymic.ToLower(), $"%{word.ToLower()}%"));
                    predicate = predicate.Or(employee =>
                        EF.Functions.Like(employee.Email.ToLower(), $"%{word.ToLower()}%"));
                }
            } else
            {
                if (!string.IsNullOrEmpty(request.Name))
                    predicate = predicate.And(employee =>
                        EF.Functions.Like(employee.Name.ToLower(), $"%{request.Name.ToLower()}%"));
                if (!string.IsNullOrEmpty(request.Surname))
                    predicate = predicate.And(employee =>
                        EF.Functions.Like(employee.Surname.ToLower(), $"%{request.Surname.ToLower()}%"));
                if (!string.IsNullOrEmpty(request.Patronymic))
                    predicate = predicate.And(employee =>
                        EF.Functions.Like(employee.Patronymic.ToLower(), $"%{request.Patronymic.ToLower()}%"));
                if (!string.IsNullOrEmpty(request.Email))
                    predicate = predicate.And(employee =>
                        EF.Functions.Like(employee.Email.ToLower(), $"%{request.Email.ToLower()}%"));
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
            }

            var employeesQuery = await _dbContext.Employees
                .Where(predicate)
                .ProjectTo<EmployeeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EmployeeListVm { Employees = employeesQuery };
        }
    }
}
