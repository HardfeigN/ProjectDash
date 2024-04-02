using FluentValidation;

namespace ProjectDash.Application.ProjectEmployees.Commands.DeleteProjectEmployee
{
    public class DeleteProjectEmployeeCommandValidator : AbstractValidator<DeleteProjectEmployeeCommand>
    {
        public DeleteProjectEmployeeCommandValidator()
        {
            RuleFor(deleteProjectEmployeeCommand =>
                deleteProjectEmployeeCommand.ProjectId).NotEqual(Guid.Empty);
            RuleFor(deleteProjectEmployeeCommand =>
                deleteProjectEmployeeCommand.EmployeeId).NotEqual(Guid.Empty);
        }
    }
}
