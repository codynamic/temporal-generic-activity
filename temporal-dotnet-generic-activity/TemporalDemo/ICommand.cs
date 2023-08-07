namespace TemporalDemo;

public interface ICommand<TCommand>
    where TCommand : ICommand<TCommand>
{
    
}