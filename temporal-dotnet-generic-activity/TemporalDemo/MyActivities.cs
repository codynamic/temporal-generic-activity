using Temporalio.Activities;

namespace TemporalDemo;

public class MyActivities
{
    private readonly CommandService _commandService;

    public MyActivities(CommandService commandService)
    {
        _commandService = commandService;
    }

    [Activity]
    public async Task ExecuteFoo(FooCommand command)
    {
        await _commandService.ExecuteAsync(command);
    }
    
    [Activity]
    public async Task ExecuteBar(BarCommand command)
    {
        await _commandService.ExecuteAsync(command);
    }
    
    [Activity]
    public async Task ExecuteGeneric<TCommand>(TCommand command)
        where TCommand : ICommand<TCommand>
    {
        await _commandService.ExecuteAsync(command);
    }
}