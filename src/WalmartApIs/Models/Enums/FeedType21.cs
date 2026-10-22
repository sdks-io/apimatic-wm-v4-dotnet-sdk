using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FeedType21>))]
public sealed record FeedType21 : OpenStringEnum<FeedType21>
{
    private FeedType21(string value) : base(value)
    {
    }

    public static readonly FeedType21 PriceAndPromotion = new("PRICE_AND_PROMOTION");

    public TResult Match<TResult>(Func<TResult> onPriceAndPromotion, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == PriceAndPromotion => onPriceAndPromotion(),
            _ => otherwise(Value)
        };

    public void Match(Action onPriceAndPromotion, Action<string> otherwise)
    {
        if (this == PriceAndPromotion) onPriceAndPromotion();
        else otherwise(Value);
    }
}
