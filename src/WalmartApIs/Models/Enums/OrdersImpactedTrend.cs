using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Impacted orders trend
/// </summary>
[JsonConverter(typeof(StringEnumConverter<OrdersImpactedTrend>))]
public sealed record OrdersImpactedTrend : OpenStringEnum<OrdersImpactedTrend>
{
    private OrdersImpactedTrend(string value) : base(value)
    {
    }

    public static readonly OrdersImpactedTrend GreenUp = new("GREEN_UP");

    public static readonly OrdersImpactedTrend Green = new("GREEN");

    public static readonly OrdersImpactedTrend GreenDown = new("GREEN_DOWN");

    public static readonly OrdersImpactedTrend YellowUp = new("YELLOW_UP");

    public static readonly OrdersImpactedTrend Yellow = new("YELLOW");

    public static readonly OrdersImpactedTrend YellowDown = new("YELLOW_DOWN");

    public static readonly OrdersImpactedTrend RedUp = new("RED_UP");

    public static readonly OrdersImpactedTrend Red = new("RED");

    public static readonly OrdersImpactedTrend RedDown = new("RED_DOWN");

    public TResult Match<TResult>(Func<TResult> onGreenUp,
        Func<TResult> onGreen,
        Func<TResult> onGreenDown,
        Func<TResult> onYellowUp,
        Func<TResult> onYellow,
        Func<TResult> onYellowDown,
        Func<TResult> onRedUp,
        Func<TResult> onRed,
        Func<TResult> onRedDown,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == GreenUp => onGreenUp(),
            _ when this == Green => onGreen(),
            _ when this == GreenDown => onGreenDown(),
            _ when this == YellowUp => onYellowUp(),
            _ when this == Yellow => onYellow(),
            _ when this == YellowDown => onYellowDown(),
            _ when this == RedUp => onRedUp(),
            _ when this == Red => onRed(),
            _ when this == RedDown => onRedDown(),
            _ => otherwise(Value)
        };

    public void Match(Action onGreenUp,
        Action onGreen,
        Action onGreenDown,
        Action onYellowUp,
        Action onYellow,
        Action onYellowDown,
        Action onRedUp,
        Action onRed,
        Action onRedDown,
        Action<string> otherwise)
    {
        if (this == GreenUp) onGreenUp();
        else if (this == Green) onGreen();
        else if (this == GreenDown) onGreenDown();
        else if (this == YellowUp) onYellowUp();
        else if (this == Yellow) onYellow();
        else if (this == YellowDown) onYellowDown();
        else if (this == RedUp) onRedUp();
        else if (this == Red) onRed();
        else if (this == RedDown) onRedDown();
        else otherwise(Value);
    }
}
