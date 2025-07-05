using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Cinema.APIGateway.Domain.Shared;

/// <summary>
/// Classe utilitária para configuração centralizada das opções de domínio via injeção de dependência.
/// </summary>
/// <remarks>
/// Responsável por registrar e validar as opções de configuração (Options Pattern) para integrações como RabbitMQ, EcommerceTicketApi e CatalogApi.
/// Utiliza validação por data annotations e validação no startup da aplicação.
/// </remarks>
[ExcludeFromCodeCoverage]
public static class OptionsSetup
{
    /// <summary>
    /// Registra e valida as opções de configuração do domínio no container de injeção de dependência.
    /// </summary>
    /// <param name="services">Coleção de serviços da aplicação.</param>
    /// <param name="configuration">Configuração da aplicação (geralmente proveniente do appsettings).</param>
    public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDomainOptions<RabbitMqOptions>(configuration, "RabbitMq");
        services.AddDomainOptions<EcommerceTicketApiOptions>(configuration, "EcommerceTicketApi");
        services.AddDomainOptions<CatalogApiOptions>(configuration, "CatalogApi");
    }

    /// <summary>
    /// Registra uma opção de domínio do tipo <typeparamref name="T"/> com validação de data annotations e validação no startup.
    /// </summary>
    /// <typeparam name="T">Tipo da opção de configuração.</typeparam>
    /// <param name="services">Coleção de serviços da aplicação.</param>
    /// <param name="configuration">Configuração da aplicação.</param>
    /// <param name="section">Nome da seção de configuração.</param>
    private static void AddDomainOptions<T>(this IServiceCollection services, IConfiguration configuration, string section) where T : class
    {
        services.AddOptions<T>()
            .Bind(configuration.GetSection(section))
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}

/// <summary>
/// Opções de configuração para integração com o RabbitMQ.
/// </summary>
/// <remarks>
/// Mapeia a seção "RabbitMq" do appsettings e exige propriedades obrigatórias para conexão e nome da fila.
/// </remarks>
[ExcludeFromCodeCoverage]
public class RabbitMqOptions
{
    /// <summary>
    /// Host do servidor RabbitMQ.
    /// </summary>
    [Required]
    public string Host { get; set; } = default!;

    /// <summary>
    /// Porta de conexão com o RabbitMQ.
    /// </summary>
    public string Port { get; set; } = default!;

    /// <summary>
    /// Nome de usuário para autenticação no RabbitMQ.
    /// </summary>
    [Required]
    public string Username { get; set; } = default!;

    /// <summary>
    /// Senha para autenticação no RabbitMQ.
    /// </summary>
    [Required]
    public string Password { get; set; } = default!;

    /// <summary>
    /// Nome da fila para criação de tickets de e-commerce.
    /// </summary>
    [Required]
    public string QueueCreateEcommerceTicketName { get; set; } = default!;
}

/// <summary>
/// Opções de configuração para integração com a API de tickets de e-commerce.
/// </summary>
/// <remarks>
/// Mapeia a seção "EcommerceTicketApi" do appsettings.
/// </remarks>
[ExcludeFromCodeCoverage]
public class EcommerceTicketApiOptions
{
    /// <summary>
    /// Nome da integração da API de tickets de e-commerce.
    /// </summary>
    [Required]
    public string Name { get; set; } = "EcommerceTicketApi";

    /// <summary>
    /// URL base da API de tickets de e-commerce.
    /// </summary>
    [Required]
    public string BaseUrl { get; set; } = default!;
}

/// <summary>
/// Opções de configuração para integração com a API de catálogo.
/// </summary>
/// <remarks>
/// Mapeia a seção "CatalogApi" do appsettings.
/// </remarks>
[ExcludeFromCodeCoverage]
public class CatalogApiOptions
{
    /// <summary>
    /// Nome da integração da API de catálogo.
    /// </summary>
    [Required]
    public string Name { get; set; } = "CatalogApi";

    /// <summary>
    /// URL base da API de catálogo.
    /// </summary>
    [Required]
    public string BaseUrl { get; set; } = default!;
}

