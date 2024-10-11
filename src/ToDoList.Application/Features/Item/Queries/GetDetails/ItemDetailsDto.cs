using System;

namespace ToDoList.Application.Features.Item.Queries.GetDetails;

public sealed record ItemDetailsDto(Guid Id, string Title, string? Note, DateTime? Remind, DateTime? DueTo, bool Important, bool Completed, DateTime? CompletedDate, int Order);
