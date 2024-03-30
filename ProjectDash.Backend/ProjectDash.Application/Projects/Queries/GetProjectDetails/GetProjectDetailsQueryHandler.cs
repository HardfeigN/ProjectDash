using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQuery, ProjectDetailsVm>
    {
        private readonly IProjectDashDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProjectDetailsQueryHandler(IProjectDashDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProjectDetailsVm> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Projects
                .FirstOrDefaultAsync(project =>
                    project.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            return _mapper.Map<ProjectDetailsVm>(entity);
        }
    }
}
