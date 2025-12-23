using FluentValidation;

namespace SmartTaskHub.Application.Features.Projetcs.Commands.CreateProject
{
    public class CreateProjectCommandValidator :
        AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty()
                .WithMessage("ProjectNameIsRequired");

            RuleFor(v => v.Name)
                .MaximumLength(100)
                .WithMessage("NameCannotExceed100Character");

            RuleFor(v => v.OwnerId)
                .GreaterThan(0)
                .WithMessage("OwnerIdIsNotValid");

            RuleFor(v => v.Description)
                .MaximumLength(500)
                .WithMessage("DescriptionCannotExceed500Character");
        }
    }
}
