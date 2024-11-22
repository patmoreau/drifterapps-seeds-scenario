namespace DrifterApps.Seeds.FluentScenario;

internal record StepDefinition
{
    private StepDefinition(string command, string description, Func<object?, Task<object?>> step)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentNullException(nameof(description),
                "Please explain your intent by documenting your test.");
        }

        Command = command;
        Description = description;
        Step = step;
    }

    internal string Command { get; }
    internal string Description { get; init; }

    internal Func<object?, Task<object?>> Step { get; }

    internal static StepDefinition Create(string command, string description, Action step) =>
        new(command, description, async _ =>
        {
            await Task.Run(step).ConfigureAwait(false);
            return null;
        });

    internal static StepDefinition Create(string command, string description, Func<Task> step) =>
        new(command, description, async _ =>
        {
            await step().ConfigureAwait(false);
            return null;
        });

    internal static StepDefinition Create<T>(string command, string description, Action<Ensure<T>> step) =>
        new(command, description, async input =>
        {
            await Task.Run(() => step(Ensure<T>.From(input))).ConfigureAwait(false);
            return null;
        });

    internal static StepDefinition Create<T>(string command, string description, Func<T> step) =>
        new(command, description, async _ => await Task.Run(step).ConfigureAwait(false));

    internal static StepDefinition Create<T>(string command, string description, Func<Task<T>> step) =>
        new(command, description, async _ => await step().ConfigureAwait(false));

    internal static StepDefinition Create<T>(string command, string description, Func<Ensure<T>, Task> step) =>
        new(command, description, async input =>
        {
            await step(Ensure<T>.From(input)).ConfigureAwait(false);
            return null;
        });

    internal static StepDefinition Create<T, T2>(string command, string description, Func<Ensure<T>, T2> step) =>
        new(command, description,
            async input => await Task.Run(() => step(Ensure<T>.From(input))).ConfigureAwait(false));

    internal static StepDefinition Create<T, T2>(string command, string description, Func<Ensure<T>, Task<T2>> step) =>
        new(command, description,
            async input => await step(Ensure<T>.From(input)).ConfigureAwait(false));
}
