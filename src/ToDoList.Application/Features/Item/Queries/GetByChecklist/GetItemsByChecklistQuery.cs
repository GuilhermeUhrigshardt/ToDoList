using System;
using MediatR;

namespace ToDoList.Application.Features.Item.Queries.GetByChecklist;

public sealed record GetItemsByChecklistQuery(Guid ChecklistId) : IRequest<List<ItemsByChecklistDto>>;
