using System.Diagnostics.CodeAnalysis;

namespace FluentScenario.Tests;

[SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out")]
public static class TestData
{
    public const string OutputFromExecute = "Executing...";

    public static Action ExecuteAction(IScenarioOutput scenarioOutput) =>
        () => { scenarioOutput.WriteLine(OutputFromExecute); };

    public static Func<Task> ExecuteFuncTask(IScenarioOutput scenarioOutput) =>
        () => Task.Run(() => { scenarioOutput.WriteLine(OutputFromExecute); });

    public static Action<Ensure<int>> ExecuteActionOfT(IScenarioOutput scenarioOutput) =>
        (Ensure<int> value) => { scenarioOutput.WriteLine(OutputFromExecute); };

    public static Func<int> ExecuteFuncOfT(IScenarioOutput scenarioOutput) =>
        () => { scenarioOutput.WriteLine(OutputFromExecute); return 1; };

    public static Func<Task<int>> ExecuteFuncTaskOfT(IScenarioOutput scenarioOutput) =>
        () => Task.Run(() => { scenarioOutput.WriteLine(OutputFromExecute); return 1; });

    public static Func<Ensure<int>, Task> ExecuteFuncTAndTask(IScenarioOutput scenarioOutput) =>
        (Ensure<int> value) => Task.Run(() => { scenarioOutput.WriteLine(OutputFromExecute); });

    public static Func<Ensure<int>, int> ExecuteFuncTAndT(IScenarioOutput scenarioOutput) =>
        (Ensure<int> value) => { scenarioOutput.WriteLine(OutputFromExecute); return 1; };

    public static Func<Ensure<int>, Task<int>> ExecuteFuncTAndTaskOfT(IScenarioOutput scenarioOutput) =>
        (Ensure<int> value) => Task.Run(() => { scenarioOutput.WriteLine(OutputFromExecute); return 1; });
}
