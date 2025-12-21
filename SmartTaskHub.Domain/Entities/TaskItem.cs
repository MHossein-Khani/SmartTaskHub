namespace SmartTaskHub.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public TaskStatus TaskStatus { get; private set; } = TaskStatus.ToDo;

        public int ProjectId { get; private set; }
        public Project? Project { get; private set; }

        public int? AssignedUserId { get; private set; }
        public User? AssignedUser { get; private set; }

        protected TaskItem(){}

        public TaskItem(string title,
            int projectId,
            TaskStatus? taskStatus = TaskStatus.ToDo,
            string? description = null,
            int? assignedUserId = null)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Task item name cannot be empty");

            Title = title;
            Description = description;
            TaskStatus = taskStatus ?? TaskStatus.ToDo;
            ProjectId = projectId;
            AssignedUserId = assignedUserId;
        }

        public void UpdateTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Task item name cannot be empty");

            Title = newTitle;
        }
    }

    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Done
    }
}
