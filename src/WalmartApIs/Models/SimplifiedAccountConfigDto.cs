using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Account configuration to be set for a seller, comprising of Carrier configurations and Region configurations.
/// </summary>
public record SimplifiedAccountConfigDto
{
    /// <summary>
    /// Shipping priority will help system decide the carrier service for fulfillment in case there are multiple shipping options available for customers with different carrier services in terms of shipping cost and speed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingPriority")]
    public ShippingPriority? ShippingPriority { get; init; }

    /// <summary>
    /// Flag used to migrate/not migrate all the eligible offers for a seller.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("migrateEligibleOffers")]
    public bool? MigrateEligibleOffers { get; init; }

    /// <summary>
    /// Defines the carrier configurations used for shipping, like carrier details and their corresponding region coverage..
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierConfigs")]
    [UniqueItems]
    public IReadOnlyList<CarrierConfigDto>? CarrierConfigs { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
