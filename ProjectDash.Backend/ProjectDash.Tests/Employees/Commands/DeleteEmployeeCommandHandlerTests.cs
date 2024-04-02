using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.Employees.Commands.DeleteEmployee;
using ProjectDash.Tests.Common;

namespace ProjectDash.Tests.Employees.Commands
{
    public  class DeleteEmployeeCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteEmployeeCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteEmployeeCommandHandler(Context);

            //Act
            await handler.Handle(new DeleteEmployeeCommand
            {
                Id = ProjectDashContextFactory.EmployeeIdForDelete
            },
            CancellationToken.None);

            //Assert
            Assert.Null(Context.Employees.SingleOrDefault(employee =>
                employee.Id == ProjectDashContextFactory.EmployeeIdForDelete));
        }

        [Fact]
        public async Task DeleteEmployeeCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteEmployeeCommandHandler(Context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteEmployeeCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
