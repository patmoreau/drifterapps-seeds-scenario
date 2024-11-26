using System.Runtime.CompilerServices;

namespace DrifterApps.Seeds.FluentScenario;

internal sealed partial class ScenarioRunner
{
    /// <inheritdoc/>
    public IScenarioRunner Then(Action<IStepRunner> step)
    {
        ArgumentNullException.ThrowIfNull(step);

        _stepCommand = nameof(Then);

        step.Invoke(this);

        return this;
    }

    /// <inheritdoc/>
    public IScenarioRunner Then(string description, Action step) =>
        AddStep(StepDefinition.Create(nameof(Then), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Then(string description, Func<Task> step) =>
        AddStep(StepDefinition.Create(nameof(Then), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Then<T>(string description, Action<Ensure<T>> step) =>
        AddStep(StepDefinition.Create(nameof(Then), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Then<T>(string description, Func<T> step) =>
        AddStep(StepDefinition.Create(nameof(Then), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Then<T>(string description, Func<Task<T>> step) =>
        AddStep(StepDefinition.Create(nameof(Then), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Then<T, T2>(string description, Func<Ensure<T>, T2> step) =>
        AddStep(StepDefinition.Create(nameof(Then), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Then<T, T2>(string description, Func<Ensure<T>, Task<T2>> step) =>
        AddStep(StepDefinition.Create(nameof(Then), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Then<T>(string description, Func<Ensure<T>, Task> step) =>
        AddStep(StepDefinition.Create(nameof(Then), description, step));

    /// <inheritdoc/>
    public IScenarioRunner Then(Action step, [CallerMemberName] string description = "") =>
        Then(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Then(Func<Task> step, [CallerMemberName] string description = "") =>
        Then(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Then<T>(Action<Ensure<T>> step, [CallerMemberName] string description = "") =>
        Then(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Then<T>(Func<T> step, [CallerMemberName] string description = "") =>
        Then(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Then<T>(Func<Task<T>> step, [CallerMemberName] string description = "") =>
        Then(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Then<T>(Func<Ensure<T>, Task> step, [CallerMemberName] string description = "") =>
        Then(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Then<T, T2>(Func<Ensure<T>, T2> step, [CallerMemberName] string description = "") =>
        Then(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner Then<T, T2>(Func<Ensure<T>, Task<T2>> step, [CallerMemberName] string description = "") =>
        Then(CamelToSentence(description), step);
}
