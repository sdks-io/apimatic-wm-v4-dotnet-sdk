using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Cumulative valid tracking rate trend
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CumulativeRateTrend>))]
public sealed record CumulativeRateTrend : OpenStringEnum<CumulativeRateTrend>
{
    private CumulativeRateTrend(string value) : base(value)
    {
    }

    public static readonly CumulativeRateTrend GreenUp = new("GREEN_UP");

    public static readonly CumulativeRateTrend Green = new("GREEN");

    public static readonly CumulativeRateTrend GreenDown = new("GREEN_DOWN");

    public static readonly CumulativeRateTrend YellowUp = new("YELLOW_UP");

    public static readonly CumulativeRateTrend Yellow = new("YELLOW");

    public static readonly CumulativeRateTrend YellowDown = new("YELLOW_DOWN");

    public static readonly CumulativeRateTrend RedUp = new("RED_UP");

    public static readonly CumulativeRateTrend Red = new("RED");

    public static readonly CumulativeRateTrend RedDown = new("RED_DOWN");

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
