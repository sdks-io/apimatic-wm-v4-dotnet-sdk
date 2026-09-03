using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record WfsInventoryDetails
{
    /// <summary>
    /// Current listing state of the item on Walmart.com.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("publishingStatus")]
    public PublishingStatus? PublishingStatus { get; init; }

    /// <summary>
    /// Lifecycle state of the item in the Walmart catalog.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemLifecycle")]
    public ItemLifecycle? ItemLifecycle { get; init; }

    /// <summary>
    /// Stock health label based on current days of supply.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("stockStatus")]
    public StockStatus? StockStatus { get; init; }

    /// <summary>
    /// Units currently available to sell.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fulfillableQuantity")]
    [Minimum(0)]
    public int? FulfillableQuantity { get; init; }

    /// <summary>
    /// Units reserved and not available for immediate sale.
    /// Null if no breakdown data is available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reservedQuantity")]
    public ReservedQuantity? ReservedQuantity { get; init; }

    /// <summary>
    /// Units currently in transit and not yet available to sell.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inboundQuantity")]
    [Minimum(0)]
    public int? InboundQuantity { get; init; }

    /// <summary>
    /// Total units physically at fulfillment centers,
    /// including available, reserved, and unavailable units.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("onHandQuantity")]
    [Minimum(0)]
    public int? OnHandQuantity { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unavailableQuantity")]
    public WfsUnavailableQuantity? UnavailableQuantity { get; init; }

    /// <summary>
    /// Units under investigation for inventory discrepancies.
    /// Null if no units are under investigation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("researchingQuantity")]
    public ResearchingQuantity? ResearchingQuantity { get; init; }

    /// <summary>
    /// Units that cannot be fulfilled due to damage, defects, or expiry.
    /// Null if no unfulfillable units exist.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unfulfillableQuantity")]
    public UnfulfillableQuantity? UnfulfillableQuantity { get; init; }

    /// <summary>
    /// Units grouped by storage duration. Used for long-term storage fee assessment.
    /// 7 buckets: days365Plus, days365To450, and days450Plus reflect the upstream
    /// split-aged-buckets feature — days365Plus is the pre-split total.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inventoryAge")]
    public WfsInventoryAge? InventoryAge { get; init; }

    /// <summary>
    /// Date item first arrived at a fulfillment center. Null if not yet received.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("firstInStockDate")]
    public DateTimeOffset? FirstInStockDate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
