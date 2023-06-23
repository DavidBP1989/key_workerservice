namespace KeyWorkerService.Domain.Abstractions
{
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message, params object[] args);
    }
}
