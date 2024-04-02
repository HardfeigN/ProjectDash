using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Projects.Commands.CreateProject;
using ProjectDash.Tests.Common;

namespace ProjectDash.Tests.Projects.Commands
{
    public class CreateProjectCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateProjectCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateProjectCommandHandler(Context);
            var name = "project name";
            var performer = "performer";
            var customer = "customer";
            var priority = 12;

            //Act
            var projId = await handler.Handle(
                new CreateProjectCommand
                {
                    Name = name,
                    Performer = performer,
                    Customer = customer,
                    Priority = priority,
                    ProjectLeaderId = ProjectDashContextFactory.ProjectLeaderIdForCreate
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.Projects.SingleOrDefaultAsync(proj =>
                proj.Id == projId &&
                proj.Name == name &&
                proj.Performer == performer &&
                proj.Customer == customer &&
                proj.CreationDate == DateTime.Today &&
                proj.Priority == priority &&
                proj.ProjectLeaderId == ProjectDashContextFactory.ProjectLeaderIdForCreate));
        }
    }
}
