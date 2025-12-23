using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTaskHub.Domain.Entities;

namespace SmartTaskHub.Infrastructure.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired(false).HasMaxLength(500);

            builder.HasOne(p => p.Owner)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.Navigation(nameof(Project.Tasks))
           .HasField("_tasks")
           .UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
