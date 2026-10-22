using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Extensions;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models.AnyOf;

/// <summary>
/// The visible block for rich media. The expected structure depends on <c>SupplierItemFeedHeader.subCategory</c>. Discriminator is based on <c>SupplierItemFeedHeader.subCategory</c>
/// </summary>
[JsonConverter(typeof(VisibleConverter))]
public record Visible
{
    private readonly Optional<VisibleVideoPayload> _visibleVideoPayloadValue;

    private readonly Optional<Visible360ImagePayload> _visible360ImagePayloadValue;

    private Visible(Optional<VisibleVideoPayload> visibleVideoPayloadValue,
        Optional<Visible360ImagePayload> visible360ImagePayloadValue)
    {
        _visibleVideoPayloadValue = visibleVideoPayloadValue;
        _visible360ImagePayloadValue = visible360ImagePayloadValue;
    }

    public static Visible VisibleVideoPayload(VisibleVideoPayload value) =>
        new(Optional<VisibleVideoPayload>.Some(value), default);

    public static Visible Visible360ImagePayload(Visible360ImagePayload value) =>
        new(default, Optional<Visible360ImagePayload>.Some(value));

    public bool TryGetVisibleVideoPayload(out VisibleVideoPayload value) =>
        _visibleVideoPayloadValue.TryGetValue(out value);

    public bool TryGetVisible360ImagePayload(out Visible360ImagePayload value) =>
        _visible360ImagePayloadValue.TryGetValue(out value);

    public static implicit operator Visible(VisibleVideoPayload value) => VisibleVideoPayload(value);

    public static implicit operator Visible(Visible360ImagePayload value) => Visible360ImagePayload(value);
}

file sealed class VisibleConverter : JsonConverter<Visible>
{
    public override Visible Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<VisibleVideoPayload>(root, options, out var visibleVideoPayloadValue))
        {
            return Visible.VisibleVideoPayload(visibleVideoPayloadValue);
        }
        if (JsonSerializer.TryDeserialize<Visible360ImagePayload>(root, options, out var visible360ImagePayloadValue))
        {
            return Visible.Visible360ImagePayload(visible360ImagePayloadValue);
        }
        throw new JsonException(
            $"JSON does not match VisibleVideoPayload or Visible360ImagePayload schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, Visible value, JsonSerializerOptions options)
    {
        if (value.TryGetVisibleVideoPayload(out var visibleVideoPayloadValue))
        {
            JsonSerializer.Serialize(writer, visibleVideoPayloadValue, options);
        }
        else if (value.TryGetVisible360ImagePayload(out var visible360ImagePayloadValue))
        {
            JsonSerializer.Serialize(writer, visible360ImagePayloadValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(Visible)} contains no valid value to serialize.");
        }
    }
}
