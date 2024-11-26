namespace FluentScenario.Tests;

[UnitTest]
public class RunnerContextTests
{
    [Fact]
    public void GivenSetContextData_WhenGetContextData_ThenShouldReturnData()
    {
        // arrange
        var output = Substitute.For<IScenarioOutput>();
        var context = ScenarioRunner.Create(output);

        // act
        context.SetContextData("key", "value");

        // assert
        context.GetContextData<string>("key").Should().Be("value");
    }

    [Fact]
    public void GivenSetContextData_WhenReplacingData_ThenShouldReturnNewData()
    {
        // arrange
        var output = Substitute.For<IScenarioOutput>();
        var context = ScenarioRunner.Create(output);

        // act
        context.SetContextData("key", "value");
        context.SetContextData("key", "new_value");

        // assert
        context.GetContextData<string>("key").Should().Be("new_value");
    }

    [Fact]
    public void GivenGetContextData_WhenNotExistantKey_ThenShouldThrowException()
    {
        // arrange
        var output = Substitute.For<IScenarioOutput>();
        var context = ScenarioRunner.Create(output);

        // act
        var action = () => context.GetContextData<string>("key");

        // assert
        action.Should().Throw<KeyNotFoundException>()
            .WithMessage($"The context data with key key was not found.");
    }
}
