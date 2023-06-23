using KeyWorkerService.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace KeyWorkerService.Infrastructure
{
    public class ServiceScopeFactoryLocator : IServiceLocator
    {
        private readonly IServiceScopeFactory _factory;
        private IServiceScope? _scope;
        public ServiceScopeFactoryLocator(IServiceScopeFactory factory)
        {
            _factory = factory;
        }

        public T Get<T>()
        {
            _scope ??= _factory.CreateScope();
            return _scope.ServiceProvider.GetService<T>();
        }

        public void Dispose()
        {
            _scope?.Dispose();
            _scope = null;
        }
    }
}
