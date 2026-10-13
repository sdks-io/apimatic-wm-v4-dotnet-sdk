using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Granularity>))]
public sealed record Granularity : OpenStringEnum<Granularity>
{
    private Granularity(string value) : base(value)
    {
    }

    public static readonly Granularity Hour = new("Hour");

    public static readonly Granularity Day = new("Day");

    public static readonly Granularity Week = new("Week");

    public static readonly Granularity Month = new("Month");

    public static readonly Granularity Year = new("Year");

    public static readonly Granularity Total = new("Total");

    public TResult Match<TResult>(Func<TResult> onHour,
        Func<TResult> onDay,
        Func<TResult> onWeek,
        Func<TResult> onMonth,
        Func<TResult> onYear,
        Func<TResult> onTotal,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Hour => onHour(),
            _ when this == Day => onDay(),
            _ when this == Week => onWeek(),
            _ when this == Month => onMonth(),
            _ when this == Year => onYear(),
            _ when this == Total => onTotal(),
            _ => otherwise(Value)
        };

    public void Match(Action onHour,
        Action onDay,
        Action onWeek,
        Action onMonth,
        Action onYear,
        Action onTotal,
        Action<string> otherwise)
    {
        if (this == Hour) onHour();
        else if (this == Day) onDay();
        else if (this == Week) onWeek();
        else if (this == Month) onMonth();
        else if (this == Year) onYear();
        else if (this == Total) onTotal();
        else otherwise(Value);
    }
}
