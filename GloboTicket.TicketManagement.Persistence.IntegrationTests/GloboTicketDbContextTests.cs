using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace GloboTicket.TicketManagement.Persistence.IntegrationTests
{
    public class GloboTicketDbContextTests
    {
        private readonly GloboTicketDbContext _globoTicketDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public GloboTicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<GloboTicketDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _globoTicketDbContext = new GloboTicketDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            // Arrange
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };

            _globoTicketDbContext.Events.Add(ev);

            // Act
            await _globoTicketDbContext.SaveChangesAsync();

            // Assert
            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
