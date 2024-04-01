using FluentValidation;

namespace ProjectDash.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator() 
        {
            RuleFor(updateEmployeeCommand =>
                updateEmployeeCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateEmployeeCommand =>
                updateEmployeeCommand.Name).NotEmpty().MaximumLength(30);
            RuleFor(updateEmployeeCommand =>
                updateEmployeeCommand.Surname).NotEmpty().MaximumLength(30);
            RuleFor(updateEmployeeCommand =>
                updateEmployeeCommand.Patronymic).NotEmpty().MaximumLength(30);
            RuleFor(updateEmployeeCommand =>
                updateEmployeeCommand.Email).NotEmpty().MaximumLength(50);
        }
    }
}
