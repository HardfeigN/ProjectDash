using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
                predicate = predicate.Or(project => 
                    project.Name.Contains(request.Name));
            if (!string.IsNullOrEmpty(request.Performer))
                predicate = predicate.Or(project => 
                    project.Performer.Contains(request.Performer));
            if (!string.IsNullOrEmpty(request.Customer))
                predicate = predicate.Or(project => 
                    project.Customer.Contains(request.Customer));
            if (request.CreationDateStart != default && request.CreationDateEnd != default)
                predicate = predicate.Or(project =>
                    project.CreationDate >= request.CreationDateStart && 
                    project.CreationDate <= request.CreationDateEnd);
            if (request.CompletionDateStart != default && request.CompletionDateEnd != default)
                predicate = predicate.Or(project => 
                    project.CompletionDate >= request.CompletionDateStart && 
                    project.CompletionDate <= request.CompletionDateEnd);
            if (request.Priority != default)
                predicate = predicate.Or(project => 
                    project.Priority == request.Priority);
            if (request.ProjectLeaderId != default)
                predicate = predicate.Or(project => 
                    project.ProjectLeaderId == request.ProjectLeaderId);

            var projectQuery = await _dbContext.Projects
                .Where(predicate)
                .ProjectTo<ProjectLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProjectListVm { Projects = projectQuery };
        }
    }
}
