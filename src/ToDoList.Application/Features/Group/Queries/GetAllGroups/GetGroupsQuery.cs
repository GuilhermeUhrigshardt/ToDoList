using System;
using MediatR;

namespace ToDoList.Application.Features.Group.Queries.GetAllGroups;

public record GetGroupsQuery : IRequest<List<GroupDto>>;
