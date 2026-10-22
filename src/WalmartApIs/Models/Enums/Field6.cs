using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | ITEM_NAME | Product name | string |
/// | SKU | Specifies the item identified. This value is defined by the seller. | string |
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Field6>))]
public sealed record Field6 : OpenStringEnum<Field6>
{
    private Field6(string value) : base(value)
    {
    }

    public static readonly Field6 ItemName = new("ITEM_NAME");

    public static readonly Field6 Sku = new("SKU");

    public TResult Match<TResult>(Func<TResult> onItemName, Func<TResult> onSku, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ItemName => onItemName(),
            _ when this == Sku => onSku(),
            _ => otherwise(Value)
        };

    public void Match(Action onItemName, Action onSku, Action<string> otherwise)
    {
        if (this == ItemName) onItemName();
        else if (this == Sku) onSku();
        else otherwise(Value);
    }
}
