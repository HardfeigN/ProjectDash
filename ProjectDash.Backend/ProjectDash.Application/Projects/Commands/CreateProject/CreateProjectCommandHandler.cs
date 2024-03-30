using MediatR;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Domain;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectDashDbContext _dbContext;
        public CreateProjectCommandHandler(IProjectDashDbContext dbContext) => 
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var projectLeader = await _dbContext.Employees
                .FindAsync(request.ProjectLeaderId);

            if (projectLeader == null)
            {
                throw new NotFoundException(nameof(Employee), request.ProjectLeaderId);
            }

            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Performer = request.Performer,
                Customer = request.Customer,
                CreationDate = DateTime.Now,
                Priority = request.Priority,
                ProjectLeaderId = request.ProjectLeaderId
            };

            await _dbContext.Projects.AddAsync(project, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return project.Id;
        }
    }
}
