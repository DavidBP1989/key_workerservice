using KeyWorkerService.Domain.Abstractions;

namespace KeyWorkerService.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEntryPointService _entryPointService;
        private readonly WorkerSettings _settings;

        public Worker(ILogger<Worker> logger, IEntryPointService entryPointService, WorkerSettings settings)
        {
            _logger = logger;
            _entryPointService = entryPointService;
            _settings = settings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ExecuteAsync start");

            while (!stoppingToken.IsCancellationRequested)
            {
                List<Task> tasks = new()
                {
                    _entryPointService.LoadCUtoQS(_settings.LoadCUtoQS, stoppingToken)
                };

                await Task.WhenAll(tasks);
            }
        }
    }
}