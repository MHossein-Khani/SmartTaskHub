using MediatR;

namespace SmartTaskHub.Application.Features.Projetcs.Commands.CreateProject
{
    public record CreateProjectCommand : IRequest<int>
    {
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
        public int OwnerId { get; init; }
    }
}
