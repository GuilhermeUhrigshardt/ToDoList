using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Application.Features.Group.Queries.GetAll;
using ToDoList.Application.MappingProfiles;
using ToDoList.UnitTests.Mocks;

namespace ToDoList.UnitTests.Features.Group.Queries;

public class GetGroupsQueryHandlerTests
{
    private readonly Mock<IGroupRepository> _mockGroupRepository;
    private readonly IMapper _mapper;

    public GetGroupsQueryHandlerTests()
    {
        _mockGroupRepository = MockGroupRepository.GetGroups();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<GroupProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidQuery_ShouldReturnList()
    {
        var handler = new GetGroupsQueryHandler(_mapper, _mockGroupRepository.Object);

        var result = await handler.Handle(new GetGroupsQuery(), CancellationToken.None);

        result.ShouldNotBeNull();
        result.Count.ShouldBe(4);
        result.ShouldBeOfType<List<GroupDto>>();
    }
}
