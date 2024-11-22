namespace DrifterApps.Seeds.FluentScenario;

/// <summary>
/// Interface for managing runner context data.
/// </summary>
public interface IRunnerContext
{
    /// <summary>
    /// Sets the context data for a given key.
    /// </summary>
    /// <param name="contextKey">The key for the context data.</param>
    /// <param name="data">The data to be stored in the context.</param>
    void SetContextData(string contextKey, object data);

    /// <summary>
    /// Gets the context data for a given key.
    /// </summary>
    /// <typeparam name="T">The type of the data to be retrieved.</typeparam>
    /// <param name="contextKey">The key for the context data.</param>
    /// <returns>The data associated with the given key.</returns>
    public T GetContextData<T>(string contextKey);
}
