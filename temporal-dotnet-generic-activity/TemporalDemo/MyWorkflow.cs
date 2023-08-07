using Temporalio.Workflows;

namespace TemporalDemo;

[Workflow]
public class MyWorkflow
{
    private readonly ActivityOptions _defaultActivityOptions = new()
    {
        StartToCloseTimeout = TimeSpan.FromSeconds(10)
    };
    
    [WorkflowRun]
    public async Task RunAsync()
    {
        // Executing a foo command works correctly
        var foo = new FooCommand("Foo");
        await Workflow.ExecuteActivityAsync<MyActivities>(x => x.ExecuteFoo(foo), _defaultActivityOptions);

        // Executing a bar command works correctly
        var bar = new BarCommand("Bar");
        await Workflow.ExecuteActivityAsync<MyActivities>(x => x.ExecuteBar(bar), _defaultActivityOptions);
        
        // Executing either command via a generic activity does not work.
        // The type 'TCommand' is invalid for serialization or deserialization because it is a pointer type, is a ref struct, or contains generic parameters that have not been replaced by specific types.
        await Workflow.ExecuteActivityAsync<MyActivities>(x => x.ExecuteGeneric(bar), _defaultActivityOptions);
    }
}