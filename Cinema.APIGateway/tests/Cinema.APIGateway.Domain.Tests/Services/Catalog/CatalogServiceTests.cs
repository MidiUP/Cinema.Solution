using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Infrastructure.Repositories;
using Cinema.APIGateway.Domain.Models.Catalog;
using Cinema.APIGateway.Domain.Services.Catalog;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Cinema.APIGateway.Domain.Tests.Services.Catalog;

public class CatalogServiceTests
{
    private readonly Mock<ICatalogRepository> _catalogRepositoryMock;
    private readonly Mock<ILogger<CatalogService>> _loggerMock;
    private readonly CatalogService _service;

    public CatalogServiceTests()
    {
        _catalogRepositoryMock = new Mock<ICatalogRepository>();
        _loggerMock = new Mock<ILogger<CatalogService>>();
        _service = new CatalogService(_catalogRepositoryMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task SearchMoviesAsync_ShouldReturnMovies_WhenModelIsValid()
    {
        // Arrange
        var model = new SearchMoviesModel { TermSearch = "Matrix", PremiereYear = 1999 };
        var movies = new List<MovieModel>
        {
            new MovieModel { Id = 1, Name = "Matrix", Description = "Sci-fi", PremiereDate = DateTimeOffset.Now }
        };
        _catalogRepositoryMock.Setup(r => r.SearchMoviesAsync(model)).ReturnsAsync(movies);

        // Act
        var result = await _service.SearchMoviesAsync(model);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Matrix", result.First().Name);
    }

    [Fact]
    public async Task SearchMoviesAsync_ShouldThrowValidationException_WhenModelIsInvalid()
    {
        // Arrange
        var model = new SearchMoviesModel { TermSearch = "", PremiereYear = 2020 };

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => _service.SearchMoviesAsync(model));
    }

    [Fact]
    public async Task SearchMoviesAsync_ShouldLogErrorAndThrow_WhenRepositoryThrowsException()
    {
        // Arrange
        var model = new SearchMoviesModel { TermSearch = "Matrix", PremiereYear = 1999 };
        _catalogRepositoryMock.Setup(r => r.SearchMoviesAsync(model)).ThrowsAsync(new Exception("DB error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _service.SearchMoviesAsync(model));
        _loggerMock.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Erro desconhecido ao buscar filmes no catálogo")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}