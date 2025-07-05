using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Infrastructure.ApiFacades;
using Cinema.APIGateway.Domain.Models.Catalog;
using Cinema.APIGateway.Domain.Services.Catalog;
using Moq;

namespace Cinema.APIGateway.Tests.Domain.Services.Catalog;

public class CatalogServiceTests
{
    private readonly Mock<ICatalogApiFacade> _catalogApiFacadeMock;
    private readonly CatalogService _service;

    public CatalogServiceTests()
    {
        _catalogApiFacadeMock = new Mock<ICatalogApiFacade>();
        _service = new CatalogService(_catalogApiFacadeMock.Object);
    }

    [Fact]
    public async Task SearchMoviesAsync_ShouldReturnMovies_WhenModelIsValid()
    {
        // Arrange
        var searchModel = new SearchMoviesModel
        {
            TermSearch = "Matrix",
            PremiereYear = 1999
        };
        var movies = new List<MovieModel>
        {
            new MovieModel { Id = 1, Name = "Matrix", Description = "Sci-fi", PremiereYear = DateTimeOffset.Now }
        };

        _catalogApiFacadeMock
            .Setup(f => f.GetMoviesAsync(searchModel, It.IsAny<CancellationToken>()))
            .ReturnsAsync(movies);

        // Act
        var result = await _service.SearchMoviesAsync(searchModel);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Matrix", Assert.Single(result).Name);
    }

    [Fact]
    public async Task SearchMoviesAsync_ShouldThrowValidationException_WhenModelIsInvalid()
    {
        // Arrange
        var searchModel = new SearchMoviesModel
        {
            TermSearch = "", // inválido
            PremiereYear = 2020
        };

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => _service.SearchMoviesAsync(searchModel));
        _catalogApiFacadeMock.Verify(f => f.GetMoviesAsync(It.IsAny<SearchMoviesModel>(), It.IsAny<CancellationToken>()), Times.Never);
    }
}