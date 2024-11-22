using System.Runtime.CompilerServices;

namespace DrifterApps.Seeds.Scenario;

internal sealed partial class ScenarioRunner
{
    /// <inheritdoc/>
    public IStepRunner Execute(string description, Action stepExecution)
    {
        _ = _stepCommand switch
        {
            nameof(Given) => Given(description, stepExecution),
            nameof(When) => When(description, stepExecution),
            nameof(Then) => Then(description, stepExecution),
            _ => Given(description, stepExecution)
        };

        return this;
    }

    /// <inheritdoc/>
    public IStepRunner Execute(string description, Func<Task> stepExecution)
    {
        _ = _stepCommand switch
        {
            nameof(Given) => Given(description, stepExecution),
            nameof(When) => When(description, stepExecution),
            nameof(Then) => Then(description, stepExecution),
            _ => Given(description, stepExecution)
        };

        return this;
    }

    /// <inheritdoc/>
    public IStepRunner Execute<T>(string description, Action<Ensure<T>> stepExecution)
    {
        _ = _stepCommand switch
        {
            nameof(Given) => Given(description, stepExecution),
            nameof(When) => When(description, stepExecution),
            nameof(Then) => Then(description, stepExecution),
            _ => Given(description, stepExecution)
        };

        return this;
    }

    /// <inheritdoc/>
    public IStepRunner Execute<T>(string description, Func<T> stepExecution)
    {
        _ = _stepCommand switch
        {
            nameof(Given) => Given(description, stepExecution),
            nameof(When) => When(description, stepExecution),
            nameof(Then) => Then(description, stepExecution),
            _ => Given(description, stepExecution)
        };

        return this;
    }

    /// <inheritdoc/>
    public IStepRunner Execute<T>(string description, Func<Task<T>> stepExecution)
    {
        _ = _stepCommand switch
        {
            nameof(Given) => Given(description, stepExecution),
            nameof(When) => When(description, stepExecution),
            nameof(Then) => Then(description, stepExecution),
            _ => Given(description, stepExecution)
        };

        return this;
    }

    /// <inheritdoc/>
    public IStepRunner Execute<T>(string description, Func<Ensure<T>, Task> stepExecution)
    {
        _ = _stepCommand switch
        {
            nameof(Given) => Given(description, stepExecution),
            nameof(When) => When(description, stepExecution),
            nameof(Then) => Then(description, stepExecution),
            _ => Given(description, stepExecution)
        };

        return this;
    }

    /// <inheritdoc/>
    public IStepRunner Execute<T, T2>(string description, Func<Ensure<T>, T2> stepExecution)
    {
        _ = _stepCommand switch
        {
            nameof(Given) => Given(description, stepExecution),
            nameof(When) => When(description, stepExecution),
            nameof(Then) => Then(description, stepExecution),
            _ => Given(description, stepExecution)
        };

        return this;
    }

    /// <inheritdoc/>
    public IStepRunner Execute<T, T2>(string description, Func<Ensure<T>, Task<T2>> stepExecution)
    {
        _ = _stepCommand switch
        {
            nameof(Given) => Given(description, stepExecution),
            nameof(When) => When(description, stepExecution),
            nameof(Then) => Then(description, stepExecution),
            _ => Given(description, stepExecution)
        };

        return this;
    }

    /// <inheritdoc/>
    public IStepRunner Execute(Action stepExecution, [CallerMemberName] string description = "")
        => Execute(CamelToSentence(description), stepExecution);

    /// <inheritdoc/>
    public IStepRunner Execute(Func<Task> stepExecution, [CallerMemberName] string description = "")
        => Execute(CamelToSentence(description), stepExecution);

    /// <inheritdoc/>
    public IStepRunner Execute<T>(Action<Ensure<T>> stepExecution, [CallerMemberName] string description = "")
        => Execute(CamelToSentence(description), stepExecution);

    /// <inheritdoc/>
    public IStepRunner Execute<T>(Func<T> stepExecution, [CallerMemberName] string description = "")
        => Execute(CamelToSentence(description), stepExecution);

    /// <inheritdoc/>
    public IStepRunner Execute<T>(Func<Task<T>> stepExecution, [CallerMemberName] string description = "")
        => Execute(CamelToSentence(description), stepExecution);

    /// <inheritdoc/>
    public IStepRunner Execute<T>(Func<Ensure<T>, Task> stepExecution, [CallerMemberName] string description = "")
        => Execute(CamelToSentence(description), stepExecution);

    /// <inheritdoc/>
    public IStepRunner Execute<T, T2>(Func<Ensure<T>, T2> stepExecution, [CallerMemberName] string description = "")
        => Execute(CamelToSentence(description), stepExecution);

    /// <inheritdoc/>
    public IStepRunner Execute<T, T2>(Func<Ensure<T>, Task<T2>> stepExecution,
        [CallerMemberName] string description = "")
        => Execute(CamelToSentence(description), stepExecution);
}
