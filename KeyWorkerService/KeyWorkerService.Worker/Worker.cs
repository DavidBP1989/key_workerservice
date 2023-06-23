using KeyWorkerService.Domain.Abstractions;

namespace KeyWorkerService.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEntryPointService _entryPointService;

        public Worker(ILogger<Worker> logger, IEntryPointService entryPointService)
        {
            _logger = logger;
            _entryPointService = entryPointService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ExecuteAsync start");

            while (!stoppingToken.IsCancellationRequested)
            {
                List<Task> tasks = new()
                {
                    _entryPointService.LoadCUtoQS(1000, stoppingToken)
                };

                await Task.WhenAll(tasks);
            }
        }
    }
}