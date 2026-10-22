using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// carriers
/// </summary>
public record Carrier1
{
    /// <summary>
    /// The carrier ID. A unique identifier for the carrier.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierId")]
    public string? CarrierId { get; init; }

    /// <summary>
    /// The carrier's short name.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shortName")]
    public string? ShortName { get; init; }

    /// <summary>
    /// The carrier's name.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierName")]
    public string? CarrierName { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
