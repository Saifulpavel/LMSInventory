using Inventory.Application.Features.Elements.Commands.CreateElement;
using Inventory.Application.Features.Elements.Commands.DeleteElement;
using Inventory.Application.Features.Elements.Commands.UpdateElement;
using Inventory.Application.Features.Elements.Queries.GetAllElements;
using Inventory.Application.Features.Elements.Queries.GetElementById;
using Inventory.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.WebAPI.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]


    public class ElementController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ElementController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        //[Route("GetAll")]
        //public async Task<ActionResult<Result<List<GetAllElementsDto>>>> Get()
        //{
        //    return await _mediator.Send(new GetAllElementsQuery());
        //}
        public async Task<ActionResult<List<GetAllElementsDto>>> Get()
        {
            return await _mediator.Send(new GetAllElementsQuery());
        }
        [HttpGet("{id}")]
        //[HttpGet]
        //[Route("GetById")]
        public async Task<ActionResult<GetElementByIdDto>> GetElementById(int id)
        {
            return await _mediator.Send(new GetElementByIdQuery(id));
        }
        [HttpPost]
        //[Route("CreateElement")]
        public async Task<ActionResult<Result<int>>> Create([FromBody] CreateElementCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut("{id}")]
        //[HttpPut]
        //[Route("UpdateElement")]
        public async Task<ActionResult<Result<int>>> Update(int id, UpdateElementCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return await _mediator.Send(command);
        }
        [HttpPost("{id}")]
        //[HttpDelete("{id}")]
        //[HttpDelete]
        //[Route("DeleteElement")]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteElementCommand(id));
        }

    }
}
