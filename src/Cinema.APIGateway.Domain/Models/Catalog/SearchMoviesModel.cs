using Cinema.APIGateway.Domain.Shared;

namespace Cinema.APIGateway.Domain.Models.Catalog;

public class SearchMoviesModel
{
    public required string TermSearch { get; set; }
    public int PremiereYear { get; set; }

    public ValidationResult Validation()
    {
        var result = new ValidationResult();

        if (string.IsNullOrWhiteSpace(TermSearch))
            result.AddError("O termo de pesquisa não pode ser nulo ou vazio");

        return result;
    }
}
