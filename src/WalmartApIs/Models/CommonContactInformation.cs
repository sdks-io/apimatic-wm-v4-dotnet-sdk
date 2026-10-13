using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The seller's contact information.
/// </summary>
public record CommonContactInformation
{
    /// <summary>
    /// The email address.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("email")]
    [StringLength(1024, MinimumLength = 1)]
    public string? Email { get; init; }

    /// <summary>
    /// The contact's name.
    /// </summary>
    [JsonPropertyName("name")]
    [StringLength(50, MinimumLength = 1)]
    public required string Name { get; init; }

    /// <summary>
    /// The phone number.
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    [StringLength(20, MinimumLength = 1)]
    public required string PhoneNumber { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
