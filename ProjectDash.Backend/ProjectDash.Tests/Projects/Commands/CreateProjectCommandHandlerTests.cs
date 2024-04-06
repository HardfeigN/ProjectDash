using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
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
            var startDate = new DateOnly(2023, 05, 28);
            var endDate = new DateOnly(2024, 01, 02);
            var priority = 12;

            //Act
            var projId = await handler.Handle(
                new CreateProjectCommand
                {
                    Name = name,
                    Performer = performer,
                    Customer = customer,
                    StartDate = startDate,
                    EndDate = endDate,
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
                proj.StartDate == startDate &&
                proj.EndDate == endDate &&
                proj.Priority == priority &&
                proj.ProjectLeaderId == ProjectDashContextFactory.ProjectLeaderIdForCreate));
        }

        [Fact]
        public async Task CreateProjectCommandHandler_FailOnWrongProjectLeaderId()
        {
            //Arrange
            var handler = new CreateProjectCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new CreateProjectCommand
                    {
                        ProjectLeaderId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
