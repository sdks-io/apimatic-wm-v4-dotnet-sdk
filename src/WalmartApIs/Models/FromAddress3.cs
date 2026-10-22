using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// From address
/// </summary>
public record FromAddress3
{
    /// <summary>
    /// Contact name. &lt;br/&gt;&lt;b&gt;Applicable to SWW only.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("contactName")]
    public required string ContactName { get; init; }

    /// <summary>
    /// Company name. &lt;br/&gt;&lt;b&gt;Applicable to SWW only.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("companyName")]
    public string? CompanyName { get; init; }

    /// <summary>
    /// Address Line 1. &lt;br/&gt;&lt;b&gt;Applicable to SWW only.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("addressLine1")]
    public required string AddressLine1 { get; init; }

    /// <summary>
    /// Address Line 2. &lt;br/&gt;&lt;b&gt;Applicable to SWW only.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addressLine2")]
    public string? AddressLine2 { get; init; }

    /// <summary>
    /// City of the from address location. &lt;br/&gt;&lt;b&gt;Applicable to SWW only.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; init; }

    /// <summary>
    /// State or province of the from address. Use the standard two-letter code where applicable. &lt;br/&gt;&lt;b&gt;Applicable to SWW only.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("state")]
    public required string State { get; init; }

    /// <summary>
    /// ZIP or postal code of the from address location. &lt;br/&gt;&lt;b&gt;Applicable to SWW only.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("postalCode")]
    public required string PostalCode { get; init; }

    /// <summary>
    /// Country code of the from address location (example, US, CN). &lt;br/&gt;&lt;b&gt;Applicable to SWW only.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("country")]
    public required string Country { get; init; }

    /// <summary>
    /// Phone number associated with the from address location. &lt;br/&gt;&lt;b&gt;Applicable to SWW only.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("phone")]
    public required string Phone { get; init; }

    /// <summary>
    /// Email address associated with the from address location. &lt;br/&gt;&lt;b&gt;Applicable to SWW only.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
