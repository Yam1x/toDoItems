using Application.ToDoItems.Commands;
using Application.ToDoItems.Queries;
using AutoMapper;
using lab2.Models.ToDoItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    [ApiController]
    [Route("api/items")]
    [Produces("application/json")]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ToDoController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> AddToDoItem([FromForm] AddToDoItemDto request)
        {
            return Ok(await _mediator.Send(_mapper.Map<AddToDoItemCommand>(request)));
        }
        [HttpGet]
        public async Task<ActionResult<ToDoItemsListVm>> GetToDoItems()
        {
            return Ok(await _mediator.Send(new GetToDoItemsList()));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemVm>> GetToDoItem(Guid id)
        {
            return await _mediator.Send(new GetToDoItem() { Id = id });
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateToDoItem([FromForm] UpdateToDoItemCommand request)
        {
            await _mediator.Send(request);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteToDoItem(Guid id)
        {
            await _mediator.Send(new DeleteToDoItemCommand() { Id = id });
            return NoContent();
        }
    }
}
