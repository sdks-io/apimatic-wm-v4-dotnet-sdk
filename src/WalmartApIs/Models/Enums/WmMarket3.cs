using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<WmMarket3>))]
public sealed record WmMarket3 : OpenStringEnum<WmMarket3>
{
    private WmMarket3(string value) : base(value)
    {
    }

    public static readonly WmMarket3 Us = new("us");

    public static readonly WmMarket3 Mx = new("mx");

    public TResult Match<TResult>(Func<TResult> onUs, Func<TResult> onMx, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Us => onUs(),
            _ when this == Mx => onMx(),
            _ => otherwise(Value)
        };

    public void Match(Action onUs, Action onMx, Action<string> otherwise)
    {
        if (this == Us) onUs();
        else if (this == Mx) onMx();
        else otherwise(Value);
    }
}
