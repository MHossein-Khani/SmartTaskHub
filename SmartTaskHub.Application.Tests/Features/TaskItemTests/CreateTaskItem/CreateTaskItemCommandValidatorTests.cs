using FluentValidation.TestHelper;
using SmartTaskHub.Application.Features.TaskItems.Commands.CreateTaskItem;

namespace SmartTaskHub.Application.Tests.Features.TaskItemTests.CreateTaskItem
{
    public class CreateTaskItemCommandValidatorTests
    {
        private readonly CreateTaskItemCommandValidator _validator;

        public CreateTaskItemCommandValidatorTests()
        {
            _validator = new CreateTaskItemCommandValidator();
        }

        [Fact]
        public void Should_have_TaskItemTitleIsRequired_error_when_Title_is_empty()
        {
            // Arrange
            var command = new CreateTaskItemCommand
            {
                Title = string.Empty,
                ProjectId = 1
            };

            // Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(v => v.Title)
                .WithErrorMessage("TaskItemTitleIsRequired");
        }

        [Fact]
        public void Should_have_TitleCannotExceed100Character_error_when_Title_exceeds_max_length()
        {
            // Arrange
            var command = new CreateTaskItemCommand
            {
                Title = new string('A', 101),
                ProjectId = 1
            };
            // Act
            var result = _validator.TestValidate(command);
            // Assert
            result.ShouldHaveValidationErrorFor(v => v.Title)
                .WithErrorMessage("TitleCannotExceed100Character");
        }

        [Fact]
        public void Should_have_DescriptionCannotExceed500Character_error_when_Description_exceeds_max_lenght()
        {
            //Arrange
            var command = new CreateTaskItemCommand
            {
                Title = "dummy title",
                Description = new string('D', 501),
                ProjectId = 1
            };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(v => v.Description)
                .WithErrorMessage("DescriptionCannotExceed500Character");
        }

        [Fact]
        public void Should_have_InvalidProjectId_error_when_ProjectId_is_invalid()
        {
            //Arrange
            var command = new CreateTaskItemCommand
            {
                Title = "dummy title",
                ProjectId = 0
            };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(v => v.ProjectId)
                .WithErrorMessage("InvalidProjectId");
        }

        [Fact]
        public void Should_pass_validation_when_all_fields_are_valid()
        {
            //Arrange
            var command = new CreateTaskItemCommand
            {
                Title = "Valid Task Title",
                Description = "Valid Description",
                ProjectId = 1
            };
            //Act
            var result = _validator.TestValidate(command);
            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
