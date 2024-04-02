using FluentValidation;

namespace ProjectDash.Application.ProjectEmployees.Commands.CreateProjectEmployee
{
    public class CreateProjectEmployeeCommandValidator : AbstractValidator<CreateProjectEmployeeCommand>
    {
        public CreateProjectEmployeeCommandValidator() 
        {
            RuleFor(createProjectEmployeeCommand =>
                createProjectEmployeeCommand.ProjectId).NotEqual(Guid.Empty);
            RuleFor(createProjectEmployeeCommand =>
                createProjectEmployeeCommand.EmployeeId).NotEqual(Guid.Empty);
        }
    }
}
