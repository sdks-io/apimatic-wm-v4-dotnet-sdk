using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Field7>))]
public sealed record Field7 : OpenStringEnum<Field7>
{
    private Field7(string value) : base(value)
    {
    }

    public static readonly Field7 Sku = new("sku");

    public static readonly Field7 ItemId = new("itemId");

    public static readonly Field7 ProductName = new("productName");

    public TResult Match<TResult>(Func<TResult> onSku,
        Func<TResult> onItemId,
        Func<TResult> onProductName,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Sku => onSku(),
            _ when this == ItemId => onItemId(),
            _ when this == ProductName => onProductName(),
            _ => otherwise(Value)
        };

    public void Match(Action onSku, Action onItemId, Action onProductName, Action<string> otherwise)
    {
        if (this == Sku) onSku();
        else if (this == ItemId) onItemId();
        else if (this == ProductName) onProductName();
        else otherwise(Value);
    }
}
