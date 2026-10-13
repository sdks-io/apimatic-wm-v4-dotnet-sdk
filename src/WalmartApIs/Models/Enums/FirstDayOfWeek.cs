using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FirstDayOfWeek>))]
public sealed record FirstDayOfWeek : OpenStringEnum<FirstDayOfWeek>
{
    private FirstDayOfWeek(string value) : base(value)
    {
    }

    public static readonly FirstDayOfWeek Monday = new("Monday");

    public static readonly FirstDayOfWeek Sunday = new("Sunday");

    public TResult Match<TResult>(Func<TResult> onMonday, Func<TResult> onSunday, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Monday => onMonday(),
            _ when this == Sunday => onSunday(),
            _ => otherwise(Value)
        };

    public void Match(Action onMonday, Action onSunday, Action<string> otherwise)
    {
        if (this == Monday) onMonday();
        else if (this == Sunday) onSunday();
        else otherwise(Value);
    }
}
