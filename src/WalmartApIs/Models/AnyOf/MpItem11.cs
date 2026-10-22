using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Extensions;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models.AnyOf;

[JsonConverter(typeof(MpItem11Converter))]
public record MpItem11
{
    private readonly Optional<IReadOnlyList<PriceFeedPriceItem>> _listOfPriceFeedPriceItemValue;

    private readonly Optional<IReadOnlyList<PriceFeedPromoDiscountItem>> _listOfPriceFeedPromoDiscountItemValue;

    private MpItem11(Optional<IReadOnlyList<PriceFeedPriceItem>> listOfPriceFeedPriceItemValue,
        Optional<IReadOnlyList<PriceFeedPromoDiscountItem>> listOfPriceFeedPromoDiscountItemValue)
    {
        _listOfPriceFeedPriceItemValue = listOfPriceFeedPriceItemValue;
        _listOfPriceFeedPromoDiscountItemValue = listOfPriceFeedPromoDiscountItemValue;
    }

    public static MpItem11 ListOfPriceFeedPriceItem(IReadOnlyList<PriceFeedPriceItem> value) =>
        new(Optional<IReadOnlyList<PriceFeedPriceItem>>.Some(value), default);

    public static MpItem11 ListOfPriceFeedPromoDiscountItem(IReadOnlyList<PriceFeedPromoDiscountItem> value) =>
        new(default, Optional<IReadOnlyList<PriceFeedPromoDiscountItem>>.Some(value));

    public bool TryGetListOfPriceFeedPriceItem(out IReadOnlyList<PriceFeedPriceItem> value) =>
        _listOfPriceFeedPriceItemValue.TryGetValue(out value);

    public bool TryGetListOfPriceFeedPromoDiscountItem(out IReadOnlyList<PriceFeedPromoDiscountItem> value) =>
        _listOfPriceFeedPromoDiscountItemValue.TryGetValue(out value);
}

file sealed class MpItem11Converter : JsonConverter<MpItem11>
{
    public override MpItem11 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<IReadOnlyList<PriceFeedPriceItem>>(
            root,
            options,
            out var listOfPriceFeedPriceItemValue))
        {
            return MpItem11.ListOfPriceFeedPriceItem(listOfPriceFeedPriceItemValue);
        }
        if (JsonSerializer.TryDeserialize<IReadOnlyList<PriceFeedPromoDiscountItem>>(
            root,
            options,
            out var listOfPriceFeedPromoDiscountItemValue))
        {
            return MpItem11.ListOfPriceFeedPromoDiscountItem(listOfPriceFeedPromoDiscountItemValue);
        }
        throw new JsonException(
            $"JSON does not match IReadOnlyList<PriceFeedPriceItem> or IReadOnlyList<PriceFeedPromoDiscountItem> schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, MpItem11 value, JsonSerializerOptions options)
    {
        if (value.TryGetListOfPriceFeedPriceItem(out var listOfPriceFeedPriceItemValue))
        {
            JsonSerializer.Serialize(writer, listOfPriceFeedPriceItemValue, options);
        }
        else if (value.TryGetListOfPriceFeedPromoDiscountItem(out var listOfPriceFeedPromoDiscountItemValue))
        {
            JsonSerializer.Serialize(writer, listOfPriceFeedPromoDiscountItemValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(MpItem11)} contains no valid value to serialize.");
        }
    }
}
