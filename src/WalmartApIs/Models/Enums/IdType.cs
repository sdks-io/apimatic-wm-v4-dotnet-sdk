using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Type of item identifier.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<IdType>))]
public sealed record IdType : OpenStringEnum<IdType>
{
    private IdType(string value) : base(value)
    {
    }

    public static readonly IdType WalmartItemId = new("WalmartItemId");

    public static readonly IdType SellerSku = new("SellerSKU");

    public TResult Match<TResult>(Func<TResult> onWalmartItemId,
        Func<TResult> onSellerSku,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == WalmartItemId => onWalmartItemId(),
            _ when this == SellerSku => onSellerSku(),
            _ => otherwise(Value)
        };

    public void Match(Action onWalmartItemId, Action onSellerSku, Action<string> otherwise)
    {
        if (this == WalmartItemId) onWalmartItemId();
        else if (this == SellerSku) onSellerSku();
        else otherwise(Value);
    }
}
