using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains input information to update LTL tracking information.
/// </summary>
public record CommonLtlTrackingDetailInput
{
    /// <summary>
    /// The number of the carrier shipment acknowledgement document.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("billOfLadingNumber")]
    [StringLength(1024, MinimumLength = 1)]
    public string? BillOfLadingNumber { get; init; }

    /// <summary>
    /// Number associated with the freight bill.
    /// </summary>
    [JsonPropertyName("freightBillNumber")]
    [MinLength(1)]
    [MaxLength(1)]
    public required IReadOnlyList<string> FreightBillNumber { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
