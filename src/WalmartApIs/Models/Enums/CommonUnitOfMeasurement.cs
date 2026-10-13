using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Unit of linear measure.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonUnitOfMeasurement>))]
public sealed record CommonUnitOfMeasurement : OpenStringEnum<CommonUnitOfMeasurement>
{
    private CommonUnitOfMeasurement(string value) : base(value)
    {
    }

    public static readonly CommonUnitOfMeasurement In = new("IN");

    public static readonly CommonUnitOfMeasurement Cm = new("CM");

    public TResult Match<TResult>(Func<TResult> onIn, Func<TResult> onCm, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == In => onIn(),
            _ when this == Cm => onCm(),
            _ => otherwise(Value)
        };

    public void Match(Action onIn, Action onCm, Action<string> otherwise)
    {
        if (this == In) onIn();
        else if (this == Cm) onCm();
        else otherwise(Value);
    }
}
