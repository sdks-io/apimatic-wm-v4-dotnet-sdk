using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record TokenDetailResponse
{
    /// <summary>
    /// The API categories with their corresponding access levels
    /// </summary>
    [JsonPropertyName("scopes")]
    public required Scopes Scopes { get; init; }

    /// <summary>
    /// The timestamp when the token expires
    /// </summary>
    [JsonPropertyName("expire_at")]
    public string ExpireAt { get; init; } = "1560973098000";

    /// <summary>
    /// The timestamp when the token is issued
    /// </summary>
    [JsonPropertyName("issued_at")]
    public string IssuedAt { get; init; } = "1560973098000";

    /// <summary>
    /// Whether the token is valid; boolean value of true or false
    /// </summary>
    [JsonPropertyName("is_valid")]
    public bool IsValid { get; init; } = true;

    /// <summary>
    /// Whether the keys Seller used are correctly associated
    /// </summary>
    [JsonPropertyName("is_channel_match")]
    public bool IsChannelMatch { get; init; } = true;

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
