using System;

namespace ToDoList.Application.Features.Group.Queries.GetGroupDetails;

public record GroupDetailDto(Guid Id, string? Name);
