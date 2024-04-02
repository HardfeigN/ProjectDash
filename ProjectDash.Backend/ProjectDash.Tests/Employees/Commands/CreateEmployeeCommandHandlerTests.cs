using ProjectDash.Tests.Common;
using ProjectDash.Application.Employees.Commands.CreateEmployee;
using Microsoft.EntityFrameworkCore;

namespace ProjectDash.Tests.Employees.Commands
{
    public class CreateEmployeeCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateEmployeeCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateEmployeeCommandHandler(Context);
            var employeeName = "emp name";
            var employeeSurname = "emp Surname";
            var employeePatronymic = "emp Patronymic";
            var employeeEmail = "emp Email";

            //Act
            var empId = await handler.Handle(
                new CreateEmployeeCommand
                {
                    Name = employeeName, 
                    Surname = employeeSurname,
                    Patronymic = employeePatronymic,
                    Email = employeeEmail,
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.Employees.SingleOrDefaultAsync(emp =>
                emp.Id == empId && 
                emp.Name == employeeName &&
                emp.Surname == employeeSurname &&
                emp.Patronymic == employeePatronymic &&
                emp.Email == employeeEmail));
        }
    }
}
