using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Requirements>))]
public sealed record Requirements : StringEnum<Requirements>
{
    private Requirements(string value) : base(value)
    {
    }

    public static readonly Requirements Listing = new("LISTING");

    public static readonly Requirements ListingProductOnly = new("LISTING_PRODUCT_ONLY");

    public static readonly Requirements ListingOfferOnly = new("LISTING_OFFER_ONLY");

    public static Requirements FromValue(string value) => FromValueCore(value);
}
