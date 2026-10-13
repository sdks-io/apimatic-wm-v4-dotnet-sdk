using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// A constraint that can apply to an individual owner.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonOwnerConstraint>))]
public sealed record CommonOwnerConstraint : OpenStringEnum<CommonOwnerConstraint>
{
    private CommonOwnerConstraint(string value) : base(value)
    {
    }

    public static readonly CommonOwnerConstraint SellerOnly = new("SELLER_ONLY");

    public static readonly CommonOwnerConstraint NoneOnly = new("NONE_ONLY");

    public TResult Match<TResult>(Func<TResult> onSellerOnly,
        Func<TResult> onNoneOnly,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == SellerOnly => onSellerOnly(),
            _ when this == NoneOnly => onNoneOnly(),
            _ => otherwise(Value)
        };

    public void Match(Action onSellerOnly, Action onNoneOnly, Action<string> otherwise)
    {
        if (this == SellerOnly) onSellerOnly();
        else if (this == NoneOnly) onNoneOnly();
        else otherwise(Value);
    }
}
