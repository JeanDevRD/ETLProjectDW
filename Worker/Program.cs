using ETLProject.Infrastructure.Persistence;
using Worker;

var host = Host.CreateDefaultBuilder(args)
    .UseDefaultServiceProvider(options =>
    {
        options.ValidateScopes = false;
    })
    .ConfigureServices((context, services) =>
    {
        services.AddPersistenceLayer(context.Configuration);
        services.AddHostedService<ExtractionWorker>();
    })
    .Build();

host.Run();