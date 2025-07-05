using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Cinema.APIGateway.Domain.Exceptions;

/// <summary>
/// Exceção lançada quando ocorre um timeout em uma operação no API Gateway de Cinema.
/// </summary>
/// <remarks>
/// Representa uma exceção específica para situações em que uma requisição excede o tempo limite de resposta esperado.
/// Retorna o código de erro HTTP 408 (Request Timeout).
/// </remarks>
[ExcludeFromCodeCoverage]
public class TimeoutException : CinemaAPIGatewayException
{
    const string ERROR_EXCEPTION_MESSAGE = "Timeout Exception";

    /// <summary>
    /// Código de erro HTTP associado à exceção de timeout (408 - Request Timeout).
    /// </summary>
    public override int ERROR_CODE => (int) HttpStatusCode.RequestTimeout;

    /// <summary>
    /// Inicializa uma nova instância de <see cref="TimeoutException"/> com mensagem padrão de timeout.
    /// </summary>
    public TimeoutException() : base([], ERROR_EXCEPTION_MESSAGE) { }

}
