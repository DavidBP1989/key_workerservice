using KeyWorkerService.Application.UseCases.LoadCUtoQS;
using KeyWorkerService.Domain.Abstractions;

namespace KeyWorkerService.Application.Services
{
    public class EntryPointService : IEntryPointService
    {
        private readonly ILoadCUtoQS _loadCUtoQS;
        public EntryPointService(ILoadCUtoQS loadCUtoQS)
        {
            _loadCUtoQS = loadCUtoQS;
        }

        public Task AnotherTask()
        {
            throw new NotImplementedException();
        }

        public async Task LoadCUtoQS(int delay, CancellationToken cancellationToken)
        {
            await _loadCUtoQS.DoWork();
            await Task.Delay(delay, cancellationToken);
        }
    }
}
