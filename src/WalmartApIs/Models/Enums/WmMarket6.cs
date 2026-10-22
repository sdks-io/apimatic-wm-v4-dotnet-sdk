using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<WmMarket6>))]
public sealed record WmMarket6 : OpenStringEnum<WmMarket6>
{
    private WmMarket6(string value) : base(value)
    {
    }

    public static readonly WmMarket6 Mx = new("mx");

    public static readonly WmMarket6 Ca = new("ca");

    public static readonly WmMarket6 Us = new("us");

    public TResult Match<TResult>(Func<TResult> onMx,
        Func<TResult> onCa,
        Func<TResult> onUs,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Mx => onMx(),
            _ when this == Ca => onCa(),
            _ when this == Us => onUs(),
            _ => otherwise(Value)
        };

    public void Match(Action onMx, Action onCa, Action onUs, Action<string> otherwise)
    {
        if (this == Mx) onMx();
        else if (this == Ca) onCa();
        else if (this == Us) onUs();
        else otherwise(Value);
    }
}
