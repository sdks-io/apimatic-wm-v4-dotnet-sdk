using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<CurrentPriceType>))]
public sealed record CurrentPriceType : OpenStringEnum<CurrentPriceType>
{
    private CurrentPriceType(string value) : base(value)
    {
    }

    public static readonly CurrentPriceType Base = new("BASE");

    public static readonly CurrentPriceType Reduced = new("REDUCED");

    public static readonly CurrentPriceType Clearance = new("CLEARANCE");

    public TResult Match<TResult>(Func<TResult> onBase,
        Func<TResult> onReduced,
        Func<TResult> onClearance,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Base => onBase(),
            _ when this == Reduced => onReduced(),
            _ when this == Clearance => onClearance(),
            _ => otherwise(Value)
        };

    public void Match(Action onBase, Action onReduced, Action onClearance, Action<string> otherwise)
    {
        if (this == Base) onBase();
        else if (this == Reduced) onReduced();
        else if (this == Clearance) onClearance();
        else otherwise(Value);
    }
}
