using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Market | Translation |
/// | --- | ----------- |
/// | US | ["Clearance", "Reduced"]|
/// <para>
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PromotionType1>))]
public sealed record PromotionType1 : OpenStringEnum<PromotionType1>
{
    private PromotionType1(string value) : base(value)
    {
    }

    public static readonly PromotionType1 Clearance = new("Clearance");

    public static readonly PromotionType1 Reduced = new("Reduced");

    public TResult Match<TResult>(Func<TResult> onClearance,
        Func<TResult> onReduced,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Clearance => onClearance(),
            _ when this == Reduced => onReduced(),
            _ => otherwise(Value)
        };

    public void Match(Action onClearance, Action onReduced, Action<string> otherwise)
    {
        if (this == Clearance) onClearance();
        else if (this == Reduced) onReduced();
        else otherwise(Value);
    }
}
