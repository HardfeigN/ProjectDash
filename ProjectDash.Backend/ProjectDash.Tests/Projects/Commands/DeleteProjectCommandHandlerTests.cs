using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.Projects.Commands.DeleteProject;
using ProjectDash.Tests.Common;

namespace ProjectDash.Tests.Projects.Commands
{
    public class DeleteProjectCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteProjectCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteProjectCommandHandler(Context);

            //Act
            await handler.Handle(new DeleteProjectCommand
            {
                Id = ProjectDashContextFactory.ProjectIdForDelete
            },
            CancellationToken.None);

            //Assert
            Assert.Null(Context.Employees.SingleOrDefault(proj =>
                proj.Id == ProjectDashContextFactory.ProjectIdForDelete));
        }

        [Fact]
        public async Task DeleteProjectCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteProjectCommandHandler(Context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteProjectCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
