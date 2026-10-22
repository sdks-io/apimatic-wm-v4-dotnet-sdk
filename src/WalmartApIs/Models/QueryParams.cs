using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record QueryParams
{
    /// <summary>
    /// Return order identifier of the return order object.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnOrderId")]
    public string? ReturnOrderId { get; init; }

    /// <summary>
    /// A unique ID associated with the sales order for specified customer.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerOrderId")]
    public string? CustomerOrderId { get; init; }

    /// <summary>
    /// The status can be specified to query returns with a specific status. Valid values will be Initiated, Completed and Cancelled.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public IReadOnlyList<string>? Status { get; init; }

    /// <summary>
    /// Provides additional attributes related to replacement return orders in the response, if available. These attributes include replacementCustomerOrderID, returnType, rechargeReason, and returnCancellationReason. Allowed values are true or false.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("replacementInfo")]
    public string? ReplacementInfo { get; init; }

    /// <summary>
    /// Filters the results to return orders with the specified return type.
    /// Possible values are PREORDER, REPLACEMENT, or REFUND.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnType")]
    public IReadOnlyList<string>? ReturnType { get; init; }

    /// <summary>
    /// Start date for querying all return orders created after that date. Use one of the following UTC, ISO 8601 formats. Date example: '2013-08-16' Timestamp example: '2013-08-16T10:30:15Z'&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnCreationStartDate")]
    public string? ReturnCreationStartDate { get; init; }

    /// <summary>
    /// Limits the query to return orders created before this returnCreationEndDate. Use one of the following ISO 8601 formats: UTC date or timestamp. Examples: '2016-08-16T10:30:30.155Z' or '2016-08-16'&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnCreationEndDate")]
    public string? ReturnCreationEndDate { get; init; }

    /// <summary>
    /// Start Date for querying all return orders that were modified after that date. Use one of the following UTC, ISO 8601 formats: Date example: 2013-08-16, Timestamp example: 2013-08-16T10:30:15Z
    /// For dates with timezone, use the format 2020-04-17T10:42:41.000+0000 and encode '+' as %20.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnLastModifiedStartDate")]
    public string? ReturnLastModifiedStartDate { get; init; }

    /// <summary>
    /// Limits the query to the return orders that were modified before this date. Use one of the following UTC, ISO 8601 formats: Date example: 2013-08-16, Timestamp example: 2013-08-18T10:30:15Z
    /// For dates with timezone, use the format 2020-04-18T10:42:41.000+0000 and encode '+' as %20.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnLastModifiedEndDate")]
    public string? ReturnLastModifiedEndDate { get; init; }

    /// <summary>
    /// The number of orders to be returned. Cannot be larger than 200.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("limit")]
    public int? Limit { get; init; }

    /// <summary>
    /// Flag to get WFS returns. Valid value is Y.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX | CA | CL&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isWFSEnabled")]
    public string? IsWfsEnabled { get; init; }

    /// <summary>
    /// The starting offset of the first order required in the response. Cannot be greater than 1000.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX | CA | CL&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offset")]
    public int? Offset { get; init; }

    /// <summary>
    /// Unique ID of the Seller.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerId")]
    public string? SellerId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
