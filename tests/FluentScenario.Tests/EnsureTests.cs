// ReSharper disable SuspiciousTypeConversion.Global

namespace FluentScenario.Tests;

[UnitTest]
public class EnsureTests
{
    private readonly Faker _faker = new();

    [Fact]
    public void GivenEnsure_WhenNonNullValue_ThenShouldBeValid()
    {
        // arrange
        var value = _faker.Random.Int();

        // act
        var ensure = Ensure<int>.From(value);

        // assert
        ensure.IsValid.Should().BeTrue();
        ensure.IsNullable.Should().BeFalse();
        ensure.Value.Should().Be(value);
    }

    [Fact]
    public void GivenEnsure_WhenNullValue_ThenShouldBeInvalid()
    {
        // arrange
        var ensure = Ensure<string>.From(null);

        // act
        var act = () => _ = ensure.Value;

        // assert
        act.Should().Throw<InvalidOperationException>().WithMessage("Value is not valid.");
        ensure.IsValid.Should().BeFalse();
        ensure.IsNullable.Should().BeFalse();
    }

    [Fact]
    public void GivenEnsure_WhenNullableType_ThenShouldBeValid()
    {
        // arrange
        var ensure = Ensure<int?>.From(null);

        // act

        // assert
        ensure.IsValid.Should().BeTrue();
        ensure.IsNullable.Should().BeTrue();
        ensure.Value.Should().BeNull();
    }

    [Fact]
    public void GivenEquals_WhenValuesAreSame_ThenShouldReturnTrueForEqualValues()
    {
        // arrange
        var value = _faker.Random.Int();
        var ensure1 = Ensure<int>.From(value);
        var ensure2 = Ensure<int>.From(value);

        // act
        var result = ensure1.Equals(ensure2);
        var resultObject = ensure1.Equals((object?)ensure2.Value);
        var resulOperator = ensure1 == ensure2;

        // assert
        result.Should().BeTrue();
        resultObject.Should().BeTrue();
        resulOperator.Should().BeTrue();
    }

    [Fact]
    public void GivenEquals_WhenValuesAreDifferent_ThenShouldReturnFalseForDifferentValues()
    {
        // arrange
        var ensure1 = Ensure<int>.From(_faker.Random.Int());
        var ensure2 = Ensure<int>.From(_faker.Random.Int());

        // act
        var result = ensure1.Equals(ensure2);
        var resultObject = ensure1.Equals((object?)ensure2.Value);
        var resulOperator = ensure1 != ensure2;

        // assert
        result.Should().BeFalse();
        resultObject.Should().BeFalse();
        resulOperator.Should().BeTrue();
    }

    [Fact]
    public void GivenToString_WhenValid_ThenShouldReturnValueString()
    {
        // arrange
        var value = _faker.Random.Int();
        var ensure = Ensure<int>.From(value);

        // act
        var result = ensure.ToString();

        // assert
        result.Should().Be(value.ToString(CultureInfo.InvariantCulture));
    }

    [Fact]
    public void GivenToString_WhenNotValid_ShouldReturnInvalidValueString()
    {
        // arrange
        var ensure = Ensure<string>.From(null);

        // act
        var result = ensure.ToString();

        // assert
        result.Should().Be("invalid value");
    }

    [Fact]
    public void GivenGetHashCode_WhenValid_ThenShouldReturnHashCodeOfValue()
    {
        // arrange
        var value = _faker.Random.Int();
        var ensure = Ensure<int>.From(value);

        // act
        var result = ensure.GetHashCode();

        // assert
        result.Should().Be(value.GetHashCode());
    }

    [Fact]
    public void GivenGetHashCode_WhenNull_ThenShouldReturnZeroForNullValue()
    {
        // arrange
        var ensure = Ensure<string>.From(null);

        // act
        var result = ensure.GetHashCode();

        // assert
        result.Should().Be(0);
    }

    [Fact]
    public void GivenImplicitOperator_WhenValid_ThenShouldReturnUnderlyingValue()
    {
        // arrange
        var value = _faker.Random.Int();
        var ensure = Ensure<int>.From(value);

        // act
        var result = (int)ensure;
        var resultFrom = ensure.FromEnsure();

        // assert
        result.Should().Be(value);
        resultFrom.Should().Be(value);
    }

    [Fact]
    public void GivenImplicitValueOperator_WhenValid_ThenShouldReturnUnderlyingValue()
    {
        // arrange
        var value = _faker.Random.Int();

        // act
        var result = (Ensure<int>)value;
        var resultTo = result.ToEnsure();

        // assert
        result.Should().BeValid().And.HaveValue(value);
        resultTo.Should().BeValid().And.HaveValue(value);
    }
}
