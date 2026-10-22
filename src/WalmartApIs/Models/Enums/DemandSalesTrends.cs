using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates the months of the year when high demand is observed for the recommended item. The sequence of month is in the decreasing order of the high demand. The values are comma separated.
/// <para>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC | Months of the year. | string |
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<DemandSalesTrends>))]
public sealed record DemandSalesTrends : OpenStringEnum<DemandSalesTrends>
{
    private DemandSalesTrends(string value) : base(value)
    {
    }

    public static readonly DemandSalesTrends Jan = new("JAN");

    public static readonly DemandSalesTrends Feb = new("FEB");

    public static readonly DemandSalesTrends Mar = new("MAR");

    public static readonly DemandSalesTrends Apr = new("APR");

    public static readonly DemandSalesTrends May = new("MAY");

    public static readonly DemandSalesTrends Jun = new("JUN");

    public static readonly DemandSalesTrends Jul = new("JUL");

    public static readonly DemandSalesTrends Aug = new("AUG");

    public static readonly DemandSalesTrends Sep = new("SEP");

    public static readonly DemandSalesTrends Oct = new("OCT");

    public static readonly DemandSalesTrends Nov = new("NOV");

    public static readonly DemandSalesTrends Dec = new("DEC");

    public TResult Match<TResult>(Func<TResult> onJan,
        Func<TResult> onFeb,
        Func<TResult> onMar,
        Func<TResult> onApr,
        Func<TResult> onMay,
        Func<TResult> onJun,
        Func<TResult> onJul,
        Func<TResult> onAug,
        Func<TResult> onSep,
        Func<TResult> onOct,
        Func<TResult> onNov,
        Func<TResult> onDec,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Jan => onJan(),
            _ when this == Feb => onFeb(),
            _ when this == Mar => onMar(),
            _ when this == Apr => onApr(),
            _ when this == May => onMay(),
            _ when this == Jun => onJun(),
            _ when this == Jul => onJul(),
            _ when this == Aug => onAug(),
            _ when this == Sep => onSep(),
            _ when this == Oct => onOct(),
            _ when this == Nov => onNov(),
            _ when this == Dec => onDec(),
            _ => otherwise(Value)
        };

    public void Match(Action onJan,
        Action onFeb,
        Action onMar,
        Action onApr,
        Action onMay,
        Action onJun,
        Action onJul,
        Action onAug,
        Action onSep,
        Action onOct,
        Action onNov,
        Action onDec,
        Action<string> otherwise)
    {
        if (this == Jan) onJan();
        else if (this == Feb) onFeb();
        else if (this == Mar) onMar();
        else if (this == Apr) onApr();
        else if (this == May) onMay();
        else if (this == Jun) onJun();
        else if (this == Jul) onJul();
        else if (this == Aug) onAug();
        else if (this == Sep) onSep();
        else if (this == Oct) onOct();
        else if (this == Nov) onNov();
        else if (this == Dec) onDec();
        else otherwise(Value);
    }
}
