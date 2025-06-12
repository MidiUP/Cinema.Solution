using Cinema.EcommerceTicket.Domain.Models.Interfaces;
using Cinema.EcommerceTicket.Domain.Shared;

namespace Cinema.EcommerceTicket.Domain.Models;

public class CheckInModel : IModelValidator
{
    const string MESSAGE_VALIDATION_ERROR = "O identificador do filme e do cliente não podem ser nulos ou zero.";

    /// <summary>
    /// Identificador do filme.
    /// </summary>
    public int MovieId { get; set; }

    /// <summary>
    /// Identificador do cliente.
    /// </summary>
    public int CustomerId { get; set; }

    public ValidationResult Validation()
    {
        var result = new ValidationResult();

        if (MovieId <= 0 || CustomerId <= 0)
            result.AddError(MESSAGE_VALIDATION_ERROR);

        return result;
    }
}
