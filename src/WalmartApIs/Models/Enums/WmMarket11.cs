using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<WmMarket11>))]
public sealed record WmMarket11 : OpenStringEnum<WmMarket11>
{
    private WmMarket11(string value) : base(value)
    {
    }

    public static readonly WmMarket11 Mx = new("mx");

    public static readonly WmMarket11 Ca = new("ca");

    public static readonly WmMarket11 Cl = new("cl");

    public TResult Match<TResult>(Func<TResult> onMx,
        Func<TResult> onCa,
        Func<TResult> onCl,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Mx => onMx(),
            _ when this == Ca => onCa(),
            _ when this == Cl => onCl(),
            _ => otherwise(Value)
        };

    public void Match(Action onMx, Action onCa, Action onCl, Action<string> otherwise)
    {
        if (this == Mx) onMx();
        else if (this == Ca) onCa();
        else if (this == Cl) onCl();
        else otherwise(Value);
    }
}
