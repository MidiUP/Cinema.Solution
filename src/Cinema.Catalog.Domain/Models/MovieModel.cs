namespace Cinema.Catalog.Domain.Models;

public class MovieModel
{
    /// <summary>
    /// Identificador do filme no The Moview Database.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Nome do filme.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Descricao/Resumo do filme.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Data de lancamento do filme.
    /// </summary>
    public DateTimeOffset? PremiereYear { get; set; }
}
