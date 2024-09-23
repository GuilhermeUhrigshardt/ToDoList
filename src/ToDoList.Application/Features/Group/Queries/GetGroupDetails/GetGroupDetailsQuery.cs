using System;
using MediatR;

namespace ToDoList.Application.Features.Group.Queries.GetGroupDetails;

public record GetGroupDetailsQuery : IRequest<List<GroupDetailDto>>;
