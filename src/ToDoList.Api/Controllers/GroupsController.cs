using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Features.Group.Commands.Create;
using ToDoList.Application.Features.Group.Commands.Delete;
using ToDoList.Application.Features.Group.Commands.Update;
using ToDoList.Application.Features.Group.Queries.GetAll;
using ToDoList.Application.Features.Group.Queries.GetDetails;
using ToDoList.Application.Features.Group.Queries.GetWithChecklists;
using ToDoList.Application.Features.Group.Queries.GetWithChecklistsAndItems;

namespace ToDoList.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<GroupDto>>> Get()
    {
        var groups = await _mediator.Send(new GetGroupsQuery());
        return Ok(groups);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<GroupDetailsDto>> Get(Guid id)
    {
        var group = await _mediator.Send(new GetGroupDetailsQuery(id));
        return Ok(group);
    }

    [HttpGet("{id}/WithChecklists")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<GroupWithChecklistsDto>> GetWithChecklists(Guid id)
    {
        var group = await _mediator.Send(new GetWithChecklistsQuery(id));
        return Ok(group);
    }

    [HttpGet("{id}/WithItems")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<GroupWithChecklistsAndItemsDto>> GetWithChecklistsAndItems(Guid id)
    {
        var group = await _mediator.Send(new GetWithChecklistsAndItemsQuery(id));
        return Ok(group);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Create(GroupCreateDto group)
    {
        var response = await _mediator.Send(new CreateGroupCommand(group));
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(GroupUpdateDto group)
    {
        await _mediator.Send(new UpdateGroupCommand(group));
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteGroupCommand(id));
        return NoContent();
    }
}
