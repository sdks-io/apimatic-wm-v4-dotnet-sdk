using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Specifies the date granularity for aggregating report data. Required when using <c>reportType=ITEM_PERFORMANCE</c> and <c>reportVersion=v3</c>. Valid values are <c>DAILY</c>, <c>WEEKLY</c>, <c>MONTHLY</c>, or <c>QUARTERLY</c>. Ignored for all other report types and versions.
/// <para>
/// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<DateGranularity>))]
public sealed record DateGranularity : OpenStringEnum<DateGranularity>
{
    private DateGranularity(string value) : base(value)
    {
    }

    public static readonly DateGranularity Daily = new("DAILY");

    public static readonly DateGranularity Weekly = new("WEEKLY");

    public static readonly DateGranularity Monthly = new("MONTHLY");

    public static readonly DateGranularity Quarterly = new("QUARTERLY");

    public TResult Match<TResult>(Func<TResult> onDaily,
        Func<TResult> onWeekly,
        Func<TResult> onMonthly,
        Func<TResult> onQuarterly,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Daily => onDaily(),
            _ when this == Weekly => onWeekly(),
            _ when this == Monthly => onMonthly(),
            _ when this == Quarterly => onQuarterly(),
            _ => otherwise(Value)
        };

    public void Match(Action onDaily, Action onWeekly, Action onMonthly, Action onQuarterly, Action<string> otherwise)
    {
        if (this == Daily) onDaily();
        else if (this == Weekly) onWeekly();
        else if (this == Monthly) onMonthly();
        else if (this == Quarterly) onQuarterly();
        else otherwise(Value);
    }
}
