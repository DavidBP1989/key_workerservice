using KeyWorkerService.Application.UseCases.Local;
using KeyWorkerService.Domain.Abstractions;

namespace KeyWorkerService.Application.Services
{
    public class EntryPointService : IEntryPointService
    {
        private readonly IUsuario _usuario;
        public EntryPointService(IUsuario usuario)
        {
            _usuario = usuario;
        }

        public Task AnotherTask()
        {
            throw new NotImplementedException();
        }

        public async Task LoadCUtoQS(int delay, CancellationToken cancellationToken)
        {
            await _usuario.DoWork();
            await Task.Delay(delay, cancellationToken);
        }
    }
}
