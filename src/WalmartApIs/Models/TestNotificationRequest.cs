using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record TestNotificationRequest
{
    /// <summary>
    /// Event type to test. Use the same identifier you would use to subscribe.
    /// </summary>
    [JsonPropertyName("eventType")]
    public required string EventType { get; init; }

    /// <summary>
    /// Version of the event type to test.
    /// </summary>
    [JsonPropertyName("eventVersion")]
    public required string EventVersion { get; init; }

    /// <summary>
    /// Resource (functional category) that the event type is mapped to.
    /// </summary>
    [JsonPropertyName("resourceName")]
    public required string ResourceName { get; init; }

    /// <summary>
    /// Destination URL where notifications are delivered.
    /// </summary>
    [JsonPropertyName("eventUrl")]
    public required string EventUrl { get; init; }

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
