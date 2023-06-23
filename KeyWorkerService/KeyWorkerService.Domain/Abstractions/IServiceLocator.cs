namespace KeyWorkerService.Domain.Abstractions
{
    public interface IServiceLocator : IDisposable
    {
        T Get<T>();
    }
}
