namespace TemporalDemo;

public class CommandService
{
    public Task ExecuteAsync<TCommand>(TCommand command)
        where TCommand : ICommand<TCommand>
    {
        Console.WriteLine($"Running command {typeof(TCommand)}");
        return Task.CompletedTask;
    }
}
