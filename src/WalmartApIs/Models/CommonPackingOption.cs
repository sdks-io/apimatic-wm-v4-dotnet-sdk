using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// A packing option contains a set of pack groups plus additional information such as any discounts or fees.
/// </summary>
public record CommonPackingOption
{
    /// <summary>
    /// Discount for the offered option.
    /// </summary>
    [JsonPropertyName("discounts")]
    public required IReadOnlyList<CommonIncentive> Discounts { get; init; }

    /// <summary>
    /// The time at which this packing option is no longer valid. In ISO 8601 datetime format with pattern <c>yyyy-MM-ddTHH:mm:ss.sssZ</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiration")]
    public DateTimeOffset? Expiration { get; init; }

    /// <summary>
    /// Fee for the offered option.
    /// </summary>
    [JsonPropertyName("fees")]
    public required IReadOnlyList<CommonIncentive> Fees { get; init; }

    /// <summary>
    /// Packing group IDs.
    /// </summary>
    [JsonPropertyName("packingGroups")]
    public required IReadOnlyList<string> PackingGroups { get; init; }

    /// <summary>
    /// Identifier of a packing option.
    /// </summary>
    [JsonPropertyName("packingOptionId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string PackingOptionId { get; init; }

    /// <summary>
    /// The status of the packing option. Possible values: <c>OFFERED</c>, <c>ACCEPTED</c>, <c>EXPIRED</c>.
    /// </summary>
    [JsonPropertyName("status")]
    [StringLength(1024, MinimumLength = 1)]
    public required string Status { get; init; }

    /// <summary>
    /// A list of possible configurations for this option.
    /// </summary>
    [JsonPropertyName("supportedConfigurations")]
    public required IReadOnlyList<CommonPackingConfiguration> SupportedConfigurations { get; init; }

    /// <summary>
    /// List of supported shipping modes.
    /// </summary>
    [JsonPropertyName("supportedShippingConfigurations")]
    public required IReadOnlyList<CommonShippingConfiguration> SupportedShippingConfigurations { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
