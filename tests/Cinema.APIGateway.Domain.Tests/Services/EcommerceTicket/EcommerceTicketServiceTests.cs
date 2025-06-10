using Cinema.APIGateway.Domain.Events.EcommerceTicket;
using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Infrastructure;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.APIGateway.Domain.Services.EcommerceTicket;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using TimeoutException = Cinema.APIGateway.Domain.Exceptions.TimeoutException;

namespace Cinema.APIGateway.Domain.Tests.Services.EcommerceTicket;

public class EcommerceTicketServiceTests
{
    private readonly Mock<ITopicProducer<EcommerceCreateTicketEvent>> _producerMock;
    private readonly Mock<ILogger<EcommerceTicketService>> _loggerMock;
    private readonly EcommerceTicketService _service;

    public EcommerceTicketServiceTests()
    {
        _producerMock = new Mock<ITopicProducer<EcommerceCreateTicketEvent>>();
        _loggerMock = new Mock<ILogger<EcommerceTicketService>>();
        _service = new EcommerceTicketService(_producerMock.Object, _loggerMock.Object);
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
            p => p.ProduceAsync(It.Is<EcommerceCreateTicketEvent>(e => e.MovieId == 1 && e.CustomerId == 2), It.IsAny<CancellationToken>()),
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
    public async Task AddQueueCheckInMovieAsync_ShouldThrowTimeoutException_WhenOperationCanceledExceptionIsThrown()
    {
        // Arrange
        var model = new CheckInModel { MovieId = 1, CustomerId = 2 };
        _producerMock
            .Setup(p => p.ProduceAsync(It.IsAny<EcommerceCreateTicketEvent>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new OperationCanceledException());

        // Act & Assert
        await Assert.ThrowsAsync<TimeoutException>(() => _service.AddQueueCheckInMovieAsync(model));
        _loggerMock.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Erro de timeout ao adicionar mensagem de checkin na fila")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task AddQueueCheckInMovieAsync_ShouldLogErrorAndThrow_WhenUnknownExceptionIsThrown()
    {
        // Arrange
        var model = new CheckInModel { MovieId = 1, CustomerId = 2 };
        _producerMock
            .Setup(p => p.ProduceAsync(It.IsAny<EcommerceCreateTicketEvent>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Erro inesperado"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _service.AddQueueCheckInMovieAsync(model));
        _loggerMock.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Erro desconhecido ao adicionar mensagem de checkin na fila")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}