using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3ShippingLabelsCarriersTrackingsResponse
{
    /// <summary>
    /// Returns <c>true</c> if the label was successfully discarded.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data")]
    public bool? Data { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
