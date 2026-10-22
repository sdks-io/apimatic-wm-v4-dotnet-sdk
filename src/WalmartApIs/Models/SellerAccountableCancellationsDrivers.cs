using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Seller accountable drivers, which impacting the cancellations rate
/// </summary>
public record SellerAccountableCancellationsDrivers
{
    /// <summary>
    /// Rate of orders cancelled due to out of stock
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("outOfStockRate")]
    public double? OutOfStockRate { get; init; }

    /// <summary>
    /// Rate of orders cancelled due to pricing errors
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pricingErrorRate")]
    public double? PricingErrorRate { get; init; }

    /// <summary>
    /// Rate of orders cancelled due of incorrectly marked as address not serviceable
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("incMrkdAddNotSvcbleRate")]
    public double? IncMrkdAddNotSvcbleRate { get; init; }

    /// <summary>
    /// Rate of orders cancelled due to ship window expired
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipWindowExpRate")]
    public double? ShipWindowExpRate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
