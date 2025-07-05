using System.Diagnostics.CodeAnalysis;

namespace Cinema.APIGateway.Domain.Exceptions;

/// <summary>
/// Classe base abstrata para exceções personalizadas do API Gateway de Cinema.
/// </summary>
/// <remarks>
/// Deve ser herdada por todas as exceções específicas do domínio do API Gateway, permitindo padronização do tratamento de erros e códigos de erro customizados.
/// </remarks>
[ExcludeFromCodeCoverage]
public abstract class CinemaAPIGatewayException : Exception
{
    /// <summary>
    /// Código de erro específico da exceção.
    /// </summary>
    public abstract int ERROR_CODE { get; }

    /// <summary>
    /// Lista de mensagens de erro detalhadas.
    /// </summary>
    public List<string>? Errors { get; set; }

    /// <summary>
    /// Inicializa uma nova instância de <see cref="CinemaAPIGatewayException"/> com uma lista de erros e uma mensagem.
    /// </summary>
    /// <param name="errors">Lista de mensagens de erro detalhadas.</param>
    /// <param name="message">Mensagem principal da exceção.</param>
    public CinemaAPIGatewayException(List<string> errors, string message) : base(message)
    {
        Errors = errors;
    }

    /// <summary>
    /// Inicializa uma nova instância de <see cref="CinemaAPIGatewayException"/> com uma lista de erros e uma mensagem padrão.
    /// </summary>
    /// <param name="errors">Lista de mensagens de erro detalhadas.</param>
    public CinemaAPIGatewayException(List<string> errors) : this(errors, "Cinema API Gateway Exception") { }

}
