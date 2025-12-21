using MediatR;
using SmartTaskHub.Application.Common.Interfaces;
using SmartTaskHub.Domain.Entities;

namespace SmartTaskHub.Application.Features.Projetcs.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(
            CreateProjectCommand request,
            CancellationToken cancellationToken)
        {
            var project = new Project(request.Name, request.OwnerId, request.Description);

            _context.Projects.Add(project);

            await _context.SaveChangesAsync(cancellationToken);

            return project.Id;
        }
    }
}
