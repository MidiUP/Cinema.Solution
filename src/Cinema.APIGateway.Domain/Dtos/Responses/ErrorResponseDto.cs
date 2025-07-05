using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Cinema.APIGateway.Domain.Dtos.Responses;

/// <summary>
/// DTO de resposta para erros ocorridos nas requisições da API.
/// </summary>
/// <remarks>
/// Utilizado para padronizar o retorno de mensagens de erro e detalhes de validação para o cliente.
/// </remarks>
[ExcludeFromCodeCoverage]
public record ErrorResponseDto
{
    /// <summary>
    /// Lista de erros detalhados relacionados à requisição.
    /// </summary>
    [JsonProperty("erros")]
    public List<string>? Errors { get; set; }

    /// <summary>
    /// Mensagem principal de erro.
    /// </summary>

    [JsonProperty("mensagem")]
    public string? Message { get; set; }

    /// <summary>
    /// Inicializa uma nova instância de <see cref="ErrorResponseDto"/> com uma lista de erros e uma mensagem.
    /// </summary>
    /// <param name="errors">Lista de erros detalhados.</param>
    /// <param name="message">Mensagem principal de erro.</param>
    public ErrorResponseDto(List<string> errors, string message)
    {
        Errors = errors;
        Message = message;
    }

    /// <summary>
    /// Inicializa uma nova instância de <see cref="ErrorResponseDto"/> com um erro único e uma mensagem.
    /// </summary>
    /// <param name="error">Erro detalhado.</param>
    /// <param name="message">Mensagem principal de erro.</param>
    public ErrorResponseDto(string error, string message) : this([error], message) { }


    /// <summary>
    /// Inicializa uma nova instância de <see cref="ErrorResponseDto"/> apenas com uma mensagem.
    /// </summary>
    /// <param name="message">Mensagem principal de erro.</param>
    public ErrorResponseDto(string message)
    {
        Message = message;
    }
}
