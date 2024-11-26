using System.Diagnostics.CodeAnalysis;
using FluentScenario.Tests.Mocks;

namespace FluentScenario.Tests;

[SuppressMessage("Design", "CA1062:Validate arguments of public methods")]
[UnitTest]
public class StepRunnerTests
{
    [Theory]
    [ClassData(typeof(StepRunnerData))]
    public async Task GivenExecute_WhenPlayAsync_ThenShouldRunSteps(string testName, MockScenarioOutput output,
        Action<IStepRunner> step)
    {
        // arrange
        output.Reset();
        var sut = ScenarioRunner.Create("Testing StepRunner Execute", output)
            .Given(step)
            .And(step)
            .When(step)
            .And(step)
            .Then(step)
            .And(step);

        // act
        await sut.PlayAsync();

        // assert
        _ = output.Messages.Should().HaveCount(13).And.ContainInOrder(
            $"{ScenarioRunner.SuccessCheck} SCENARIO for Testing StepRunner Execute",
            TestData.OutputFromExecute,
            $"{ScenarioRunner.SuccessCheck} GIVEN {testName}",
            TestData.OutputFromExecute,
            $"{ScenarioRunner.SuccessCheck} and {testName}",
            TestData.OutputFromExecute,
            $"{ScenarioRunner.SuccessCheck} WHEN {testName}",
            TestData.OutputFromExecute,
            $"{ScenarioRunner.SuccessCheck} and {testName}",
            TestData.OutputFromExecute,
            $"{ScenarioRunner.SuccessCheck} THEN {testName}",
            TestData.OutputFromExecute,
            $"{ScenarioRunner.SuccessCheck} and {testName}"
            );
    }

    [Theory]
    [ClassData(typeof(StepRunnerData))]
    public async Task GivenExecute_WhenAndIsFirst_ThenShouldRunAsGivenSteps(string testName, MockScenarioOutput output,
        Action<IStepRunner> step)
    {
        // arrange
        output.Reset();
        var sut = ScenarioRunner.Create("Testing StepRunner Execute", output)
            .And(step);

        // act
        await sut.PlayAsync();

        // assert
        _ = output.Messages.Should().HaveCount(3).And.ContainInOrder(
            $"{ScenarioRunner.SuccessCheck} SCENARIO for Testing StepRunner Execute",
            TestData.OutputFromExecute,
            $"{ScenarioRunner.SuccessCheck} GIVEN {testName}"
        );
    }

    internal class StepRunnerData : TheoryData<string, MockScenarioOutput, Action<IStepRunner>>
    {
        private readonly MockScenarioOutput _scenarioOutput = new();

        public StepRunnerData()
        {
            AddStep("Execute Action", runner => runner.Execute("Execute Action", TestData.ExecuteAction(_scenarioOutput)));
            AddStep(".ctor", runner => runner.Execute(TestData.ExecuteAction(_scenarioOutput)));
            AddStep("Execute Func<Task>", runner => runner.Execute("Execute Func<Task>", TestData.ExecuteFuncTask(_scenarioOutput)));
            AddStep(".ctor", runner => runner.Execute(TestData.ExecuteFuncTask(_scenarioOutput)));
            AddStep("Execute Action<Ensure<T>>", runner => runner.Execute("Execute Action<Ensure<T>>", TestData.ExecuteActionOfT(_scenarioOutput)));
            AddStep(".ctor", runner => runner.Execute(TestData.ExecuteActionOfT(_scenarioOutput)));
            AddStep("Execute Func<T>", runner => runner.Execute("Execute Func<T>", TestData.ExecuteFuncOfT(_scenarioOutput)));
            AddStep(".ctor", runner => runner.Execute(TestData.ExecuteFuncOfT(_scenarioOutput)));
            AddStep("Execute Func<Task<T>>", runner => runner.Execute("Execute Func<Task<T>>", TestData.ExecuteFuncTaskOfT(_scenarioOutput)));
            AddStep(".ctor", runner => runner.Execute(TestData.ExecuteFuncTaskOfT(_scenarioOutput)));
            AddStep("Execute Func<Ensure<T>, Task>", runner => runner.Execute("Execute Func<Ensure<T>, Task>", TestData.ExecuteFuncTAndTask(_scenarioOutput)));
            AddStep(".ctor", runner => runner.Execute(TestData.ExecuteFuncTAndTask(_scenarioOutput)));
            AddStep("Execute Func<Ensure<T>, T>", runner => runner.Execute("Execute Func<Ensure<T>, T>", TestData.ExecuteFuncTAndT(_scenarioOutput)));
            AddStep(".ctor", runner => runner.Execute(TestData.ExecuteFuncTAndT(_scenarioOutput)));
            AddStep("Execute Func<Ensure<T>, Task<T>>", runner => runner.Execute("Execute Func<Ensure<T>, Task<T>>", TestData.ExecuteFuncTAndTaskOfT(_scenarioOutput)));
            AddStep(".ctor", runner => runner.Execute(TestData.ExecuteFuncTAndTaskOfT(_scenarioOutput)));
        }

        private void AddStep(string name, Action<IStepRunner> step) => Add(name, _scenarioOutput, step);
    }
}
