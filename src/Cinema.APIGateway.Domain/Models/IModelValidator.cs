using Cinema.APIGateway.Domain.Shared;

namespace Cinema.APIGateway.Domain.Models;

public interface IModelValidator
{
    public ValidationResult Validation();
}
