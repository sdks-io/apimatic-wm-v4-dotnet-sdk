using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates whether the item is available for shipping now, or on a known or an unknown date in the future.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<AvailabilityType>))]
public sealed record AvailabilityType : OpenStringEnum<AvailabilityType>
{
    private AvailabilityType(string value) : base(value)
    {
    }

    public static readonly AvailabilityType Now = new("NOW");

    public static readonly AvailabilityType FutureWithoutDate = new("FUTURE_WITHOUT_DATE");

    public static readonly AvailabilityType FutureWithDate = new("FUTURE_WITH_DATE");

    public TResult Match<TResult>(Func<TResult> onNow,
        Func<TResult> onFutureWithoutDate,
        Func<TResult> onFutureWithDate,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Now => onNow(),
            _ when this == FutureWithoutDate => onFutureWithoutDate(),
            _ when this == FutureWithDate => onFutureWithDate(),
            _ => otherwise(Value)
        };

    public void Match(Action onNow, Action onFutureWithoutDate, Action onFutureWithDate, Action<string> otherwise)
    {
        if (this == Now) onNow();
        else if (this == FutureWithoutDate) onFutureWithoutDate();
        else if (this == FutureWithDate) onFutureWithDate();
        else otherwise(Value);
    }
}
