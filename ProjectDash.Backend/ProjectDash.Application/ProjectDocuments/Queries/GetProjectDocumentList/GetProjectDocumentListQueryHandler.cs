using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

            var projectDocumentQuery = await _dbContext.ProjectDocuments
                .Where(projectDocument =>
                    projectDocument.ProjectId == request.ProjectId &&
                    EF.Functions.Like(projectDocument.Name, request.Name))
                .ProjectTo<ProjectDocumentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProjectDocumentListVm { ProjectDocuments = projectDocumentQuery };
        }
    }
}
