using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Origin (ship-from) address used for the scan form.
/// <para>
/// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
/// </para>
/// </summary>
public record FromAddress5
{
    /// <summary>
    /// Contact name for the origin address.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("contactName")]
    public required string ContactName { get; init; }

    /// <summary>
    /// Company name for the origin address.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("companyName")]
    public string? CompanyName { get; init; }

    /// <summary>
    /// First line of the origin street address.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("addressLine1")]
    public required string AddressLine1 { get; init; }

    /// <summary>
    /// Second line of the origin street address, such as suite or unit.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addressLine2")]
    public string? AddressLine2 { get; init; }

    /// <summary>
    /// Origin city name.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; init; }

    /// <summary>
    /// Origin state or province. Use the region code when available. For example, CA, AK.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("state")]
    public required string State { get; init; }

    /// <summary>
    /// Origin postal or ZIP code.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("postalCode")]
    public required string PostalCode { get; init; }

    /// <summary>
    /// Origin country code. Use a two-letter code. For example, US, CN, IN.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("country")]
    public required string Country { get; init; }

    /// <summary>
    /// Origin contact phone number.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("phone")]
    public required string Phone { get; init; }

    /// <summary>
    /// Origin contact email address.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
