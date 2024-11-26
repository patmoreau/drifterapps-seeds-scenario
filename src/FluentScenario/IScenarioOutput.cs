namespace DrifterApps.Seeds.FluentScenario;

/// <summary>
/// Defines the output interface for scenario logging.
/// </summary>
public interface IScenarioOutput
{
    /// <summary>
    /// Writes a message to the output.
    /// </summary>
    /// <param name="message">The message to write.</param>
    void WriteLine(string message);

    /// <summary>
    /// Writes a formatted message to the output.
    /// </summary>
    /// <param name="format">The composite format string.</param>
    /// <param name="args">An array of objects to format.</param>
    void WriteLine(string format, params object[] args);
}
