using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartTaskHub.Application.Features.Projetcs.Commands.CreateProject;

namespace SmartTaskHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ISender _mediator;

        public ProjectController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
