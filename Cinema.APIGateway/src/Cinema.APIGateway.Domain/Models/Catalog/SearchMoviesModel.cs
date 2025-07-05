using Cinema.APIGateway.Domain.Shared;

namespace Cinema.APIGateway.Domain.Models.Catalog;

/// <summary>
/// Modelo de domínio para pesquisa de filmes no catálogo.
/// </summary>
/// <remarks>
/// Contém os critérios de busca utilizados para filtrar filmes, como termo de pesquisa e ano de lançamento.
/// Implementa validação para garantir que o termo de pesquisa não seja nulo ou vazio.
/// </remarks>
public class SearchMoviesModel : IModelValidator
{
    const string MESSAGE_VALIDATION_ERROR = "O termo de pesquisa não pode ser nulo ou vazio.";

    /// <summary>
    /// Termo de pesquisa utilizado para filtrar os filmes (ex: título, parte do nome, etc).
    /// </summary>
    public required string TermSearch { get; set; }

    /// <summary>
    /// Ano de lançamento dos filmes a serem filtrados.
    /// </summary>
    public int PremiereYear { get; set; }

    /// <summary>
    /// Realiza a validação do modelo, garantindo que o termo de pesquisa seja informado.
    /// </summary>
    /// <returns>
    /// Um <see cref="ValidationResult"/> indicando se a validação foi bem-sucedida e contendo mensagens de erro, se houver.
    /// </returns>
    public ValidationResult Validation()
    {
        var result = new ValidationResult();

        if (string.IsNullOrWhiteSpace(TermSearch))
            result.AddError(MESSAGE_VALIDATION_ERROR);

        return result;
    }
}

