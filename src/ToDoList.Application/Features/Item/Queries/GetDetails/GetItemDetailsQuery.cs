using MediatR;

namespace ToDoList.Application.Features.Item.Queries.GetDetails;

public record GetItemDetailsQuery(Guid Id) : IRequest<ItemDetailsDto>;
