using System.Collections.ObjectModel;

namespace SmartTaskHub.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public int OwnerId { get; private set; }
        public User? Owner { get; private set; }

        private readonly List<TaskItem> _tasks = new();
        public IReadOnlyCollection<TaskItem> Tasks => _tasks.AsReadOnly();


        protected Project() { }

        public Project(string name, int ownerId, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Project name cannot be empty");

            Name = name;
            OwnerId = ownerId;
            Description = description;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Project name cannot be empty");

            Name = newName;
        }
    }
}
