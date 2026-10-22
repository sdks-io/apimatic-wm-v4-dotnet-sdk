using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Defines the origin address from which the order will be shipped. This represents the seller’s fulfillment center location.
/// <para>
/// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
/// </para>
/// </summary>
public record FromAddress2
{
    /// <summary>
    /// The name of the primary contact at the fulfillment center. This name will appear on the shipping label.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("contactName")]
    public required string ContactName { get; init; }

    /// <summary>
    /// The name of the seller’s company or fulfillment center.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("companyName")]
    public string? CompanyName { get; init; }

    /// <summary>
    /// The primary street address of the fulfillment center.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("addressLine1")]
    public required string AddressLine1 { get; init; }

    /// <summary>
    /// Additional address details.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addressLine2")]
    public string? AddressLine2 { get; init; }

    /// <summary>
    /// City in which the fulfillment center is located.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; init; }

    /// <summary>
    /// State of the fulfillment center. Use the standard two-letter code.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("state")]
    public required string State { get; init; }

    /// <summary>
    /// ZIP or postal code of the fulfillment center’s location.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("postalCode")]
    public required string PostalCode { get; init; }

    /// <summary>
    /// The country code of the fulfillment center location.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("country")]
    public required string Country { get; init; }

    /// <summary>
    /// A valid phone number associated with the fulfillment center.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("phone")]
    public required string Phone { get; init; }

    /// <summary>
    /// The email of the seller.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
