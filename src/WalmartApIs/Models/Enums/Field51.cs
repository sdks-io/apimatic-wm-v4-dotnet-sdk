using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | ITEM_PRIORITY | Recommended priority of the item by Walmart. | integer |
/// | PRICE | Item price | integer |
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Field51>))]
public sealed record Field51 : OpenStringEnum<Field51>
{
    private Field51(string value) : base(value)
    {
    }

    public static readonly Field51 ItemPriority = new("ITEM_PRIORITY");

    public static readonly Field51 Price = new("PRICE");

    public TResult Match<TResult>(Func<TResult> onItemPriority,
        Func<TResult> onPrice,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ItemPriority => onItemPriority(),
            _ when this == Price => onPrice(),
            _ => otherwise(Value)
        };

    public void Match(Action onItemPriority, Action onPrice, Action<string> otherwise)
    {
        if (this == ItemPriority) onItemPriority();
        else if (this == Price) onPrice();
        else otherwise(Value);
    }
}
