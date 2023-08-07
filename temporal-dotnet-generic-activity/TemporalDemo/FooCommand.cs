namespace TemporalDemo;

public record FooCommand(string Foo) : ICommand<FooCommand>;