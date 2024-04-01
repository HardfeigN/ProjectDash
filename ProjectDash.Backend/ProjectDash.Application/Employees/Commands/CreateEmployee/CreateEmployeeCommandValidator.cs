using FluentValidation;

namespace ProjectDash.Application.Employees.Commands.CreateEmployee
{
    public  class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator() 
        {
            RuleFor(createEmployeeCommand =>
                createEmployeeCommand.Name).NotEmpty().MaximumLength(30);
            RuleFor(createEmployeeCommand =>
                createEmployeeCommand.Surname).NotEmpty().MaximumLength(30);
            RuleFor(createEmployeeCommand =>
                createEmployeeCommand.Patronymic).NotEmpty().MaximumLength(30);
            RuleFor(createEmployeeCommand =>
                createEmployeeCommand.Email).NotEmpty().MaximumLength(50);
        }
    }
}
