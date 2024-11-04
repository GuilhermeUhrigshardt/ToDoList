using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Group.Commands.Create;

public class CreateGroupCommandHandler(IMapper mapper, IGroupRepository groupRepository) : IRequestHandler<CreateGroupCommand, Guid>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGroupRepository _groupRepository = groupRepository;

    public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateGroupCommandValidator(_groupRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Count > 0)
            throw new BadRequestException($"Invalid Group", validationResult);

        var groupToCreate = _mapper.Map<Domain.Entities.Group>(request.Group);
        var groupCreated = await _groupRepository.CreateAsync(groupToCreate);
        return groupCreated.Id;
    }
}
