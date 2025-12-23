using Microsoft.EntityFrameworkCore;
using SmartTaskHub.Domain.Entities;

namespace SmartTaskHub.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Project> Projects { get; }
        DbSet<TaskItem> TaskItems { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
