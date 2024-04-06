using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.ProjectEmployees.Commands.DeleteProjectEmployee;
using ProjectDash.Tests.Common;
namespace ProjectDash.Tests.ProjectEmployees.Commands
{
    public class DeleteProjectEmployeeCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteProjectEmployeeCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteProjectEmployeeCommandHandler(Context);

            //Act
            await handler.Handle(new DeleteProjectEmployeeCommand
            {
                ProjectId = ProjectDashContextFactory.ProjectIdForPEDelete,
                EmployeeId = ProjectDashContextFactory.EmployeeIdForPEDelete
            },
            CancellationToken.None);

            //Assert
            Assert.Null(Context.ProjectEmployee.SingleOrDefault(pe =>
                pe.ProjectId == ProjectDashContextFactory.ProjectIdForPEDelete &&
                pe.EmployeeId == ProjectDashContextFactory.EmployeeIdForPEDelete));
        }

        [Fact]
        public async Task DeleteProjectEmployeeCommandHandler_FailOnWrongIds()
        {
            //Arrange
            var handler = new DeleteProjectEmployeeCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteProjectEmployeeCommand
                    {
                        ProjectId = Guid.NewGuid(),
                        EmployeeId = ProjectDashContextFactory.EmployeeIdForPEDelete
                    },
                    CancellationToken.None));
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteProjectEmployeeCommand
                    {
                        ProjectId = ProjectDashContextFactory.EmployeeIdForPEDelete,
                        EmployeeId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
