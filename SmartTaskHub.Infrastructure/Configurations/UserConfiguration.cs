using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTaskHub.Domain.Entities;

namespace SmartTaskHub.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(200);
        }
    }
}
