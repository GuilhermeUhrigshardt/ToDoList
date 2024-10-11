using System;
using AutoMapper;
using ToDoList.Application.Features.Item.Queries.GetByChecklist;
using ToDoList.Application.Features.Item.Queries.GetDetails;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.MappingProfiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Item, ItemsByChecklistDto>();
        CreateMap<Item, ItemDetailsDto>();
    }
}
