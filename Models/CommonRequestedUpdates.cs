using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Objects that were included in the update request.
/// </summary>
public record CommonRequestedUpdates
{
    /// <summary>
    /// A list of boxes that will be present in the shipment after the update.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxes")]
    public IReadOnlyList<CommonBoxUpdateInput>? Boxes { get; init; }

    /// <summary>
    /// A list of all items that will be present in the shipment after the update.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("items")]
    public IReadOnlyList<CommonItemInput>? Items { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
