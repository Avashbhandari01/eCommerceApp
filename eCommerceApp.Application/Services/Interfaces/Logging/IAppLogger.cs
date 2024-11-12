namespace eCommerceApp.Application.Services.Interfaces.Logging
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message);

        void LogError(Exception ex, string message);

        void LogWarning(string message);
    }
}
