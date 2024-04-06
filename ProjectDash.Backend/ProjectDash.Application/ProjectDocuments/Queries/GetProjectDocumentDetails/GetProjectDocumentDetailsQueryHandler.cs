using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentDetails
{
    public class GetProjectDocumentDetailsQueryHandler : IRequestHandler<GetProjectDocumentDetailsQuery, ProjectDocumentDetailsVm>
    {
        private readonly IProjectDashDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProjectDocumentDetailsQueryHandler(IProjectDashDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProjectDocumentDetailsVm> Handle(GetProjectDocumentDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProjectDocument
                .FirstOrDefaultAsync(projectDocument =>
                    projectDocument.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProjectDocument), request.Id);
            }

            return _mapper.Map<ProjectDocumentDetailsVm>(entity);
        }
    }
}
