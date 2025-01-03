using System;
using AutoMapper;
using ToDoList.Application.Features.Checklist.Commands.Create;
using ToDoList.Application.Features.Checklist.Commands.Update;
using ToDoList.Application.Features.Checklist.Queries.GetAll;
using ToDoList.Application.Features.Checklist.Queries.GetDetails;
using ToDoList.Application.Features.Checklist.Queries.GetWithItems;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.MappingProfiles;

public class ChecklistProfile : Profile
{
    public ChecklistProfile()
    {
        CreateMap<Checklist, ChecklistUpdateDto>();
        CreateMap<Checklist, ChecklistCreateDto>();
        CreateMap<Checklist, ChecklistDto>();
        CreateMap<Checklist, ChecklistWithItemsDto>();
        CreateMap<Checklist, ChecklistDetailsDto>().ReverseMap();
        CreateMap<CreateChecklistCommand, Checklist>();
        CreateMap<UpdateChecklistCommand, Checklist>();
    }
}
