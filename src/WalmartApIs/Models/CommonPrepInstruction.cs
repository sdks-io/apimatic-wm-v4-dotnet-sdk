using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Information pertaining to the preparation of inbound goods.
/// </summary>
public record CommonPrepInstruction
{
    /// <summary>
    /// The type and amount of currency.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fee")]
    public CommonCurrency? Fee { get; init; }

    /// <summary>
    /// Owner of the preparations. Options include <c>SELLER</c> or <c>NONE</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("prepOwner")]
    [StringLength(1024, MinimumLength = 1)]
    public string? PrepOwner { get; init; }

    /// <summary>
    /// Type of preparation that should be done.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("prepType")]
    [StringLength(1024, MinimumLength = 1)]
    public string? PrepType { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
