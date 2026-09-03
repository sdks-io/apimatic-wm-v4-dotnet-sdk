using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates whether the offer is a B2B or B2C offer.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<OfferType>))]
public sealed record OfferType : StringEnum<OfferType>
{
    private OfferType(string value) : base(value)
    {
    }

    public static readonly OfferType B2C = new("B2C");

    public static readonly OfferType B2B = new("B2B");

    public static OfferType FromValue(string value) => FromValueCore(value);
}
