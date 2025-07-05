using System.Configuration;

namespace Cinema.APIGateway.Domain.Shared;

/// <summary>
/// Classe utilitária para constantes e variáveis globais do domínio.
/// </summary>
/// <remarks>
/// Fornece acesso centralizado a variáveis de ambiente importantes para a configuração da aplicação.
/// </remarks>
public static class Constants
{
    /// <summary>
    /// Obtém o valor da variável de ambiente <c>ENV</c>.
    /// </summary>
    /// <exception cref="ConfigurationErrorsException">
    /// Lançada quando a variável de ambiente <c>ENV</c> não está definida.
    /// </exception>
    public static string ENV => Environment.GetEnvironmentVariable("ENV")
        ?? throw new ConfigurationErrorsException("A variável de ambiente ENV não pode ser nula.");
}

