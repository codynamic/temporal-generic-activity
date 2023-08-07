using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TemporalDemo;
using Temporalio.Client;
using Temporalio.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<CommandService>(_ => new CommandService());
builder.Services.AddTemporalClient("localhost:7233", "default");

builder.Services.
    AddHostedTemporalWorker(
        "localhost:7233",
        "default",
        "default").
    AddScopedActivities<MyActivities>().
    AddWorkflow<MyWorkflow>();

// Run
var host = builder.Build();

var client = host.Services.GetRequiredService<ITemporalClient>();
await client.StartWorkflowAsync<MyWorkflow>(x => x.RunAsync(), new (Guid.NewGuid().ToString("N"), "default"));

await host.RunAsync();