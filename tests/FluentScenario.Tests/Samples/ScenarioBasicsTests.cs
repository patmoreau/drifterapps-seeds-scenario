using Xunit.Abstractions;

namespace FluentScenario.Tests.Samples;

[UnitTest]
public class ScenarioBasicsTests(ITestOutputHelper testOutputHelper)
{
    private readonly IScenarioOutput _scenarioOutput = new SampleScenarioOutput(testOutputHelper);

    [Fact]
    public async Task SimpleScenario()
    {
        int temperatureInside = 0;
        int temperatureOutside = 0;

        await ScenarioRunner.Create("when the weather is too cold", _scenarioOutput)
            .Given("I want to go play outside", () => temperatureInside = 19)
            .When("the temperature is below 0C", () => temperatureOutside = -5)
            .Then("I stay inside if the temperature difference is greater than 20C", () => (temperatureInside - temperatureOutside).Should().BeGreaterThan(20))
            .PlayAsync();
    }
}
