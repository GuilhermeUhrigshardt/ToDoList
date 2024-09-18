using System;

namespace ToDoList.Application.Features.Group.Queries.GetAllGroups;

public record GroupDto(Guid Id, string? Name);
