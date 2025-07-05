namespace Cinema.APIGateway.Domain.Shared;

/// <summary>
/// Representa o resultado da validação de um modelo de domínio.
/// </summary>
/// <remarks>
/// Armazena o status da validação e as mensagens de erro encontradas durante o processo de validação.
/// Utilizado para garantir a integridade dos dados antes de operações de negócio ou persistência.
/// </remarks>
public class ValidationResult
{
    /// <summary>
    /// Indica se a validação foi bem-sucedida.
    /// Retorna <c>true</c> se não houver erros; caso contrário, <c>false</c>.
    /// </summary>
    public bool IsValid
    {
        get
        {
            return Errors.Count == 0;
        }
    }

    /// <summary>
    /// Lista de mensagens de erro encontradas durante a validação.
    /// </summary>
    public List<string> Errors { get; private set; } = new List<string>();

    /// <summary>
    /// Inicializa uma nova instância de <see cref="ValidationResult"/> sem erros.
    /// </summary>
    public ValidationResult() { }

    /// <summary>
    /// Inicializa uma nova instância de <see cref="ValidationResult"/> com um erro informado.
    /// </summary>
    /// <param name="error">Mensagem de erro a ser adicionada.</param>
    /// <exception cref="ArgumentException">Lançada se o erro for nulo ou vazio.</exception>
    public ValidationResult(string error)
    {
        if (string.IsNullOrWhiteSpace(error))
            throw new ArgumentException("O erro não pode ser nulo ou vazio.");

        Errors.Add(error);
    }

    /// <summary>
    /// Adiciona uma mensagem à lista de erros.
    /// </summary>
    /// <param name="error">Mensagem de erro a ser adicionada.</param>
    public void AddError(string error)
    {
        Errors.Add(error);
    }
}

