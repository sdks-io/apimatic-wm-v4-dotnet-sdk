using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// shipping methods used to calculate these metrics
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ShippingMethod>))]
public sealed record ShippingMethod : OpenStringEnum<ShippingMethod>
{
    private ShippingMethod(string value) : base(value)
    {
    }

    public static readonly ShippingMethod AllMethods = new("ALL_METHODS");

    public static readonly ShippingMethod TwoDay = new("TWO_DAY");

    public static readonly ShippingMethod OneDay = new("ONE_DAY");

    public TResult Match<TResult>(Func<TResult> onAllMethods,
        Func<TResult> onTwoDay,
        Func<TResult> onOneDay,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == AllMethods => onAllMethods(),
            _ when this == TwoDay => onTwoDay(),
            _ when this == OneDay => onOneDay(),
            _ => otherwise(Value)
        };

    public void Match(Action onAllMethods, Action onTwoDay, Action onOneDay, Action<string> otherwise)
    {
        if (this == AllMethods) onAllMethods();
        else if (this == TwoDay) onTwoDay();
        else if (this == OneDay) onOneDay();
        else otherwise(Value);
    }
}
