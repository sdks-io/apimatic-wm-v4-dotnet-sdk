using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record SubmitNdrFeedbackRequest
{
    [JsonPropertyName("sellerTrackingId")]
    public required string SellerTrackingId { get; init; }

    [JsonPropertyName("ndrAction")]
    public required NdrAction NdrAction { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("comments")]
    public string? Comments { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
