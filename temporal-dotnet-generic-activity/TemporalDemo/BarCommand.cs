namespace TemporalDemo;

public record BarCommand(string Bar) : ICommand<BarCommand>;