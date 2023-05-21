using Inventory.Application.Features.Stores.Commands.CreateStore;
using Inventory.Application.Features.Stores.Commands.DeleteStore;
using Inventory.Application.Features.Stores.Commands.UpdateStore;
using Inventory.Application.Features.Stores.Queries.GetAllStores;
using Inventory.Application.Features.Stores.Queries.GetStoreById;
using Inventory.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StoreController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllStoresDto>>> Get()
        {
            return await _mediator.Send(new GetAllStoresQuery());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetStoreByIdDto>> GetStoreById(int id)
        {
            return await _mediator.Send(new GetStoreByIdQuery(id));
        }
        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateStoreCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Result<int>>> Update(int id, UpdateStoreCommand command)
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
            return await _mediator.Send(new DeleteStoreCommand(id));
        }
    }
}
