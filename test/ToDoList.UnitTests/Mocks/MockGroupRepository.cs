using Moq;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Domain.Entities;

namespace ToDoList.UnitTests.Mocks
{
    public class MockGroupRepository
    {
        public static Mock<IGroupRepository> GetGroups()
        {
            var groups = new List<Group>
                {
                    new() {
                        Id = new Guid("77084991-731a-4ffb-9151-4630a449ef8a"),
                        Name = "Shopping",
                        Inserted = DateTime.Now
                    },
                    new() {
                        Id = new Guid("104f9716-3fa6-436b-9178-facc35469d58"),
                        Name = "Work",
                        Inserted = DateTime.Now
                    },
                    new() {
                        Id = new Guid("b1a83dfa-388d-4214-908f-ef6c7cacb2e0"),
                        Name = "School",
                        Inserted = DateTime.Now
                    },
                    new() {
                        Id = new Guid("fcf89170-a712-4b75-aa39-e354223a73f2"),
                        Name = "Home",
                        Inserted = DateTime.Now
                    }
                };

            var mockGroupRepository = new Mock<IGroupRepository>();

            mockGroupRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(groups);

            mockGroupRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => groups.FirstOrDefault(x => x.Id == id));

            mockGroupRepository.Setup(repo => repo.CreateAsync(It.IsAny<Group>()))
                .ReturnsAsync((Group group) =>
                {
                    groups.Add(group);
                    return group;
                });

            mockGroupRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Group>()))
                .ReturnsAsync((Group group) =>
                {
                    var index = groups.FindIndex(x => x.Id == group.Id);
                    groups[index] = group;
                    return group;
                });

            mockGroupRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Group>()))
                .ReturnsAsync((Group group) =>
                {
                    groups.Remove(group);
                    return true;
                });

            return mockGroupRepository;
        }
    }
}
