using System;

namespace ToDoList.Application.Features.Group.Queries.GetDetails;

public record GroupDetailsDto(Guid Id, string Name, DateTime Inserted);
