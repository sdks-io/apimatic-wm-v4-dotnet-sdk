using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Date range to filter impressions, page views, and sales.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<DateRange>))]
public sealed record DateRange : OpenStringEnum<DateRange>
{
    private DateRange(string value) : base(value)
    {
    }

    public static readonly DateRange _7Days = new("7DAYS");

    public static readonly DateRange _14Days = new("14DAYS");

    public static readonly DateRange _30Days = new("30DAYS");

    public TResult Match<TResult>(Func<TResult> on_7Days,
        Func<TResult> on_14Days,
        Func<TResult> on_30Days,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == _7Days => on_7Days(),
            _ when this == _14Days => on_14Days(),
            _ when this == _30Days => on_30Days(),
            _ => otherwise(Value)
        };

    public void Match(Action on_7Days, Action on_14Days, Action on_30Days, Action<string> otherwise)
    {
        if (this == _7Days) on_7Days();
        else if (this == _14Days) on_14Days();
        else if (this == _30Days) on_30Days();
        else otherwise(Value);
    }
}
