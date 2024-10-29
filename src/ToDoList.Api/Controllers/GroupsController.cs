using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Features.Group.Queries.GetAll;

namespace ToDoList.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupsController
{
    private readonly IMediator _mediator;

    public GroupsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<GroupDto>> Get()
    {
        return await _mediator.Send(new GetGroupsQuery());
    }
}
