using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<WmMarket2>))]
public sealed record WmMarket2 : OpenStringEnum<WmMarket2>
{
    private WmMarket2(string value) : base(value)
    {
    }

    public static readonly WmMarket2 Us = new("US");

    public static readonly WmMarket2 Ca = new("CA");

    public static readonly WmMarket2 Mx = new("MX");

    public static readonly WmMarket2 Cl = new("CL");

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
