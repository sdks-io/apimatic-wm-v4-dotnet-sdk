using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<WmMarket21>))]
public sealed record WmMarket21 : OpenStringEnum<WmMarket21>
{
    private WmMarket21(string value) : base(value)
    {
    }

    public static readonly WmMarket21 Mx = new("mx");

    public TResult Match<TResult>(Func<TResult> onMx, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Mx => onMx(),
            _ => otherwise(Value)
        };

    public void Match(Action onMx, Action<string> otherwise)
    {
        if (this == Mx) onMx();
        else otherwise(Value);
    }
}
