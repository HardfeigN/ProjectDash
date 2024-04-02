using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.Projects.Commands.UpdateProject;
using ProjectDash.Tests.Common;

namespace ProjectDash.Tests.Projects.Commands
{
    public class UpdateProjectCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateProjectCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdateProjectCommandHandler(Context);
            var updateName = "NewName";
            var updatePerformer = "newPerformer";
            var updateCustomer = "newCustomer";
            var updateComplationDate = DateTime.Today;
            var updatePriority = 77;

            //Act
            await handler.Handle(new UpdateProjectCommand
            {
                Id = ProjectDashContextFactory.ProjectIdForUpdate,
                Name = updateName,
                Performer = updatePerformer,
                Customer = updateCustomer,
                CompletionDate = updateComplationDate,
                Priority = updatePriority,
                ProjectLeaderId = ProjectDashContextFactory.ProjectLeaderIdForUpdate
            },
            CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.Projects.SingleOrDefaultAsync(proj =>
                proj.Id == ProjectDashContextFactory.ProjectIdForUpdate &&
                proj.Name == updateName &&
                proj.Performer == updatePerformer &&
                proj.Customer == updateCustomer &&
                proj.CompletionDate == updateComplationDate &&
                proj.Priority == updatePriority &&
                proj.ProjectLeaderId == ProjectDashContextFactory.ProjectLeaderIdForUpdate));
        }

        [Fact]
        public async Task UpdateProjectCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateProjectCommandHandler(Context);


            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateProjectCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateProjectCommandHandler_FailOnWrongProjectLeaderId()
        {
            //Arrange
            var handler = new UpdateProjectCommandHandler(Context);


            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateProjectCommand
                    {
                        ProjectLeaderId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }

    }
}
