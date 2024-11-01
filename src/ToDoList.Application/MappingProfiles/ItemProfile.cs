using System;
using AutoMapper;
using ToDoList.Application.Features.Item.Commands.Create;
using ToDoList.Application.Features.Item.Commands.Reorder;
using ToDoList.Application.Features.Item.Commands.Update;
using ToDoList.Application.Features.Item.Queries.GetByChecklist;
using ToDoList.Application.Features.Item.Queries.GetDetails;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.MappingProfiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Item, ItemsByChecklistDto>().ReverseMap();
        CreateMap<Item, ItemDetailsDto>();
        CreateMap<Item, ItemUpdateDto>();
        CreateMap<Item, ItemCreateDto>();
        CreateMap<CreateItemCommand, Item>();
        CreateMap<UpdateItemCommand, Item>();
        CreateMap<ReorderItemsCommand, Item>();
    }
}
