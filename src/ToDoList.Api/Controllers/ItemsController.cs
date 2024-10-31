using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Features.Item.Commands.Create;
using ToDoList.Application.Features.Item.Commands.Delete;
using ToDoList.Application.Features.Item.Commands.Reorder;
using ToDoList.Application.Features.Item.Commands.Update;
using ToDoList.Application.Features.Item.Queries.GetByChecklist;
using ToDoList.Application.Features.Item.Queries.GetDetails;

namespace ToDoList.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("ByChecklist/{checklistId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ItemsByChecklistDto>>> GetByGroup(Guid checklistId) {
        var items = await _mediator.Send(new GetItemsByChecklistQuery(checklistId));
        return Ok(items);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<ItemDetailsDto>> Get(Guid id) {
        var items = await _mediator.Send(new GetItemDetailsQuery(id));
        return Ok(items);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Create(CreateItemCommand item) {
        var response = await _mediator.Send(item);
        return CreatedAtAction(nameof(Get), new { Id = response });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(UpdateItemCommand item) {
        await _mediator.Send(item);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id) {
        await _mediator.Send(new DeleteItemCommand(id));
        return NoContent();
    }

    [HttpPut("Reorder/{id}/{order}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Reorder(ReorderItemsCommand item)
    {
        await _mediator.Send(item);
        return NoContent();
    }
}
