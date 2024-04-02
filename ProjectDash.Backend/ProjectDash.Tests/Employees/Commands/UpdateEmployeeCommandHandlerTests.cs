using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.Employees.Commands.UpdateEmployee;
using ProjectDash.Tests.Common;

namespace ProjectDash.Tests.Employees.Commands
{
    public class UpdateEmployeeCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateEmployeeCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdateEmployeeCommandHandler(Context);
            var updateName = "NewName";

            //Act
            await handler.Handle(new UpdateEmployeeCommand
            {
                Id = ProjectDashContextFactory.EmployeeIdForUpdate,
                Name = updateName
            },
            CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.Employees.SingleOrDefaultAsync(employee =>
                employee.Id == ProjectDashContextFactory.EmployeeIdForUpdate &&
                employee.Name == updateName));
        }

        [Fact]
        public async Task UpdateEmployeeCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateEmployeeCommandHandler(Context);


            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateEmployeeCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
