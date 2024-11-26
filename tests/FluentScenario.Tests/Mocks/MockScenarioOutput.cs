using System.Diagnostics.CodeAnalysis;

namespace FluentScenario.Tests.Mocks;

[SuppressMessage("Maintainability", "CA1515:Consider making public types internal")]
[SuppressMessage("Design", "CA1034:Nested types should not be visible")]
public class MockScenarioOutput : IScenarioOutput
{
    private readonly List<string> _message = [];
    public IReadOnlyList<string> Messages => [.. _message];

    public void WriteLine(string message) => _message.Add(message);

    public void WriteLine(string format, params object[] args) =>
        _message.Add(string.Format(CultureInfo.InvariantCulture, format, args));

    public void Reset() => _message.Clear();
}
