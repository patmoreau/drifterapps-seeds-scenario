using System.Runtime.CompilerServices;

namespace DrifterApps.Seeds.FluentScenario;

/// <summary>
/// Interface for running steps in a scenario.
/// </summary>
public interface IStepRunner : IRunnerContext
{
    /// <summary>
    /// Executes a step with a description and an action.
    /// </summary>
    /// <param name="description">The description of the step.</param>
    /// <param name="stepExecution">The action to execute.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute(string description, Action stepExecution);

    /// <summary>
    /// Executes a step with a description and an asynchronous function.
    /// </summary>
    /// <param name="description">The description of the step.</param>
    /// <param name="stepExecution">The asynchronous function to execute.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute(string description, Func<Task> stepExecution);

    /// <summary>
    /// Executes a step with a description and an action that ensures a condition.
    /// </summary>
    /// <typeparam name="T">The type of the condition to ensure.</typeparam>
    /// <param name="description">The description of the step.</param>
    /// <param name="stepExecution">The action to execute.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute<T>(string description, Action<Ensure<T>> stepExecution);

    /// <summary>
    /// Executes a step with a description and a function.
    /// </summary>
    /// <typeparam name="T">The return type of the function.</typeparam>
    /// <param name="description">The description of the step.</param>
    /// <param name="stepExecution">The function to execute.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute<T>(string description, Func<T> stepExecution);

    /// <summary>
    /// Executes a step with a description and an asynchronous function.
    /// </summary>
    /// <typeparam name="T">The return type of the asynchronous function.</typeparam>
    /// <param name="description">The description of the step.</param>
    /// <param name="stepExecution">The asynchronous function to execute.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute<T>(string description, Func<Task<T>> stepExecution);

    /// <summary>
    /// Executes a step with a description and an asynchronous function that ensures a condition.
    /// </summary>
    /// <typeparam name="T">The type of the condition to ensure.</typeparam>
    /// <param name="description">The description of the step.</param>
    /// <param name="stepExecution">The asynchronous function to execute.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute<T>(string description, Func<Ensure<T>, Task> stepExecution);

    /// <summary>
    /// Executes a step with a description and a function that takes an input and returns a result.
    /// </summary>
    /// <typeparam name="T">The type of the input.</typeparam>
    /// <typeparam name="T2">The type of the result.</typeparam>
    /// <param name="description">The description of the step.</param>
    /// <param name="stepExecution">The function to execute.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute<T, T2>(string description, Func<Ensure<T>, T2> stepExecution);

    /// <summary>
    /// Executes a step with a description and an asynchronous function that takes an input and returns a result.
    /// </summary>
    /// <typeparam name="T">The type of the input.</typeparam>
    /// <typeparam name="T2">The type of the result.</typeparam>
    /// <param name="description">The description of the step.</param>
    /// <param name="stepExecution">The asynchronous function to execute.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute<T, T2>(string description, Func<Ensure<T>, Task<T2>> stepExecution);

    /// <summary>
    /// Executes a step with an action and an optional description.
    /// </summary>
    /// <param name="stepExecution">The action to execute.</param>
    /// <param name="description">The optional description of the step.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute(Action stepExecution, [CallerMemberName] string description = "");

    /// <summary>
    /// Executes a step with an asynchronous function and an optional description.
    /// </summary>
    /// <param name="stepExecution">The asynchronous function to execute.</param>
    /// <param name="description">The optional description of the step.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute(Func<Task> stepExecution, [CallerMemberName] string description = "");

    /// <summary>
    /// Executes a step with an action that ensures a condition and an optional description.
    /// </summary>
    /// <typeparam name="T">The type of the condition to ensure.</typeparam>
    /// <param name="stepExecution">The action to execute.</param>
    /// <param name="description">The optional description of the step.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute<T>(Action<Ensure<T>> stepExecution, [CallerMemberName] string description = "");

    /// <summary>
    /// Executes a step with a function and an optional description.
    /// </summary>
    /// <typeparam name="T">The return type of the function.</typeparam>
    /// <param name="stepExecution">The function to execute.</param>
    /// <param name="description">The optional description of the step.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute<T>(Func<T> stepExecution, [CallerMemberName] string description = "");

    /// <summary>
    /// Executes a step with an asynchronous function and an optional description.
    /// </summary>
    /// <typeparam name="T">The return type of the asynchronous function.</typeparam>
    /// <param name="stepExecution">The asynchronous function to execute.</param>
    /// <param name="description">The optional description of the step.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute<T>(Func<Task<T>> stepExecution, [CallerMemberName] string description = "");

    /// <summary>
    /// Executes a step with an asynchronous function that ensures a condition and an optional description.
    /// </summary>
    /// <typeparam name="T">The type of the condition to ensure.</typeparam>
    /// <param name="stepExecution">The asynchronous function to execute.</param>
    /// <param name="description">The optional description of the step.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute<T>(Func<Ensure<T>, Task> stepExecution, [CallerMemberName] string description = "");

    /// <summary>
    /// Executes a step with a function that takes an input and returns a result, with an optional description.
    /// </summary>
    /// <typeparam name="T">The type of the input.</typeparam>
    /// <typeparam name="T2">The type of the result.</typeparam>
    /// <param name="stepExecution">The function to execute.</param>
    /// <param name="description">The optional description of the step.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute<T, T2>(Func<Ensure<T>, T2> stepExecution, [CallerMemberName] string description = "");

    /// <summary>
    /// Executes a step with an asynchronous function that takes an input and returns a result, with an optional description.
    /// </summary>
    /// <typeparam name="T">The type of the input.</typeparam>
    /// <typeparam name="T2">The type of the result.</typeparam>
    /// <param name="stepExecution">The asynchronous function to execute.</param>
    /// <param name="description">The optional description of the step.</param>
    /// <returns>The current instance of <see cref="IStepRunner"/>.</returns>
    IStepRunner Execute<T, T2>(Func<Ensure<T>, Task<T2>> stepExecution, [CallerMemberName] string description = "");
}
