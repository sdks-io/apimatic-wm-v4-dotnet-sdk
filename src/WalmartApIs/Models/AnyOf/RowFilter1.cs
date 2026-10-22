using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Extensions;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models.AnyOf;

/// <summary>
/// Supertype of all row filters.
/// </summary>
[JsonConverter(typeof(RowFilter1Converter))]
public record RowFilter1
{
    private readonly Optional<EnumFilter2> _enumFilter2Value;

    private readonly Optional<RangeFilter> _rangeFilterValue;

    private readonly Optional<MultiValueFilter1> _multiValueFilter1Value;

    private RowFilter1(Optional<EnumFilter2> enumFilter2Value,
        Optional<RangeFilter> rangeFilterValue,
        Optional<MultiValueFilter1> multiValueFilter1Value)
    {
        _enumFilter2Value = enumFilter2Value;
        _rangeFilterValue = rangeFilterValue;
        _multiValueFilter1Value = multiValueFilter1Value;
    }

    public static RowFilter1 EnumFilter2(EnumFilter2 value) => new(Optional<EnumFilter2>.Some(value), default, default);

    public static RowFilter1 RangeFilter(RangeFilter value) => new(default, Optional<RangeFilter>.Some(value), default);

    public static RowFilter1 MultiValueFilter1(MultiValueFilter1 value) =>
        new(default, default, Optional<MultiValueFilter1>.Some(value));

    public bool TryGetEnumFilter2(out EnumFilter2 value) => _enumFilter2Value.TryGetValue(out value);

    public bool TryGetRangeFilter(out RangeFilter value) => _rangeFilterValue.TryGetValue(out value);

    public bool TryGetMultiValueFilter1(out MultiValueFilter1 value) => _multiValueFilter1Value.TryGetValue(out value);

    public static implicit operator RowFilter1(EnumFilter2 value) => EnumFilter2(value);

    public static implicit operator RowFilter1(RangeFilter value) => RangeFilter(value);

    public static implicit operator RowFilter1(MultiValueFilter1 value) => MultiValueFilter1(value);
}

file sealed class RowFilter1Converter : JsonConverter<RowFilter1>
{
    public override RowFilter1 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<EnumFilter2>(root, options, out var enumFilter2Value))
        {
            return RowFilter1.EnumFilter2(enumFilter2Value);
        }
        if (JsonSerializer.TryDeserialize<RangeFilter>(root, options, out var rangeFilterValue))
        {
            return RowFilter1.RangeFilter(rangeFilterValue);
        }
        if (JsonSerializer.TryDeserialize<MultiValueFilter1>(root, options, out var multiValueFilter1Value))
        {
            return RowFilter1.MultiValueFilter1(multiValueFilter1Value);
        }
        throw new JsonException(
            $"JSON does not match EnumFilter2 or RangeFilter or MultiValueFilter1 schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, RowFilter1 value, JsonSerializerOptions options)
    {
        if (value.TryGetEnumFilter2(out var enumFilter2Value))
        {
            JsonSerializer.Serialize(writer, enumFilter2Value, options);
        }
        else if (value.TryGetRangeFilter(out var rangeFilterValue))
        {
            JsonSerializer.Serialize(writer, rangeFilterValue, options);
        }
        else if (value.TryGetMultiValueFilter1(out var multiValueFilter1Value))
        {
            JsonSerializer.Serialize(writer, multiValueFilter1Value, options);
        }
        else
        {
            throw new JsonException($"{nameof(RowFilter1)} contains no valid value to serialize.");
        }
    }
}
