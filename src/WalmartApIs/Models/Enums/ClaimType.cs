using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Claim category: LIT (lost in transit), LAD (lost after delivery), or DAMAGED.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ClaimType>))]
public sealed record ClaimType : OpenStringEnum<ClaimType>
{
    private ClaimType(string value) : base(value)
    {
    }

    public static readonly ClaimType Lit = new("LIT");

    public static readonly ClaimType Lad = new("LAD");

    public static readonly ClaimType Damaged = new("DAMAGED");

    public TResult Match<TResult>(Func<TResult> onLit,
        Func<TResult> onLad,
        Func<TResult> onDamaged,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Lit => onLit(),
            _ when this == Lad => onLad(),
            _ when this == Damaged => onDamaged(),
            _ => otherwise(Value)
        };

    public void Match(Action onLit, Action onLad, Action onDamaged, Action<string> otherwise)
    {
        if (this == Lit) onLit();
        else if (this == Lad) onLad();
        else if (this == Damaged) onDamaged();
        else otherwise(Value);
    }
}
