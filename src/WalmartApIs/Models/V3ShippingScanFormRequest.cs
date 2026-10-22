using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3ShippingScanFormRequest
{
    /// <summary>
    /// Client-generated unique identifier for this scan form. Acts as a natural idempotency key — submitting a second POST with the same scanFormId returns 409 Conflict without creating a duplicate. Use a deterministic value (e.g., sellerId + shipOnDate + shipNode) to enable safe retries on network failure.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("scanFormId")]
    public required string ScanFormId { get; init; }

    /// <summary>
    /// Carrier short name for the scan form request. This value maps to shortName from the supported carriers API response.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("carrierName")]
    public required string CarrierName { get; init; }

    /// <summary>
    /// Ship-on date for the scan form. This is the date when the shipment is scheduled for carrier pickup. Format: yyyy-MM-dd.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("shipOnDate")]
    public required string ShipOnDate { get; init; }

    /// <summary>
    /// Origin (ship-from) address used for the scan form.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("fromAddress")]
    public required FromAddress5 FromAddress { get; init; }

    /// <summary>
    /// List of tracking numbers to include in the scan form. Maximum 200 tracking numbers per scan form (USPS limit).
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("trackingNumbers")]
    [MinLength(1)]
    [MaxLength(200)]
    public required IReadOnlyList<string> TrackingNumbers { get; init; }

    /// <summary>
    /// Carrier service type. This value maps to serviceTypes.name from the shipping estimates API response.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierServiceType")]
    public string? CarrierServiceType { get; init; }

    /// <summary>
    /// Requested scan form output format. Allowed values: PDF, ZPL, PNG, BLOB. Default is PDF.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("documentFormat")]
    public required string DocumentFormat { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
