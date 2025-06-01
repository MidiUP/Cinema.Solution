using System.Configuration;

namespace Cinema.APIGateway.Domain.Shared;

public static class Constants
{
    public static class RabbitMq
    {
        public static string RABBIMQ_PORT => Environment.GetEnvironmentVariable("RABBIMQ_PORT") ?? throw new ConfigurationErrorsException("A variável de amibente RABBIMQ_PORT não pode ser nula.");  
        public static string RABBIMQ_HOST => Environment.GetEnvironmentVariable("RABBIMQ_HOST") ?? throw new ConfigurationErrorsException("A variável de amibente RABBIMQ_HOST não pode ser nula.");  
        public static string RABBIMQ_USERNAME = Environment.GetEnvironmentVariable("RABBIMQ_USERNAME") ?? throw new ConfigurationErrorsException("A variável de amibente RABBIMQ_USERNAME não pode ser nula.");
        public static string RABBIMQ_PASSWORD = Environment.GetEnvironmentVariable("RABBIMQ_PASSWORD") ?? throw new ConfigurationErrorsException("A variável de amibente RABBIMQ_PASSWORD não pode ser nula.");
        public static string QUEUE_CREATE_ECOMMERCE_TICKET_NAME = Environment.GetEnvironmentVariable("QUEUE_CREATE_ECOMMERCE_TICKET_NAME") ?? throw new ConfigurationErrorsException("A variável de amibente QUEUE_NAME não pode ser nula.");
    }
}
