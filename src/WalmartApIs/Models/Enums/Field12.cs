using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | ITEM_PRIORITY | Recommended priority of the item by Walmart. | integer |
/// | PRICE | Item price | integer |
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Field12>))]
public sealed record Field12 : OpenStringEnum<Field12>
{
    private Field12(string value) : base(value)
    {
    }

    public static readonly Field12 ItemPriority = new("ITEM_PRIORITY");

    public static readonly Field12 Price = new("PRICE");

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
