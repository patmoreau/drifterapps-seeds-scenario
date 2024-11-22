using System.Runtime.CompilerServices;

namespace DrifterApps.Seeds.Scenario;

internal sealed partial class ScenarioRunner
{
    /// <inheritdoc/>
    public IScenarioRunner Given(Action<IStepRunner> step)
    {
        ArgumentNullException.ThrowIfNull(step);

        _stepCommand = nameof(Given);

        step.Invoke(this);

        return this;
    }

    /// <inheritdoc/>
    public IScenarioRunner Given(string description, Action step) =>
        AddStep(StepDefinition.Create(nameof(Given), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Given(string description, Func<Task> step) =>
        AddStep(StepDefinition.Create(nameof(Given), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Given<T>(string description, Action<Ensure<T>> step) =>
        AddStep(StepDefinition.Create(nameof(Given), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Given<T>(string description, Func<T> step) =>
        AddStep(StepDefinition.Create(nameof(Given), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Given<T>(string description, Func<Task<T>> step) =>
        AddStep(StepDefinition.Create(nameof(Given), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Given<T>(string description, Func<Ensure<T>, Task> step) =>
        AddStep(StepDefinition.Create(nameof(Given), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Given<T, T2>(string description, Func<Ensure<T>, T2> step) =>
        AddStep(StepDefinition.Create(nameof(Given), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Given<T, T2>(string description, Func<Ensure<T>, Task<T2>> step) =>
        AddStep(StepDefinition.Create(nameof(Given), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Given(Action step, [CallerMemberName] string description = "") =>
        Given(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Given(Func<Task> step, [CallerMemberName] string description = "") =>
        Given(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Given<T>(Action<Ensure<T>> step, [CallerMemberName] string description = "") =>
        Given(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Given<T>(Func<T> step, [CallerMemberName] string description = "") =>
        Given(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Given<T>(Func<Task<T>> step, [CallerMemberName] string description = "") =>
        Given(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Given<T>(Func<Ensure<T>, Task> step, [CallerMemberName] string description = "") =>
        Given(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Given<T, T2>(Func<Ensure<T>, T2> step, [CallerMemberName] string description = "") =>
        Given(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Given<T, T2>(Func<Ensure<T>, Task<T2>> step, [CallerMemberName] string description = "") =>
        Given(CamelToSentence(description), step);
}
