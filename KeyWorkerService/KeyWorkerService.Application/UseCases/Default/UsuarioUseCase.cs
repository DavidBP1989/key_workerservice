using KeyWorkerService.Domain.Abstractions;
using KeyWorkerService.Domain.Abstractions.Default;

namespace KeyWorkerService.Application.UseCases.Default
{
    public class UsuarioUseCase : IUsuario
    {
        private readonly ILoggerAdapter<UsuarioUseCase> _logger;
        private readonly IServiceLocator _service;
        public UsuarioUseCase(ILoggerAdapter<UsuarioUseCase> looger, IServiceLocator service)
        {
            _logger = looger;
            _service = service;
        }

        public async Task DoWork()
        {
            var repository = _service.Get<IRequestUsuarioRepository>();
            var usuarios = await repository.GetAll();

            _logger.LogInformation($"total usuarios: {usuarios.Count()}");
        }
    }
}
