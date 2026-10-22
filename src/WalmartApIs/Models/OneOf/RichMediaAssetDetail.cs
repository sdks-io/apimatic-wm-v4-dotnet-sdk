using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models.OneOf;

/// <summary>
/// Asset content details. Structure varies by <c>mediaType</c>: <c>VIDEO</c> assets contain video URL, optional closed captions, category, and thumbnail; <c>IMAGES360</c> assets contain an ordered array of image frame URLs.
/// </summary>
[JsonConverter(typeof(RichMediaAssetDetailConverter))]
public record RichMediaAssetDetail
{
    private readonly Optional<VideoAssetDetailPayload> _videoAssetDetailPayloadValue;

    private readonly Optional<Images360AssetDetailPayload> _images360AssetDetailPayloadValue;

    private RichMediaAssetDetail(Optional<VideoAssetDetailPayload> videoAssetDetailPayloadValue,
        Optional<Images360AssetDetailPayload> images360AssetDetailPayloadValue)
    {
        _videoAssetDetailPayloadValue = videoAssetDetailPayloadValue;
        _images360AssetDetailPayloadValue = images360AssetDetailPayloadValue;
    }

    public static RichMediaAssetDetail VideoAssetDetailPayload(VideoAssetDetailPayload value) =>
        new(Optional<VideoAssetDetailPayload>.Some(value), default);

    public static RichMediaAssetDetail Images360AssetDetailPayload(Images360AssetDetailPayload value) =>
        new(default, Optional<Images360AssetDetailPayload>.Some(value));

    public bool TryGetVideoAssetDetailPayload(out VideoAssetDetailPayload value) =>
        _videoAssetDetailPayloadValue.TryGetValue(out value);

    public bool TryGetImages360AssetDetailPayload(out Images360AssetDetailPayload value) =>
        _images360AssetDetailPayloadValue.TryGetValue(out value);

    public static implicit operator RichMediaAssetDetail(VideoAssetDetailPayload value) =>
        VideoAssetDetailPayload(value);

    public static implicit operator RichMediaAssetDetail(Images360AssetDetailPayload value) =>
        Images360AssetDetailPayload(value);
}

file sealed class RichMediaAssetDetailConverter : JsonConverter<RichMediaAssetDetail>
{
    public override RichMediaAssetDetail Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (!root.TryGetProperty("mediaType", out var typeProperty))
        {
            throw new JsonException("Missing required 'mediaType' discriminator field");
        }
        var discriminator = typeProperty.GetString();
        return discriminator switch
        {
            "VIDEO" => RichMediaAssetDetail.VideoAssetDetailPayload(root.Deserialize<VideoAssetDetailPayload>(
                options)!),
            "IMAGES360" => RichMediaAssetDetail.Images360AssetDetailPayload(
                root.Deserialize<Images360AssetDetailPayload>(options)!),
            _ => throw new JsonException(
                $"JSON does not match VideoAssetDetailPayload or Images360AssetDetailPayload schemas: {root.ToString()}")
        };
    }

    public override void Write(Utf8JsonWriter writer, RichMediaAssetDetail value, JsonSerializerOptions options)
    {
        if (value.TryGetVideoAssetDetailPayload(out var videoAssetDetailPayloadValue))
        {
            JsonSerializer.Serialize(writer, videoAssetDetailPayloadValue, options);
        }
        else if (value.TryGetImages360AssetDetailPayload(out var images360AssetDetailPayloadValue))
        {
            JsonSerializer.Serialize(writer, images360AssetDetailPayloadValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(RichMediaAssetDetail)} contains no valid value to serialize.");
        }
    }
}
