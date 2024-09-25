using System;
using System.Text.RegularExpressions;
using AutoMapper;
using ToDoList.Application.Features.Group.Queries.GetAll;
using ToDoList.Application.Features.Group.Queries.GetDetails;

namespace ToDoList.Application.MappingProfiles;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<GroupDto, Group>().ReverseMap();
        CreateMap<Group, GroupDetailsDto>();
    }
}
