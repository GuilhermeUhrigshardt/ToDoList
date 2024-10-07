using System;
using MediatR;

namespace ToDoList.Application.Features.Group.Queries.GetDetails;

public sealed record GetGroupDetailsQuery(Guid Id) : IRequest<GroupDetailsDto>;
