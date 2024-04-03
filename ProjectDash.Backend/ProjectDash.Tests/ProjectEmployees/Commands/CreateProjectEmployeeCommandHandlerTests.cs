using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.ProjectEmployees.Commands.CreateProjectEmployee;
using ProjectDash.Tests.Common;

namespace ProjectDash.Tests.ProjectEmployees.Commands
{
    public class CreateProjectEmployeeCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateProjectEmployeeCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateProjectEmployeeCommandHandler(Context);

            //Act
            await handler.Handle(
                new CreateProjectEmployeeCommand
                {
                    ProjectId = ProjectDashContextFactory.ProjectIdForPECreate,
                    EmployeeId = ProjectDashContextFactory.EmployeeIdForPECreate
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.ProjectEmployees.SingleOrDefaultAsync(pe =>
                pe.ProjectId == ProjectDashContextFactory.ProjectIdForPECreate &&
                pe.EmployeeId == ProjectDashContextFactory.EmployeeIdForPECreate));
        }

        [Fact]
        public async Task CreateProjectEmployeeCommandHandler_FailOnWrongProjectId()
        {
            //Arrange
            var handler = new CreateProjectEmployeeCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new CreateProjectEmployeeCommand
                    {
                        ProjectId = Guid.NewGuid(),
                        EmployeeId = ProjectDashContextFactory.EmployeeIdForPECreate
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task CreateProjectEmployeeCommandHandler_FailOnWrongEmployeeId()
        {
            //Arrange
            var handler = new CreateProjectEmployeeCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new CreateProjectEmployeeCommand
                    {
                        ProjectId = ProjectDashContextFactory.ProjectIdForPECreate,
                        EmployeeId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
