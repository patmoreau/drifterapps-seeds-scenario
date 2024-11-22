using System.Runtime.CompilerServices;

namespace DrifterApps.Seeds.Scenario;

internal sealed partial class ScenarioRunner
{
    /// <inheritdoc/>
    public IScenarioRunner When(Action<IStepRunner> step)
    {
        ArgumentNullException.ThrowIfNull(step);

        _stepCommand = nameof(When);

        step.Invoke(this);

        return this;
    }

    /// <inheritdoc/>
    public IScenarioRunner When(string description, Action step) =>
        AddStep(StepDefinition.Create(nameof(When), description, step));

    /// <inheritdoc/>
    public IScenarioRunner When(string description, Func<Task> step) =>
        AddStep(StepDefinition.Create(nameof(When), description, step));

    /// <inheritdoc/>
    public IScenarioRunner When<T>(string description, Action<Ensure<T>> step) =>
        AddStep(StepDefinition.Create(nameof(When), description, step));

    /// <inheritdoc/>
    public IScenarioRunner When<T>(string description, Func<T> step) =>
        AddStep(StepDefinition.Create(nameof(When), description, step));

    /// <inheritdoc/>
    public IScenarioRunner When<T>(string description, Func<Task<T>> step) =>
        AddStep(StepDefinition.Create(nameof(When), description, step));

    /// <inheritdoc/>
    public IScenarioRunner When<T, T2>(string description, Func<Ensure<T>, T2> step) =>
        AddStep(StepDefinition.Create(nameof(When), description, step));

    /// <inheritdoc/>
    public IScenarioRunner When<T, T2>(string description, Func<Ensure<T>, Task<T2>> step) =>
        AddStep(StepDefinition.Create(nameof(When), description, step));

    /// <inheritdoc/>
    public IScenarioRunner When<T>(string description, Func<Ensure<T>, Task> step) =>
        AddStep(StepDefinition.Create(nameof(When), description, step));

    /// <inheritdoc/>
    public IScenarioRunner When(Action step, [CallerMemberName] string description = "") =>
        When(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner When(Func<Task> step, [CallerMemberName] string description = "") =>
        When(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner When<T>(Action<Ensure<T>> step, [CallerMemberName] string description = "") =>
        When(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner When<T>(Func<T> step, [CallerMemberName] string description = "") =>
        When(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner When<T>(Func<Task<T>> step, [CallerMemberName] string description = "") =>
        When(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner When<T>(Func<Ensure<T>, Task> step, [CallerMemberName] string description = "") =>
        When(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner When<T, T2>(Func<Ensure<T>, T2> step, [CallerMemberName] string description = "") =>
        When(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner When<T, T2>(Func<Ensure<T>, Task<T2>> step, [CallerMemberName] string description = "") =>
        When(CamelToSentence(description), step);
}
