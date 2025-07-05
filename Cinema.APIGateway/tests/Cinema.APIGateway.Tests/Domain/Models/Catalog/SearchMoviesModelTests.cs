using Cinema.APIGateway.Domain.Models.Catalog;
using Xunit;

namespace Cinema.APIGateway.Tests.Domain.Models.Catalog;


public class SearchMoviesModelTests
{
    [Fact]
    public void Validation_ShouldBeValid_WhenTermSearchIsFilled()
    {
        // Arrange
        var model = new SearchMoviesModel
        {
            TermSearch = "Matrix",
            PremiereYear = 1999
        };

        // Act
        var result = model.Validation();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Validation_ShouldBeInvalid_WhenTermSearchIsNullOrEmpty(string term)
    {
        // Arrange
        var model = new SearchMoviesModel
        {
            TermSearch = term,
            PremiereYear = 2020
        };

        // Act
        var result = model.Validation();

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains("O termo de pesquisa não pode ser nulo ou vazio.", result.Errors);
    }
}
