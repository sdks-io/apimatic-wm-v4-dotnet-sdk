using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<IdentifierType>))]
public sealed record IdentifierType : StringEnum<IdentifierType>
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

    public static IdentifierType FromValue(string value) => FromValueCore(value);
}
