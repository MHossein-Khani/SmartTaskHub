using FluentValidation.TestHelper;
using SmartTaskHub.Application.Features.Projetcs.Commands.CreateProject;

namespace SmartTaskHub.Application.Tests.Features.ProjectTests.CreateProject
{
    public class CreateProjectCommandValidatorTests
    {
        private readonly CreateProjectCommandValidator _validator;

        public CreateProjectCommandValidatorTests()
        {
            _validator = new CreateProjectCommandValidator();
        }

        [Fact]
        public void Should_have_ProjectNameIsRequired_error_when_Name_is_empty()
        {
            // Arrange
            var command = new CreateProjectCommand
            {
                Name = string.Empty,
                OwnerId = 1
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Name)
                .WithErrorMessage("ProjectNameIsRequired");
        }

        [Fact]
        public void Should_have_NameCannotExceed100Character_error_when_Name_exceeds_max_length()
        {
            // Arrange
            var command = new CreateProjectCommand
            {
                Name = new string('A', 101),
                OwnerId = 1
            };
            // Act
            var result = _validator.TestValidate(command);
            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Name)
                .WithErrorMessage("NameCannotExceed100Character");
        }

        [Fact]
        public void Should_have_OwnerIdIsNotValid_error_when_OwnerId_is_empty()
        {
            // Arrange
            var command = new CreateProjectCommand
            {
                Name = "Valid Project Name",
                OwnerId = 0 
            };
            // Act
            var result = _validator.TestValidate(command);
            // Assert
            result.ShouldHaveValidationErrorFor(c => c.OwnerId)
                .WithErrorMessage("OwnerIdIsNotValid");
        }

        [Fact]
        public void Should_have_DescriptionCannotExceed500Character_error_when_Description_exceeds_max_length()
        {
            // Arrange
            var command = new CreateProjectCommand
            {
                Name = "Valid Project Name",
                OwnerId = 1,
                Description = new string('A', 501)
            };
            // Act
            var result = _validator.TestValidate(command);
            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Description)
                .WithErrorMessage("DescriptionCannotExceed500Character");
        }

        [Fact]
        public void Should_pass_validation_when_all_fields_are_valid()
        {
            // Arrange
            var command = new CreateProjectCommand
            {
                Name = "Valid Project Name",
                OwnerId = 1,
                Description = "Valid Description"
            };
            // Act
            var result = _validator.TestValidate(command);
            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
