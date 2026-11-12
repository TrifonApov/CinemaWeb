namespace CinemaApp.Services.Tests
{
    using Core;
    using Core.Contracts;
    using Data.Models;
    using Data.Repository.Contracts;
    using Moq;

    [TestFixture]
    public class ManagerServiceTests
    {
        private IManagerService managerService;

        [SetUp]
        public void SetUp()
        {
            Guid managerId = Guid.Parse("2bc6de06-f7e0-48c5-8624-7ce63bea60ff");
            Guid regUserIs = Guid.Parse("2bc6de06-f7e0-48c5-8624-7ce63bea60fe");
            
            Mock<IManagerRepository> managerRepositoryMock
                = new Mock<IManagerRepository>();
            
            managerRepositoryMock
                .Setup(mr => mr.GetManagerByUserIdAsync(managerId))
                .ReturnsAsync(new Manager()
                {
                    Id = Guid.Parse("358d106d-2c6d-4c5e-bc16-132881680240"),
                    Level = 1,
                    UserId = managerId
                });

            managerRepositoryMock
                .Setup(mr => mr.GetManagerByUserIdAsync(regUserIs))
                .ReturnsAsync((Manager?)null);

            managerService = new ManagerService(managerRepositoryMock.Object);
        }

        [Test]
        public async Task IsUserManagerAsync_UserIsManager_ReturnsTrue()
        {
            // Arrange
            string userId = "2bc6de06-f7e0-48c5-8624-7ce63bea60ff";

            // Act
            bool result = await managerService.IsUserManagerAsync(userId);
            
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsUserManagerAsync_UserIsNotManager_ReturnsFalse()
        {
            // Arrange
            string userId = "2bc6de06-f7e0-48c5-8624-7ce63bea60fe";

            // Act
            bool result = await managerService.IsUserManagerAsync(userId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsUserManagerAsync_InvalidGuid_ReturnsFalse()
        {
            // Arrange
            string userId = "SomeInvalidGuid";

            // Act
            bool result = await managerService.IsUserManagerAsync(userId);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
