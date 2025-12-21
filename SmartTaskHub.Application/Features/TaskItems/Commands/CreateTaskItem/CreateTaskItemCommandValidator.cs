using FluentValidation;

namespace SmartTaskHub.Application.Features.TaskItems.Commands.CreateTaskItem
{
    public class CreateTaskItemCommandValidator :
        AbstractValidator<CreateTaskItemCommand>
    {
        public CreateTaskItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .NotEmpty()
                .WithMessage("TaskItemTitleIsRequired");

            RuleFor(v => v.Title)
                .MaximumLength(100)
                .WithMessage("TitleCannotExceed100Character");

            RuleFor(v => v.Description)
                .MaximumLength(500)
                .WithMessage("DescriptionCannotExceed500Character");

            RuleFor(v => v.ProjectId)
                .GreaterThan(0)
                .WithMessage("InvalidProjectId");
        }
    }
}
