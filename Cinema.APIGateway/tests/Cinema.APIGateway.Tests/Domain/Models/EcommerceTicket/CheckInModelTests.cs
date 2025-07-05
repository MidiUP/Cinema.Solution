using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Xunit;

namespace Cinema.APIGateway.Tests.Domain.Models.EcommerceTicket;

public class CheckInModelTests
{
    [Fact]
    public void Validation_ShouldBeValid_WhenMovieIdAndCustomerIdAreGreaterThanZero()
    {
        // Arrange
        var model = new CheckInModel
        {
            MovieId = 1,
            CustomerId = 2
        };

        // Act
        var result = model.Validation();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 0)]
    [InlineData(0, 0)]
    [InlineData(-1, 2)]
    [InlineData(2, -1)]
    public void Validation_ShouldBeInvalid_WhenMovieIdOrCustomerIdIsZeroOrNegative(int movieId, int customerId)
    {
        // Arrange
        var model = new CheckInModel
        {
            MovieId = movieId,
            CustomerId = customerId
        };

        // Act
        var result = model.Validation();

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains("O identificador do filme e do cliente não podem ser nulos ou zero.", result.Errors);
    }
}
