namespace SmartTaskHub.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<Project>? Projects { get; set; } 
        public ICollection<TaskItem>? AssignedTasks { get; set; }

        protected User(){}

        public User(string userName, string email, string passwordHash)
        {
            if (userName == null) 
                throw new ArgumentException("UserName cannot be empty");
            if (email == null)
                throw new ArgumentException("Email cannot be empty");

            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
