using Cinema.APIGateway.Domain.Shared;

namespace Cinema.APIGateway.Domain.Models.EcommerceTicket;

/// <summary>
/// Modelo de domínio para o check-in de ingresso de cinema.
/// </summary>
/// <remarks>
/// Contém os dados necessários para registrar o check-in de um cliente em um filme.
/// Implementa validação para garantir que os identificadores do filme e do cliente sejam válidos.
/// </remarks>
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

    /// <summary>
    /// Realiza a validação do modelo, garantindo que os identificadores do filme e do cliente sejam maiores que zero.
    /// </summary>
    /// <returns>
    /// Um <see cref="ValidationResult"/> indicando se a validação foi bem-sucedida e contendo mensagens de erro, se houver.
    /// </returns>
    public ValidationResult Validation()
    {
        var result = new ValidationResult();

        if (MovieId <= 0 || CustomerId <= 0)
            result.AddError(MESSAGE_VALIDATION_ERROR);

        return result;
    }
}

