using System.Diagnostics.CodeAnalysis;

namespace DrifterApps.Seeds.Scenario;

public readonly struct Ensure<TValue> : IEquatable<Ensure<TValue>>
{
    private Ensure(TValue? value)
    {
        Value = value!;
        IsValid = value is not null || IsNullable;
    }

    public bool IsNullable => Nullable.GetUnderlyingType(typeof(TValue)) is not null;

    [MemberNotNullWhen(true, nameof(Value))]
    public bool IsValid { get; }

    public TValue Value { get; }

    public override string ToString() => Value?.ToString() ?? "invalid value";

    public override bool Equals(object? obj) => IsNullable && Value is null ? obj is null : Value!.Equals(obj);

    public bool Equals(Ensure<TValue> other) =>
        IsNullable && Value is null ? other.Value is null : Value!.Equals(other.Value);

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;

    public static bool operator ==(Ensure<TValue> left, Ensure<TValue> right) => left.Equals(right);

    public static bool operator !=(Ensure<TValue> left, Ensure<TValue> right) => !(left == right);

    public static Ensure<TValue> From(object? value) => new(value is TValue typedValue ? typedValue : default);
}
