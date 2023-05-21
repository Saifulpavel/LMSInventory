using Inventory.Application.Features.Racks.Queries.GetAllRacks;
using Inventory.Application.Features.Racks.Queries.GetRackById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Inventory.Application.Features.Racks.Commands.CreateRack;
using Inventory.Application.Features.Racks.Commands.UpdateRack;
using Inventory.Application.Features.Racks.Commands.DeleteRack;
using Inventory.Application.Features.Stores.Commands.DeleteStore;
using Inventory.Domain.Common;

namespace Inventory.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class RackController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllRacksDto>>> Get()
        {
            return await _mediator.Send(new GetAllRacksQuery());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRackByIdDto>> GetRackById(int id)
        {
            return await _mediator.Send(new GetRackByIdQuery(id));
        }
        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateRackCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<int>>> Update(int id, UpdateRackCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return await _mediator.Send(command);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            try
            {
                return await _mediator.Send(new DeleteRackCommand(id));
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
