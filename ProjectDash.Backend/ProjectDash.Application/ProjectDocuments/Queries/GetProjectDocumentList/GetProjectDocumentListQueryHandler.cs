using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentList
{
    public class GetProjectDocumentListQueryHandler : IRequestHandler<GetProjectDocumentListQuery, ProjectDocumentListVm>
    {
        private readonly IProjectDashDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProjectDocumentListQueryHandler(IProjectDashDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProjectDocumentListVm> Handle(GetProjectDocumentListQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateBuilder.New<ProjectDocument>(true);

            if (request.ProjectId != Guid.Empty)
            {
                var project = await _dbContext.Projects
                    .FirstOrDefaultAsync(project =>
                        project.Id == request.ProjectId, cancellationToken);

                if (project == null)
                {
                    throw new NotFoundException(nameof(Project), request.ProjectId);
                }
                predicate = predicate.And(projectDocument => 
                    projectDocument.ProjectId == request.ProjectId);
            }
            if(request.Name != string.Empty)
            {
                predicate = predicate.And(projectDocument =>
                    EF.Functions.Like(projectDocument.Name, $"%{request.Name}%"));
            }

            var projectDocumentQuery = await _dbContext.ProjectDocument
                .Where(predicate)
                .ProjectTo<ProjectDocumentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProjectDocumentListVm { ProjectDocuments = projectDocumentQuery };
        }
    }
}
