namespace Cinema.APIGateway.Domain.Models.Catalog;

public class MovieModel
{
    /// <summary>
    /// Identificador do filme no The Moview Database.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Nome do filme.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Descricao/resumo do filme.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Data de lançamento do filme.
    /// </summary>
    public DateTimeOffset PremiereDate { get; set; }

}
