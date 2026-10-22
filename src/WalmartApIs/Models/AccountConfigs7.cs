using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Account configuration to be set for a seller, comprising of Carrier configurations and Region configurations.
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
/// </summary>
public record AccountConfigs7
{
    /// <summary>
    /// Flag used to migrate/not migrate all the eligible offers for a seller.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("migrateEligibleOffers")]
    public bool? MigrateEligibleOffers { get; init; }

    /// <summary>
    /// Defines the carrier configurations used for shipping, like carrier details and their corresponding region coverage..
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierConfigs")]
    [UniqueItems]
    public IReadOnlyList<CarrierConfig18>? CarrierConfigs { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
