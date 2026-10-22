using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ItemDto
{
    /// <summary>
    /// Identifier of the payer entity issuing the tax form.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payerId")]
    public string? PayerId { get; init; }

    /// <summary>
    /// Taxpayer identification number associated with the payee.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tin")]
    public string? Tin { get; init; }

    /// <summary>
    /// Logical grouping identifier for related transactions or sub-accounts.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("groupId")]
    public string? GroupId { get; init; }

    /// <summary>
    /// Account identifier related to the payout or settlement.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("account")]
    public string? Account { get; init; }

    /// <summary>
    /// Unique tax form identifier referenced by the download endpoint.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("formId")]
    public string? FormId { get; init; }

    /// <summary>
    /// Form modification level or version indicator.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("formModLevel")]
    public string? FormModLevel { get; init; }

    /// <summary>
    /// Payee-level modification indicator.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payeeModLevel")]
    public string? PayeeModLevel { get; init; }

    /// <summary>
    /// Type of TIN provided (for example, SSN, EIN, ITIN).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tintype")]
    public string? Tintype { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
