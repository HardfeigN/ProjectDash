using FluentValidation;

namespace ProjectDash.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator() 
        {
            RuleFor(deleteEmployeeCommand =>
                deleteEmployeeCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
