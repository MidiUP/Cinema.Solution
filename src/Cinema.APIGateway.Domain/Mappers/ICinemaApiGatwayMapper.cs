namespace Cinema.APIGateway.Domain.Mappers;

public interface ICinemaApiGatwayMapper<T, I> where T : class where I : class
{
    public static T MapTo(I model);
}
