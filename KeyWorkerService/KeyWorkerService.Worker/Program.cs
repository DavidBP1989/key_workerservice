using KeyWorkerService.Worker;
using KeyWorkerService.Infrastructure;
using KeyWorkerService.Domain.Abstractions;
using KeyWorkerService.Application.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
        services.AddSingleton<IServiceLocator, ServiceScopeFactoryLocator>();
        services.AddDbContext(hostContext.Configuration);

        services.AddSingleton<IEntryPointService, EntryPointService>();
        services.AddRepositories();
        services.AddUseCaseServices();
        
        var workerSettings = new WorkerSettings();
        hostContext.Configuration.Bind(nameof(WorkerSettings), workerSettings);
        services.AddSingleton(workerSettings);

        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
