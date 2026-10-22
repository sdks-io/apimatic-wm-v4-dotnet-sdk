using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Currency>))]
public sealed record Currency : OpenStringEnum<Currency>
{
    private Currency(string value) : base(value)
    {
    }

    public static readonly Currency Usd = new("USD");

    public static readonly Currency Cad = new("CAD");

    public TResult Match<TResult>(Func<TResult> onUsd, Func<TResult> onCad, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Usd => onUsd(),
            _ when this == Cad => onCad(),
            _ => otherwise(Value)
        };

    public void Match(Action onUsd, Action onCad, Action<string> otherwise)
    {
        if (this == Usd) onUsd();
        else if (this == Cad) onCad();
        else otherwise(Value);
    }
}
