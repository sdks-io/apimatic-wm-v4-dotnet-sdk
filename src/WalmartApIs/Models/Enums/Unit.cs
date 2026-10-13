using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Unit>))]
public sealed record Unit : OpenStringEnum<Unit>
{
    private Unit(string value) : base(value)
    {
    }

    public static readonly Unit Inches = new("inches");

    public static readonly Unit Centimeters = new("centimeters");

    public TResult Match<TResult>(Func<TResult> onInches,
        Func<TResult> onCentimeters,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Inches => onInches(),
            _ when this == Centimeters => onCentimeters(),
            _ => otherwise(Value)
        };

    public void Match(Action onInches, Action onCentimeters, Action<string> otherwise)
    {
        if (this == Inches) onInches();
        else if (this == Centimeters) onCentimeters();
        else otherwise(Value);
    }
}
