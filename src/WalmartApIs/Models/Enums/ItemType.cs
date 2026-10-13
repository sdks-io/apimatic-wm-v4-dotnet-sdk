using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ItemType>))]
public sealed record ItemType : OpenStringEnum<ItemType>
{
    private ItemType(string value) : base(value)
    {
    }

    public static readonly ItemType WalmartItemId = new("WalmartItemId");

    public static readonly ItemType Sku = new("Sku");

    public TResult Match<TResult>(Func<TResult> onWalmartItemId,
        Func<TResult> onSku,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == WalmartItemId => onWalmartItemId(),
            _ when this == Sku => onSku(),
            _ => otherwise(Value)
        };

    public void Match(Action onWalmartItemId, Action onSku, Action<string> otherwise)
    {
        if (this == WalmartItemId) onWalmartItemId();
        else if (this == Sku) onSku();
        else otherwise(Value);
    }
}
