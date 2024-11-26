using System.Runtime.CompilerServices;

namespace DrifterApps.Seeds.FluentScenario;

internal sealed partial class ScenarioRunner
{
    /// <inheritdoc/>
    public IScenarioRunner And(Action<IStepRunner> step)
    {
        ArgumentNullException.ThrowIfNull(step);

        var previousCommand = _steps.LastOrDefault();

        return previousCommand?.Command switch
        {
            nameof(Given) => Given(step),
            nameof(When) => When(step),
            nameof(Then) => Then(step),
            _ => Given(step)
        };
    }

    /// <inheritdoc/>
    public IScenarioRunner And(string description, Action step)
    {
        var previousCommand = _steps.LastOrDefault();

        return string.IsNullOrWhiteSpace(previousCommand?.Command)
            ? Given(description, step)
            : previousCommand.Command switch
            {
                nameof(Given) => Given(description, step),
                nameof(When) => When(description, step),
                nameof(Then) => Then(description, step),
                _ => Given(description, step)
            };
    }

    /// <inheritdoc/>
    public IScenarioRunner And(string description, Func<Task> step)
    {
        var previousCommand = _steps.LastOrDefault();

        return previousCommand?.Command switch
        {
            nameof(Given) => Given(description, step),
            nameof(When) => When(description, step),
            nameof(Then) => Then(description, step),
            _ => Given(description, step)
        };
    }

    /// <inheritdoc/>
    public IScenarioRunner And<T>(string description, Action<Ensure<T>> step)
    {
        var previousCommand = _steps.LastOrDefault();

        return string.IsNullOrWhiteSpace(previousCommand?.Command)
            ? Given(description, step)
            : previousCommand.Command switch
            {
                nameof(Given) => Given(description, step),
                nameof(When) => When(description, step),
                nameof(Then) => Then(description, step),
                _ => Given(description, step)
            };
    }

    /// <inheritdoc/>
    public IScenarioRunner And<T>(string description, Func<T> step)
    {
        var previousCommand = _steps.LastOrDefault();

        return previousCommand?.Command switch
        {
            nameof(Given) => Given(description, step),
            nameof(When) => When(description, step),
            nameof(Then) => Then(description, step),
            _ => Given(description, step)
        };
    }

    /// <inheritdoc/>
    public IScenarioRunner And<T>(string description, Func<Task<T>> step)
    {
        var previousCommand = _steps.LastOrDefault();

        return previousCommand?.Command switch
        {
            nameof(Given) => Given(description, step),
            nameof(When) => When(description, step),
            nameof(Then) => Then(description, step),
            _ => Given(description, step)
        };
    }

    /// <inheritdoc/>
    public IScenarioRunner And<T, T2>(string description, Func<Ensure<T>, T2> step)
    {
        var previousCommand = _steps.LastOrDefault();

        return previousCommand?.Command switch
        {
            nameof(Given) => Given(description, step),
            nameof(When) => When(description, step),
            nameof(Then) => Then(description, step),
            _ => Given(description, step)
        };
    }

    /// <inheritdoc/>
    public IScenarioRunner And<T, T2>(string description, Func<Ensure<T>, Task<T2>> step)
    {
        var previousCommand = _steps.LastOrDefault();

        return previousCommand?.Command switch
        {
            nameof(Given) => Given(description, step),
            nameof(When) => When(description, step),
            nameof(Then) => Then(description, step),
            _ => Given(description, step)
        };
    }

    /// <inheritdoc/>
    public IScenarioRunner And<T>(string description, Func<Ensure<T>, Task> step)
    {
        var previousCommand = _steps.LastOrDefault();

        return previousCommand?.Command switch
        {
            nameof(Given) => Given(description, step),
            nameof(When) => When(description, step),
            nameof(Then) => Then(description, step),
            _ => Given(description, step)
        };
    }

    /// <inheritdoc/>
    public IScenarioRunner And(Action step, [CallerMemberName] string description = "")
        => And(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner And(Func<Task> step, [CallerMemberName] string description = "")
        => And(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner And<T>(Action<Ensure<T>> step, [CallerMemberName] string description = "")
        => And(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner And<T>(Func<T> step, [CallerMemberName] string description = "")
        => And(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner And<T>(Func<Task<T>> step, [CallerMemberName] string description = "")
        => And(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner And<T>(Func<Ensure<T>, Task> step, [CallerMemberName] string description = "")
        => And(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner And<T, T2>(Func<Ensure<T>, T2> step, [CallerMemberName] string description = "")
        => And(CamelToSentence(description), step);

    /// <inheritdoc/>
    public IScenarioRunner And<T, T2>(Func<Ensure<T>, Task<T2>> step, [CallerMemberName] string description = "")
        => And(CamelToSentence(description), step);
}
