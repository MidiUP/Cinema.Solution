using Cinema.APIGateway.Domain.Dtos.Requests.EcommerceTicket;
using Cinema.APIGateway.Domain.Mappers.EcommerceTicket;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;

namespace Cinema.APIGateway.Tests.Mappers;

public class EcommerceTicketMappersTests
{
    [Fact]
    public void MapToEcommerceCreateTicketEvent_ShouldMapPropertiesCorrectly()
    {
        // Arrange
        var checkInModel = new CheckInModel
        {
            MovieId = 10,
            CustomerId = 20
        };

        // Act
        var result = checkInModel.MapToEcommerceCreateTicketEvent();

        // Assert
        Assert.Equal(checkInModel.MovieId, result.MovieId);
        Assert.Equal(checkInModel.CustomerId, result.CustomerId);
    }

    [Fact]
    public void MapToCheckInModel_ShouldMapPropertiesCorrectly()
    {
        // Arrange
        var request = new CreateCheckInRequestDto
        {
            MovieId = 5,
            CustomerId = 15
        };

        // Act
        var result = request.MapToCheckInModel();

        // Assert
        Assert.Equal(request.MovieId, result.MovieId);
        Assert.Equal(request.CustomerId, result.CustomerId);
    }

    [Fact]
    public void MapToGetTicketResponseDto_ShouldMapPropertiesCorrectly()
    {
        // Arrange
        var now = DateTime.UtcNow;
        var ticketModel = new TicketModel
        {
            Id = "abc123",
            MovieId = 1,
            CustomerId = 2,
            CheckInId = 3,
            Price = 25.5m,
            CreatedAt = now
        };
        
        var brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById(
        OperatingSystem.IsWindows() ? "E. South America Standard Time" : "America/Sao_Paulo"
        );

    // Act
    var result = ticketModel.MapToGetTicketResponseDto();

        // Assert
        Assert.Equal(ticketModel.Id, result.Id);
        Assert.Equal(ticketModel.MovieId, result.MovieId);
        Assert.Equal(ticketModel.CustomerId, result.CustomerId);
        Assert.Equal(ticketModel.CheckInId, result.CheckInId);
        Assert.Equal(ticketModel.Price, result.Price);
        Assert.Equal(TimeZoneInfo.ConvertTimeFromUtc(ticketModel.CreatedAt, brasiliaTimeZone), result.CreatedAt);
    }

}
