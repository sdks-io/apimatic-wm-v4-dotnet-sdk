using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FulfillmentOption>))]
public sealed record FulfillmentOption : OpenStringEnum<FulfillmentOption>
{
    private FulfillmentOption(string value) : base(value)
    {
    }

    public static readonly FulfillmentOption S2H = new("S2H");

    public static readonly FulfillmentOption S2S = new("S2S");

    public static readonly FulfillmentOption PickupToday = new("PICKUP_TODAY");

    public TResult Match<TResult>(Func<TResult> onS2H,
        Func<TResult> onS2S,
        Func<TResult> onPickupToday,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == S2H => onS2H(),
            _ when this == S2S => onS2S(),
            _ when this == PickupToday => onPickupToday(),
            _ => otherwise(Value)
        };

    public void Match(Action onS2H, Action onS2S, Action onPickupToday, Action<string> otherwise)
    {
        if (this == S2H) onS2H();
        else if (this == S2S) onS2S();
        else if (this == PickupToday) onPickupToday();
        else otherwise(Value);
    }
}
