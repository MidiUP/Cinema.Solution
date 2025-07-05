using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Infrastructure;
using Cinema.APIGateway.Domain.Infrastructure.ApiFacades;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.APIGateway.Domain.Services.EcommerceTicket;
using Cinema.Events;
using Moq;

namespace Cinema.APIGateway.Tests.Domain.Services.EcommerceTicket;

public class EcommerceTicketServiceTests
{
    private readonly Mock<ITopicProducer<EcommerceCreateTicketEvent>> _producerMock;
    private readonly Mock<IEcommerceTicketApiFacade> _apiFacadeMock;
    private readonly EcommerceTicketService _service;

    public EcommerceTicketServiceTests()
    {
        _producerMock = new Mock<ITopicProducer<EcommerceCreateTicketEvent>>();
        _apiFacadeMock = new Mock<IEcommerceTicketApiFacade>();
        _service = new EcommerceTicketService(_producerMock.Object, _apiFacadeMock.Object);
    }

    [Fact]
    public async Task AddQueueCheckInMovieAsync_ShouldCallProducer_WhenModelIsValid()
    {
        // Arrange
        var model = new CheckInModel { MovieId = 1, CustomerId = 2 };

        _producerMock
            .Setup(p => p.ProduceAsync(It.IsAny<EcommerceCreateTicketEvent>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        await _service.AddQueueCheckInMovieAsync(model);

        // Assert
        _producerMock.Verify(
            p => p.ProduceAsync(
                It.Is<EcommerceCreateTicketEvent>(e => e.MovieId == 1 && e.CustomerId == 2),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task AddQueueCheckInMovieAsync_ShouldThrowValidationException_WhenModelIsInvalid()
    {
        // Arrange
        var model = new CheckInModel { MovieId = 0, CustomerId = 0 };

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => _service.AddQueueCheckInMovieAsync(model));
        _producerMock.Verify(p => p.ProduceAsync(It.IsAny<EcommerceCreateTicketEvent>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task GetTicketsAsync_ShouldReturnTickets()
    {
        // Arrange
        var tickets = new List<TicketModel>
            {
                new() { Id = "1", MovieId = 1, CustomerId = 2, CheckInId = 3, Price = 10, CreatedAt = DateTime.Now }
            };
        _apiFacadeMock.Setup(f => f.GetTicketsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(tickets);

        // Act
        var result = await _service.GetTicketsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("1", Assert.Single(result).Id);
    }

    [Fact]
    public async Task GetTicketsByCustomerIdAsync_ShouldReturnTickets()
    {
        // Arrange
        var tickets = new List<TicketModel>
            {
                new() { Id = "1", MovieId = 1, CustomerId = 2, CheckInId = 3, Price = 10, CreatedAt = DateTime.Now }
            };
        _apiFacadeMock.Setup(f => f.GetTicketsByCustomerIdAsync(2, It.IsAny<CancellationToken>())).ReturnsAsync(tickets);

        // Act
        var result = await _service.GetTicketsByCustomerIdAsync(2);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(2, Assert.Single(result).CustomerId);
    }
}