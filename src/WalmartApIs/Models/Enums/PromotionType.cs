using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Market | Translation |
/// | --- | ----------- |
/// | CA  | ["Clearance", "Reduced"]|
/// | MX | ["Rebaja", "Liquidación"]|
/// <para>
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX &lt;/b&gt;
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PromotionType>))]
public sealed record PromotionType : OpenStringEnum<PromotionType>
{
    private PromotionType(string value) : base(value)
    {
    }

    public static readonly PromotionType Clearance = new("Clearance");

    public static readonly PromotionType Reduced = new("Reduced");

    public static readonly PromotionType Rebaja = new("Rebaja");

    public static readonly PromotionType LiquidaciN = new("Liquidación");

    public TResult Match<TResult>(Func<TResult> onClearance,
        Func<TResult> onReduced,
        Func<TResult> onRebaja,
        Func<TResult> onLiquidaciN,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Clearance => onClearance(),
            _ when this == Reduced => onReduced(),
            _ when this == Rebaja => onRebaja(),
            _ when this == LiquidaciN => onLiquidaciN(),
            _ => otherwise(Value)
        };

    public void Match(Action onClearance,
        Action onReduced,
        Action onRebaja,
        Action onLiquidaciN,
        Action<string> otherwise)
    {
        if (this == Clearance) onClearance();
        else if (this == Reduced) onReduced();
        else if (this == Rebaja) onRebaja();
        else if (this == LiquidaciN) onLiquidaciN();
        else otherwise(Value);
    }
}
