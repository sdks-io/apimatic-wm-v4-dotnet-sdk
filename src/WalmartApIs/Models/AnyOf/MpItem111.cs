using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Extensions;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models.AnyOf;

[JsonConverter(typeof(MpItem111Converter))]
public record MpItem111
{
    private readonly Optional<IReadOnlyList<PromotionFeedPriceItem>> _listOfPromotionFeedPriceItemValue;

    private readonly Optional<IReadOnlyList<PriceFeedPromoDiscountItem>> _listOfPriceFeedPromoDiscountItemValue;

    private MpItem111(Optional<IReadOnlyList<PromotionFeedPriceItem>> listOfPromotionFeedPriceItemValue,
        Optional<IReadOnlyList<PriceFeedPromoDiscountItem>> listOfPriceFeedPromoDiscountItemValue)
    {
        _listOfPromotionFeedPriceItemValue = listOfPromotionFeedPriceItemValue;
        _listOfPriceFeedPromoDiscountItemValue = listOfPriceFeedPromoDiscountItemValue;
    }

    public static MpItem111 ListOfPromotionFeedPriceItem(IReadOnlyList<PromotionFeedPriceItem> value) =>
        new(Optional<IReadOnlyList<PromotionFeedPriceItem>>.Some(value), default);

    public static MpItem111 ListOfPriceFeedPromoDiscountItem(IReadOnlyList<PriceFeedPromoDiscountItem> value) =>
        new(default, Optional<IReadOnlyList<PriceFeedPromoDiscountItem>>.Some(value));

    public bool TryGetListOfPromotionFeedPriceItem(out IReadOnlyList<PromotionFeedPriceItem> value) =>
        _listOfPromotionFeedPriceItemValue.TryGetValue(out value);

    public bool TryGetListOfPriceFeedPromoDiscountItem(out IReadOnlyList<PriceFeedPromoDiscountItem> value) =>
        _listOfPriceFeedPromoDiscountItemValue.TryGetValue(out value);
}

file sealed class MpItem111Converter : JsonConverter<MpItem111>
{
    public override MpItem111 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<IReadOnlyList<PromotionFeedPriceItem>>(
            root,
            options,
            out var listOfPromotionFeedPriceItemValue))
        {
            return MpItem111.ListOfPromotionFeedPriceItem(listOfPromotionFeedPriceItemValue);
        }
        if (JsonSerializer.TryDeserialize<IReadOnlyList<PriceFeedPromoDiscountItem>>(
            root,
            options,
            out var listOfPriceFeedPromoDiscountItemValue))
        {
            return MpItem111.ListOfPriceFeedPromoDiscountItem(listOfPriceFeedPromoDiscountItemValue);
        }
        throw new JsonException(
            $"JSON does not match IReadOnlyList<PromotionFeedPriceItem> or IReadOnlyList<PriceFeedPromoDiscountItem> schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, MpItem111 value, JsonSerializerOptions options)
    {
        if (value.TryGetListOfPromotionFeedPriceItem(out var listOfPromotionFeedPriceItemValue))
        {
            JsonSerializer.Serialize(writer, listOfPromotionFeedPriceItemValue, options);
        }
        else if (value.TryGetListOfPriceFeedPromoDiscountItem(out var listOfPriceFeedPromoDiscountItemValue))
        {
            JsonSerializer.Serialize(writer, listOfPriceFeedPromoDiscountItemValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(MpItem111)} contains no valid value to serialize.");
        }
    }
}
