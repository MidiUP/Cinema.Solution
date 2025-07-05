using System.Net;

namespace Cinema.APIGateway.Domain.Exceptions;

/// <summary>
/// Exceção lançada quando ocorre uma falha de validação em uma requisição no API Gateway de Cinema.
/// </summary>
/// <remarks>
/// Representa erros de validação de dados enviados pelo cliente, retornando o código de erro HTTP 400 (Bad Request).
/// </remarks>
public class ValidationException : CinemaAPIGatewayException
{
    const string ERROR_EXCEPTION_MESSAGE = "Validation Exception";

    /// <summary>
    /// Código de erro HTTP associado à exceção de validação (400 - Bad Request).
    /// </summary>
    public override int ERROR_CODE => (int)HttpStatusCode.BadRequest;

    /// <summary>
    /// Inicializa uma nova instância de <see cref="ValidationException"/> com uma lista de erros de validação.
    /// </summary>
    /// <param name="errors">Lista de mensagens de erro de validação.</param>
    public ValidationException(List<string> errors) : base(errors, ERROR_EXCEPTION_MESSAGE) { }

    /// <summary>
    /// Inicializa uma nova instância de <see cref="ValidationException"/> com um erro de validação.
    /// </summary>
    /// <param name="error">Mensagem de erro de validação.</param>
    public ValidationException(string error) : base([error], ERROR_EXCEPTION_MESSAGE) { }
}

