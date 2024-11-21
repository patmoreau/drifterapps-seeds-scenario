namespace DrifterApps.Seeds.Scenario;

public interface IStepRunner : IRunnerContext
{
    IStepRunner Execute(string description, Action stepExecution);
    IStepRunner Execute(string description, Func<Task> stepExecution);
}
