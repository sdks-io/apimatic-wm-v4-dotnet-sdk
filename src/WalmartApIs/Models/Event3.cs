using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Event3
{
    /// <summary>
    /// Event type for which the subscription was created.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("eventType")]
    public string? EventType { get; init; }

    /// <summary>
    /// Unique identifier for the subscription. Use this ID to retrieve, update, or delete the subscription.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; init; }

    /// <summary>
    /// Partner ID of the seller who created the subscription.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("partnerId")]
    public string? PartnerId { get; init; }

    /// <summary>
    /// Version of the event type for which the subscription was created.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("eventVersion")]
    public string? EventVersion { get; init; }

    /// <summary>
    /// Resource (functional category) that the event type is mapped to (for example, ITEM, ORDER, PRICE).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("resourceName")]
    public string? ResourceName { get; init; }

    /// <summary>
    /// Subscription status. Allowed values: ACTIVE, INACTIVE.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Destination URL where notifications are delivered.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("eventUrl")]
    public string? EventUrl { get; init; }

    /// <summary>
    /// Authentication details for accessing the destination URL, if the URL is protected.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("authDetails")]
    public AuthDetails? AuthDetails { get; init; }

    /// <summary>
    /// Additional HTTP headers to include when delivering notifications to the destination URL. Use for custom authentication headers, tracking identifiers, or any other headers your endpoint requires.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("headers")]
    public IReadOnlyDictionary<string, string>? Headers { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
