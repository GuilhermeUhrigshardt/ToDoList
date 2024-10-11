using System;
using AutoMapper;
using ToDoList.Application.Features.Checklist.Commands.Update;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.MappingProfiles;

public class ChecklistProfile : Profile
{
    public ChecklistProfile()
    {
        CreateMap<Checklist, ChecklistUpdateDto>();
    }
}
