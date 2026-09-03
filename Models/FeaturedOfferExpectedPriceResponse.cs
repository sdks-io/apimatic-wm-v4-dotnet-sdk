using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// An individual FOEP response.
/// </summary>
public record FeaturedOfferExpectedPriceResponse
{
    /// <summary>
    /// The HTTP status line associated with the response.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public GetOffersHttpStatusLine? Status { get; init; }

    /// <summary>
    /// The body of a FOEP response.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("body")]
    public FeaturedOfferExpectedPriceResponseBody? Body { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
