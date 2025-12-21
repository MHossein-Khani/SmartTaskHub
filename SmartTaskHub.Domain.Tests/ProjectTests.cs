using SmartTaskHub.Domain.Entities;

namespace SmartTaskHub.Domain.Tests
{
    public class ProjectTests
    {
        [Fact]
        public void Create_Should_ReturnProject_When_Name_Is_Valid()
        {
            //Arrange
            string name = "My First Project";
            int ownerId = 1;

            //Act
            var project = new Project(name, ownerId);

            //Assert
            Assert.NotNull(project);
            Assert.Equal(name, project.Name);
        }

        [Fact]
        public void Create_Should_ThrowException_When_Name_Is_Empty()
        {
            //Arrange
            string name = string.Empty;
            int ownerId = 1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Project(name, ownerId));
        }

        [Fact]
        public void UpdateName_Should_Updates_Name_When_Name_Is_Valid()
        {
            // Arrange
            string newName = "new name";
            var project = new Project("name", 1);

            // Act
            project.UpdateName(newName);

            // Assert
            Assert.Equal(newName, project.Name);
        }

        [Fact]
        public void UpdateName_Should_ThrowException_When_Name_Is_Empty()
        {
            //Arrange
            var Project = new Project("dummy project name", 1);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => Project.UpdateName(string.Empty));
        }
    }
}
