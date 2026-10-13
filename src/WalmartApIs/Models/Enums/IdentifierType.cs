using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<IdentifierType>))]
public sealed record IdentifierType : OpenStringEnum<IdentifierType>
{
    private IdentifierType(string value) : base(value)
    {
    }

    public static readonly IdentifierType WalmartItemId = new("WALMART_ITEM_ID");

    public static readonly IdentifierType Gtin = new("GTIN");

    public static readonly IdentifierType Upc = new("UPC");

    public static readonly IdentifierType Ean = new("EAN");

    public static readonly IdentifierType Isbn = new("ISBN");

    public static readonly IdentifierType Sku = new("SKU");

    public TResult Match<TResult>(Func<TResult> onWalmartItemId,
        Func<TResult> onGtin,
        Func<TResult> onUpc,
        Func<TResult> onEan,
        Func<TResult> onIsbn,
        Func<TResult> onSku,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == WalmartItemId => onWalmartItemId(),
            _ when this == Gtin => onGtin(),
            _ when this == Upc => onUpc(),
            _ when this == Ean => onEan(),
            _ when this == Isbn => onIsbn(),
            _ when this == Sku => onSku(),
            _ => otherwise(Value)
        };

    public void Match(Action onWalmartItemId,
        Action onGtin,
        Action onUpc,
        Action onEan,
        Action onIsbn,
        Action onSku,
        Action<string> otherwise)
    {
        if (this == WalmartItemId) onWalmartItemId();
        else if (this == Gtin) onGtin();
        else if (this == Upc) onUpc();
        else if (this == Ean) onEan();
        else if (this == Isbn) onIsbn();
        else if (this == Sku) onSku();
        else otherwise(Value);
    }
}
