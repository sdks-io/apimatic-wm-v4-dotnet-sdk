using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Schema for an individual ItemOffersResponse.
/// </summary>
public record ItemOffersResponse
{
    /// <summary>
    /// A mapping of additional HTTP headers to receive for the individual batch request.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("headers")]
    public HttpResponseHeaders? Headers { get; init; }

    /// <summary>
    /// The HTTP status line associated with the response.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public GetOffersHttpStatusLine? Status { get; init; }

    /// <summary>
    /// The response schema for the getListingOffers and getItemOffers operations.
    /// </summary>
    [JsonPropertyName("body")]
    public required GetOffersResponse Body { get; init; }

    /// <summary>
    /// List of request parameters accepted by the getItemOffers operation.
    /// </summary>
    [JsonPropertyName("request")]
    public required ItemOffersRequest Request { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
