using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record PackageDimensions
{
    [JsonPropertyName("length")]
    public required double Length { get; init; }

    [JsonPropertyName("width")]
    public required double Width { get; init; }

    [JsonPropertyName("height")]
    public required double Height { get; init; }

    [JsonPropertyName("unit")]
    public required Unit Unit { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
