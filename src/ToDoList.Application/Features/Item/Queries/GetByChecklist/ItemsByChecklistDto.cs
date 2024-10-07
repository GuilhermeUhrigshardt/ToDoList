using System;

namespace ToDoList.Application.Features.Item.Queries.GetByChecklist;

public sealed record ItemsByChecklistDto(Guid Id, string? Note, DateTime? Remind, DateTime? DueTo, bool Important, bool Completed, DateTime? CompletedDate, int Order, Guid IdChecklist);
