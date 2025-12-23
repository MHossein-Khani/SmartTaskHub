using MediatR;

namespace SmartTaskHub.Application.Features.TaskItems.Commands.CreateTaskItem
{
    public class CreateTaskItemCommand : IRequest<int>
    {
        public string Title { get; init; } = string.Empty;
        public string? Description { get; init; }
        public int ProjectId { get; init; }
        public int? AssignedUserId { get; init; }
    }
}
