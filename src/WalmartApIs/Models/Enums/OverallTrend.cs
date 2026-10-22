using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Overall On Time Delivery trand
/// </summary>
[JsonConverter(typeof(StringEnumConverter<OverallTrend>))]
public sealed record OverallTrend : OpenStringEnum<OverallTrend>
{
    private OverallTrend(string value) : base(value)
    {
    }

    public static readonly OverallTrend GreenUp = new("GREEN_UP");

    public static readonly OverallTrend Green = new("GREEN");

    public static readonly OverallTrend GreenDown = new("GREEN_DOWN");

    public static readonly OverallTrend YellowUp = new("YELLOW_UP");

    public static readonly OverallTrend Yellow = new("YELLOW");

    public static readonly OverallTrend YellowDown = new("YELLOW_DOWN");

    public static readonly OverallTrend RedUp = new("RED_UP");

    public static readonly OverallTrend Red = new("RED");

    public static readonly OverallTrend RedDown = new("RED_DOWN");

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
