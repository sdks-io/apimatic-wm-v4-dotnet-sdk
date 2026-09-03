using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// A way to configure this packing option.
/// </summary>
public record CommonPackingConfiguration
{
    /// <summary>
    /// The box content information sources that are allowed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxPackingMethods")]
    public IReadOnlyList<CommonBoxContentInformationSource>? BoxPackingMethods { get; init; }

    /// <summary>
    /// The requirements for a box in the packing option.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxRequirements")]
    public CommonBoxRequirements? BoxRequirements { get; init; }

    /// <summary>
    /// A list of supported shipping requirements for this packing configuration.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingRequirements")]
    public IReadOnlyList<CommonShippingRequirements>? ShippingRequirements { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
