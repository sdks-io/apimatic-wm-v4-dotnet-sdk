using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// ISO 8601 duration for schedule recurrence
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Period>))]
public sealed record Period : OpenStringEnum<Period>
{
    private Period(string value) : base(value)
    {
    }

    public static readonly Period Pt5M = new("PT5M");

    public static readonly Period Pt15M = new("PT15M");

    public static readonly Period Pt30M = new("PT30M");

    public static readonly Period P1D = new("P1D");

    public static readonly Period P2D = new("P2D");

    public static readonly Period P3D = new("P3D");

    public static readonly Period Pt1H = new("PT1H");

    public static readonly Period P7D = new("P7D");

    public static readonly Period P14D = new("P14D");

    public static readonly Period P15D = new("P15D");

    public static readonly Period P18D = new("P18D");

    public static readonly Period P30D = new("P30D");

    public TResult Match<TResult>(Func<TResult> onPt5M,
        Func<TResult> onPt15M,
        Func<TResult> onPt30M,
        Func<TResult> onP1D,
        Func<TResult> onP2D,
        Func<TResult> onP3D,
        Func<TResult> onPt1H,
        Func<TResult> onP7D,
        Func<TResult> onP14D,
        Func<TResult> onP15D,
        Func<TResult> onP18D,
        Func<TResult> onP30D,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Pt5M => onPt5M(),
            _ when this == Pt15M => onPt15M(),
            _ when this == Pt30M => onPt30M(),
            _ when this == P1D => onP1D(),
            _ when this == P2D => onP2D(),
            _ when this == P3D => onP3D(),
            _ when this == Pt1H => onPt1H(),
            _ when this == P7D => onP7D(),
            _ when this == P14D => onP14D(),
            _ when this == P15D => onP15D(),
            _ when this == P18D => onP18D(),
            _ when this == P30D => onP30D(),
            _ => otherwise(Value)
        };

    public void Match(Action onPt5M,
        Action onPt15M,
        Action onPt30M,
        Action onP1D,
        Action onP2D,
        Action onP3D,
        Action onPt1H,
        Action onP7D,
        Action onP14D,
        Action onP15D,
        Action onP18D,
        Action onP30D,
        Action<string> otherwise)
    {
        if (this == Pt5M) onPt5M();
        else if (this == Pt15M) onPt15M();
        else if (this == Pt30M) onPt30M();
        else if (this == P1D) onP1D();
        else if (this == P2D) onP2D();
        else if (this == P3D) onP3D();
        else if (this == Pt1H) onPt1H();
        else if (this == P7D) onP7D();
        else if (this == P14D) onP14D();
        else if (this == P15D) onP15D();
        else if (this == P18D) onP18D();
        else if (this == P30D) onP30D();
        else otherwise(Value);
    }
}
