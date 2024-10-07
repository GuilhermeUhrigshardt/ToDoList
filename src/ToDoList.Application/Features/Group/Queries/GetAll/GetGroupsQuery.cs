using System;
using MediatR;

namespace ToDoList.Application.Features.Group.Queries.GetAll;

public sealed record GetGroupsQuery : IRequest<List<GroupDto>>;
