using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<WmMarket1>))]
public sealed record WmMarket1 : OpenStringEnum<WmMarket1>
{
    private WmMarket1(string value) : base(value)
    {
    }

    public static readonly WmMarket1 Us = new("us");

    public static readonly WmMarket1 Ca = new("ca");

    public static readonly WmMarket1 Mx = new("mx");

    public static readonly WmMarket1 Cl = new("cl");

    public TResult Match<TResult>(Func<TResult> onUs,
        Func<TResult> onCa,
        Func<TResult> onMx,
        Func<TResult> onCl,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Us => onUs(),
            _ when this == Ca => onCa(),
            _ when this == Mx => onMx(),
            _ when this == Cl => onCl(),
            _ => otherwise(Value)
        };

    public void Match(Action onUs, Action onCa, Action onMx, Action onCl, Action<string> otherwise)
    {
        if (this == Us) onUs();
        else if (this == Ca) onCa();
        else if (this == Mx) onMx();
        else if (this == Cl) onCl();
        else otherwise(Value);
    }
}
