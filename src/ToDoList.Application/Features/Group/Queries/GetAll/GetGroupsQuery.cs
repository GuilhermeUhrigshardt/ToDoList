using System;
using MediatR;

namespace ToDoList.Application.Features.Group.Queries.GetAll;

public record GetGroupsQuery : IRequest<List<GroupDto>>;
