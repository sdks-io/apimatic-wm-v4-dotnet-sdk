using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ReturnOrderShipment1
{
    /// <summary>
    /// shipmentNo.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipmentNo")]
    public string? ShipmentNo { get; init; }

    /// <summary>
    /// trackingNumber.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trackingNumber")]
    public string? TrackingNumber { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
