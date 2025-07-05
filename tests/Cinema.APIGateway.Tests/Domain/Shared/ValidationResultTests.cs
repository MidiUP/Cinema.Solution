using Cinema.APIGateway.Domain.Shared;

namespace Cinema.APIGateway.Tests.Domain.Shared;

public class ValidationResultTests
{
    [Fact]
    public void ValidationResult_DefaultConstructor_ShouldBeValid()
    {
        // Arrange & Act
        var result = new ValidationResult();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void ValidationResult_ConstructorWithError_ShouldAddErrorAndBeInvalid()
    {
        // Arrange
        var error = "Campo obrigatório";

        // Act
        var result = new ValidationResult(error);

        // Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal(error, result.Errors[0]);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ValidationResult_ConstructorWithInvalidError_ShouldThrowArgumentException(string error)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new ValidationResult(error));
    }

    [Fact]
    public void AddError_ShouldAddErrorToList_AndSetIsValidFalse()
    {
        // Arrange
        var result = new ValidationResult();

        // Act
        result.AddError("Erro de validação");

        // Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("Erro de validação", result.Errors[0]);
    }
}
