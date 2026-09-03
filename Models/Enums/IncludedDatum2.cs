using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<IncludedDatum2>))]
public sealed record IncludedDatum2 : StringEnum<IncludedDatum2>
{
    private IncludedDatum2(string value) : base(value)
    {
    }

    public static readonly IncludedDatum2 FeaturedBuyingOptions = new("featuredBuyingOptions");

    public static readonly IncludedDatum2 ReferencePrices = new("referencePrices");

    public static readonly IncludedDatum2 LowestPricedOffers = new("lowestPricedOffers");

    public static readonly IncludedDatum2 SimilarItems = new("similarItems");

    public static IncludedDatum2 FromValue(string value) => FromValueCore(value);
}
