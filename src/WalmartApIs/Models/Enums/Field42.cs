using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | ITEM_NAME | Product name | string |
/// | SKU | Specifies the item identified. This value is defined by the seller. | string |
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Field42>))]
public sealed record Field42 : OpenStringEnum<Field42>
{
    private Field42(string value) : base(value)
    {
    }

    public static readonly Field42 ItemName = new("ITEM_NAME");

    public static readonly Field42 Sku = new("SKU");

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
