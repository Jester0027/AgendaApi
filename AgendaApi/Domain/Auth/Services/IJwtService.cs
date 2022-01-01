namespace AgendaApi.Domain.Auth.Services
{
    public interface IJwtService<in T>
    {
        string Sign(T item);
        bool Validate(string token);
    }
}