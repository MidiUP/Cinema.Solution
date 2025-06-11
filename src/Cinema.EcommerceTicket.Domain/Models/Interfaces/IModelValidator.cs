using Cinema.EcommerceTicket.Domain.Shared;

namespace Cinema.EcommerceTicket.Domain.Models.Interfaces;

public interface IModelValidator
{
    public ValidationResult Validation();
}
