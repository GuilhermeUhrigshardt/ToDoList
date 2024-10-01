using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Group.Commands.Create;

public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;

    public CreateGroupCommandHandler(IMapper mapper, IGroupRepository groupRepository)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
    }

    public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateGroupCommandValidator(_groupRepository);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
            throw new BadRequestException($"Invalid Group", validationResult);

        var groupToCreate = _mapper.Map<Domain.Entities.Group>(request);
        await _groupRepository.CreateAsync(groupToCreate);
        return groupToCreate.Id;
    }
}
