using MediatR;
using SmartTaskHub.Application.Common.Interfaces;
using SmartTaskHub.Domain.Entities;

namespace SmartTaskHub.Application.Features.TaskItems.Commands.CreateTaskItem
{
    public class CreateTaskItemCommandHandler :
        IRequestHandler<CreateTaskItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTaskItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(
            CreateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem(
                request.Title,
                request.ProjectId,
                Domain.Entities.TaskStatus.ToDo,
                request.Description,
                request.AssignedUserId ); 

            _context.TaskItems.Add(taskItem);

            await _context.SaveChangesAsync(cancellationToken);

            return taskItem.Id;
        }
    }
}
