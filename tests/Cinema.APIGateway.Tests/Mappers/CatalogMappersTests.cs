using Cinema.APIGateway.Domain.Dtos.Requests.Catalog;
using Cinema.APIGateway.Domain.Models.Catalog;
using Cinema.APIGateway.Domain.Mappers.Catalog;

namespace Cinema.APIGateway.Tests.Mappers;

public class CatalogMappersTests
{
    [Fact]
    public void MapToSearchMoviesModel_ShouldMapPropertiesCorrectly()
    {
        // Arrange
        var dto = new GetMoviesRequestDto
        {
            TermSearch = "Matrix",
            PremiereYear = 1999
        };

        // Act
        var model = dto.MapToSearchMoviesModel();

        // Assert
        Assert.Equal(dto.TermSearch, model.TermSearch);
        Assert.Equal(dto.PremiereYear, model.PremiereYear);
    }

    [Fact]
    public void MapToGetMoviesResponseDto_ShouldMapPropertiesCorrectly()
    {
        // Arrange
        var movie = new MovieModel
        {
            Id = 1,
            Name = "Matrix",
            Description = "Sci-fi",
            PremiereYear = new DateTimeOffset(1999, 3, 31, 0, 0, 0, TimeSpan.Zero)
        };

        // Act
        var dto = movie.MapToGetMoviesResponseDto();

        // Assert
        Assert.Equal(movie.Id, dto.Id);
        Assert.Equal(movie.Name, dto.Name);
        Assert.Equal(movie.Description, dto.Description);
        Assert.Equal(movie.PremiereYear, dto.PremiereYear);
    }
}
