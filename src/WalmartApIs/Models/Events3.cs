using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Events3
{
    /// <summary>
    /// Event type to subscribe to. For allowed values, refer to the Event Payload section or use the GET Event Types API.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("eventType")]
    public required string EventType { get; init; }

    /// <summary>
    /// Version of the event type. For supported versions per eventType, refer to the Event Payload section or use the GET Event Types API.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("eventVersion")]
    public required string EventVersion { get; init; }

    /// <summary>
    /// Resource (functional category) that the event type is mapped to. For allowed values per eventType, refer to the Event Payload section or use the GET Event Types API.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("resourceName")]
    public required string ResourceName { get; init; }

    /// <summary>
    /// Destination URL where notifications are delivered.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("eventUrl")]
    public required string EventUrl { get; init; }

    /// <summary>
    /// Authentication details for accessing the destination URL, if the URL is protected.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("authDetails")]
    public AuthDetails8? AuthDetails { get; init; }

    /// <summary>
    /// Additional HTTP headers to include when delivering notifications to the destination URL. Use for custom authentication headers, tracking identifiers, or any other headers your endpoint requires.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("headers")]
    public IReadOnlyDictionary<string, string>? Headers { get; init; }

    /// <summary>
    /// Status of the subscription. Allowed values: ACTIVE, INACTIVE. To create a subscription, use status = ACTIVE. Notifications are sent only when the subscription is ACTIVE.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
