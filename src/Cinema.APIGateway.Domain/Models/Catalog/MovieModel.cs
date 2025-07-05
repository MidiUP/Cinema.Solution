namespace Cinema.APIGateway.Domain.Models.Catalog;

/// <summary>
/// Modelo de domínio que representa um filme no catálogo.
/// </summary>
/// <remarks>
/// Contém as principais informações de um filme, como identificador, nome, descrição e data de lançamento.
/// Utilizado em operações de consulta e manipulação de dados de filmes no domínio do catálogo.
/// </remarks>
public class MovieModel
{
    /// <summary>
    /// Identificador do filme no The Movie Database.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Nome do filme.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Descrição ou resumo do filme.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Data de lançamento do filme.
    /// </summary>
    public DateTimeOffset PremiereYear { get; set; }
}

