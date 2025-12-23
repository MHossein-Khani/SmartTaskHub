using SmartTaskHub.Domain.Entities;

namespace SmartTaskHub.Domain.Tests
{
    public class TaskItemTests
    {
        [Fact]
        public void Create_Sould_ReturnTaskItem_When_Title_Is_Valid()
        {
            // Arrange
            string title = "dummy title";
            int projectId = 1;

            var project = new Project("dummy name", projectId);

            // Act
            var taskItem = new TaskItem(title, projectId);

            // Assert
            Assert.NotNull(taskItem);
            Assert.Equal(title, taskItem.Title);
        }

        [Fact]
        public void Create_Should_ThrowException_When_Title_Is_Empty()
        {
            Assert.Throws<ArgumentException>(
                () => new TaskItem(string.Empty, 1));
        }

        [Fact]
        public void UpdateTitle_Should_Updates_Title_When_Title_Is_Valid()
        {
            // Arrange
            string newTitle = "new title";
            var taskItem = new TaskItem("title", 1);

            // Act
            taskItem.UpdateTitle(newTitle);

            // Assert
            Assert.Equal(newTitle, taskItem.Title);
        }

        [Fact]
        public void Update_Should_ThrowException_When_Title_Is_Empty()
        {
            Assert.Throws<ArgumentException>(
                () => new TaskItem("dummy title", 1).UpdateTitle(string.Empty));
        }
    }
}
