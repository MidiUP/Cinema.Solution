using Cinema.Catalog.Domain.Shared;

namespace Cinema.Catalog.Domain.Models;

public interface IModelValidator
{
    public ValidationResult Validation();
}
