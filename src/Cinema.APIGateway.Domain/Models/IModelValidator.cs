using Cinema.APIGateway.Domain.Shared;

namespace Cinema.APIGateway.Domain.Models;

/// <summary>
/// Interface para validação de modelos de domínio.
/// </summary>
/// <remarks>
/// Define um contrato para que modelos implementem lógica de validação própria, retornando um <see cref="ValidationResult"/> com o status e mensagens de erro, se houver.
/// Utilizada para garantir a integridade dos dados antes de operações de negócio ou persistência.
/// </remarks>
public interface IModelValidator
{
    /// <summary>
    /// Executa a validação do modelo, retornando o resultado da validação.
    /// </summary>
    /// <returns>
    /// Um <see cref="ValidationResult"/> indicando se a validação foi bem-sucedida e contendo mensagens de erro, se houver.
    /// </returns>
    public ValidationResult Validation();
}

