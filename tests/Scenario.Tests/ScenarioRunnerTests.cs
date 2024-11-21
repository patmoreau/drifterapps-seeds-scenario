namespace Scenario.Tests;

[UnitTest]
public class ScenarioRunnerTests(ITestOutputHelper testOutputHelper)
{
    private readonly Faker _faker = new();

    [Fact]
    public async Task GivenAction_WhenRunAsync_ThenShouldRunSteps()
    {
        var sut = ScenarioRunner.Create("Testing Action Scenario", testOutputHelper)
            .Given("Task 1: Given Action", () => { })
            .And("Task 2: And Action", () => { })
            .When("Task 3: When Action", () => { })
            .And("Task 4: And Action", () => { })
            .Then("Task 5: Then Action", () => { true.Should().BeTrue(); })
            .And("Task 6: And Action", () => { true.Should().BeTrue(); });

        await ((ScenarioRunner) sut).PlayAsync();
    }

    [Fact]
    public async Task GivenFuncOfT_WhenRunAsync_ThenShouldRunSteps()
    {
        var initial = _faker.Random.Int();
        var sut = ScenarioRunner.Create("Testing Action Scenario", testOutputHelper)
            .Given("Task 0: Given Func<T>", () => initial)
            .Given("Task 1: Given Func<T>", (Ensure<int> number) => number.Value + 10)
            .And("Task 2: And Func<T>", (Ensure<int> number) => number.Value + 10)
            .When("Task 3: When Func<T>", (Ensure<int> number) => number.Value + 10)
            .And("Task 4: And Func<T>", (Ensure<int> number) => number.Value + 10)
            .Then("Task 5: Then Func<T>", (Ensure<int> number) =>
            {
                _ = number.Value.Should().Be(initial + 40);
                return number.Value + 10;
            })
            .And("Task 6: And Func<T>", (Ensure<int> number) =>
            {
                number.Should().BeValid().And.Be(initial + 50);
                return number.Value + 10;
            });

        await ((ScenarioRunner) sut).PlayAsync();
    }
}
