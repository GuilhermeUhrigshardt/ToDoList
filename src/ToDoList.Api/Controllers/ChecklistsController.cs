using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Features.Checklist.Commands.Create;
using ToDoList.Application.Features.Checklist.Commands.Delete;
using ToDoList.Application.Features.Checklist.Commands.Update;
using ToDoList.Application.Features.Checklist.Queries.GetAll;
using ToDoList.Application.Features.Checklist.Queries.GetDetails;
using ToDoList.Application.Features.Checklist.Queries.GetWithItems;

namespace ToDoList.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChecklistsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("ByGroup/{groupId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ChecklistDto>>> GetByGroup(Guid groupId)
    {
        var checklists = await _mediator.Send(new GetChecklistsQuery(groupId));
        return Ok(checklists);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ChecklistDto>>> Get(Guid id)
    {
        var checklists = await _mediator.Send(new GetChecklistDetailsQuery(id));
        return Ok(checklists);
    }

    [HttpGet("{id}/WithItems")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ChecklistWithItemsDto>>> GetWithItems(Guid id)
    {
        var checklists = await _mediator.Send(new GetChecklistWithItemsQuery(id));
        return Ok(checklists);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Create(CreateChecklistCommand checklist)
    {
        var response = await _mediator.Send(checklist);
        return CreatedAtAction(nameof(Get), new { Id = response });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(UpdateChecklistCommand checklist)
    {
        await _mediator.Send(checklist);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteChecklistCommand(id));
        return NoContent();
    }
}
