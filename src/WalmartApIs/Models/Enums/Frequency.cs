using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Specifies the frequency at which the report should be generated. For example, if set to YEARLY, the report will be generated once every year.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Frequency>))]
public sealed record Frequency : OpenStringEnum<Frequency>
{
    private Frequency(string value) : base(value)
    {
    }

    public static readonly Frequency Hourly = new("HOURLY");

    public static readonly Frequency Daily = new("DAILY");

    public static readonly Frequency Weekly = new("WEEKLY");

    public static readonly Frequency Monthly = new("MONTHLY");

    public static readonly Frequency Yearly = new("YEARLY");

    public TResult Match<TResult>(Func<TResult> onHourly,
        Func<TResult> onDaily,
        Func<TResult> onWeekly,
        Func<TResult> onMonthly,
        Func<TResult> onYearly,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Hourly => onHourly(),
            _ when this == Daily => onDaily(),
            _ when this == Weekly => onWeekly(),
            _ when this == Monthly => onMonthly(),
            _ when this == Yearly => onYearly(),
            _ => otherwise(Value)
        };

    public void Match(Action onHourly,
        Action onDaily,
        Action onWeekly,
        Action onMonthly,
        Action onYearly,
        Action<string> otherwise)
    {
        if (this == Hourly) onHourly();
        else if (this == Daily) onDaily();
        else if (this == Weekly) onWeekly();
        else if (this == Monthly) onMonthly();
        else if (this == Yearly) onYearly();
        else otherwise(Value);
    }
}
