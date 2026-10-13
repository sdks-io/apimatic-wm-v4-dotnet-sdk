using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<IncludedDatum2>))]
public sealed record IncludedDatum2 : OpenStringEnum<IncludedDatum2>
{
    private IncludedDatum2(string value) : base(value)
    {
    }

    public static readonly IncludedDatum2 FeaturedBuyingOptions = new("featuredBuyingOptions");

    public static readonly IncludedDatum2 ReferencePrices = new("referencePrices");

    public static readonly IncludedDatum2 LowestPricedOffers = new("lowestPricedOffers");

    public static readonly IncludedDatum2 SimilarItems = new("similarItems");

    public TResult Match<TResult>(Func<TResult> onFeaturedBuyingOptions,
        Func<TResult> onReferencePrices,
        Func<TResult> onLowestPricedOffers,
        Func<TResult> onSimilarItems,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == FeaturedBuyingOptions => onFeaturedBuyingOptions(),
            _ when this == ReferencePrices => onReferencePrices(),
            _ when this == LowestPricedOffers => onLowestPricedOffers(),
            _ when this == SimilarItems => onSimilarItems(),
            _ => otherwise(Value)
        };

    public void Match(Action onFeaturedBuyingOptions,
        Action onReferencePrices,
        Action onLowestPricedOffers,
        Action onSimilarItems,
        Action<string> otherwise)
    {
        if (this == FeaturedBuyingOptions) onFeaturedBuyingOptions();
        else if (this == ReferencePrices) onReferencePrices();
        else if (this == LowestPricedOffers) onLowestPricedOffers();
        else if (this == SimilarItems) onSimilarItems();
        else otherwise(Value);
    }
}
