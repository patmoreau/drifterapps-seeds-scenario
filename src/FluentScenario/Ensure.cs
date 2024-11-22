using System.Diagnostics.CodeAnalysis;

namespace DrifterApps.Seeds.FluentScenario;

/// <summary>
/// Represents a value that can be ensured to be valid or invalid.
/// </summary>
/// <typeparam name="TValue">The type of the value.</typeparam>
public readonly struct Ensure<TValue> : IEquatable<Ensure<TValue>>
{
    private readonly TValue? _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Ensure{TValue}"/> struct.
    /// </summary>
    /// <param name="value">The value to be ensured.</param>
    private Ensure(object? value)
    {
        _value = value is TValue typedValue ? typedValue : default;
        IsValid = value is TValue || (IsNullable && value is null);
    }

    /// <summary>
    /// Gets a value indicating whether the type is nullable.
    /// </summary>
    public bool IsNullable => Nullable.GetUnderlyingType(typeof(TValue)) is not null;

    /// <summary>
    /// Gets a value indicating whether the value is valid.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Value))]
    public bool IsValid { get; }

    /// <summary>
    /// Gets the value if it is valid; otherwise, throws an exception.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the value is not valid.</exception>
    public TValue Value => IsValid ? _value! : throw new InvalidOperationException("Value is not valid.");

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() =>
        IsNullable ? _value?.ToString() ?? "<null>" : _value?.ToString() ?? "invalid value";

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object? obj) => IsNullable && Value is null ? obj is null : Value!.Equals(obj);

    /// <summary>
    /// Determines whether the specified <see cref="Ensure{TValue}"/> is equal to the current <see cref="Ensure{TValue}"/>.
    /// </summary>
    /// <param name="other">The <see cref="Ensure{TValue}"/> to compare with the current <see cref="Ensure{TValue}"/>.</param>
    /// <returns>true if the specified <see cref="Ensure{TValue}"/> is equal to the current <see cref="Ensure{TValue}"/>; otherwise, false.</returns>
    public bool Equals(Ensure<TValue> other) =>
        IsNullable && Value is null ? other.Value is null : Value!.Equals(other.Value);

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <summary>
    /// Determines whether two specified instances of <see cref="Ensure{TValue}"/> are equal.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if the two values are equal; otherwise, false.</returns>
    public static bool operator ==(Ensure<TValue> left, Ensure<TValue> right) => left.Equals(right);

    /// <summary>
    /// Determines whether two specified instances of <see cref="Ensure{TValue}"/> are not equal.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if the two values are not equal; otherwise, false.</returns>
    public static bool operator !=(Ensure<TValue> left, Ensure<TValue> right) => !(left == right);

    /// <summary>
    /// Implicitly converts an <see cref="Ensure{TValue}"/> to its underlying value.
    /// </summary>
    /// <param name="value">The <see cref="Ensure{TValue}"/> instance to convert.</param>
    /// <returns>The underlying value of the <see cref="Ensure{TValue}"/> instance.</returns>
    public static implicit operator TValue(Ensure<TValue> value) => value.Value;

    /// <summary>
    /// Implicitly converts a value to an <see cref="Ensure{TValue}"/> instance.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>An <see cref="Ensure{TValue}"/> instance containing the value.</returns>
    public static implicit operator Ensure<TValue>(TValue value) => From(value);

    /// <summary>
    /// Creates a new instance of <see cref="Ensure{TValue}"/> from the specified value.
    /// </summary>
    /// <param name="value">The value to be ensured.</param>
    /// <returns>A new instance of <see cref="Ensure{TValue}"/>.</returns>
    public static Ensure<TValue> From(object? value) => new(value);

    /// <summary>
    /// Returns the current instance of <see cref="Ensure{TValue}"/>.
    /// </summary>
    /// <returns>The current instance of <see cref="Ensure{TValue}"/>.</returns>
    public Ensure<TValue> ToEnsure() => this;

    /// <summary>
    /// Returns the underlying value of the current <see cref="Ensure{TValue}"/> instance.
    /// </summary>
    /// <returns>The underlying value of the current <see cref="Ensure{TValue}"/> instance.</returns>
    public TValue FromEnsure() => Value;
}
