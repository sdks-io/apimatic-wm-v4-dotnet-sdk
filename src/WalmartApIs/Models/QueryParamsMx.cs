using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record QueryParamsMx
{
    /// <summary>
    /// Return order identifier of the return order object as part of an array. This is the same as RMA number.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnOrderId")]
    public string? ReturnOrderId { get; init; }

    /// <summary>
    /// A unique ID associated with the sales order for the specified customer.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerOrderId")]
    public string? CustomerOrderId { get; init; }

    /// <summary>
    /// Start Date for querying all return orders that were created after that date. Use one of the following UTC, ISO 8601 formats: Date example: 2013-08-16, Timestamp example: 2013-08-18T10:30:15Z
    /// For dates with timezone, use the format 2020-04-18T10:42:41.000+0000 and encode '+' as %20.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnCreationStartDate")]
    public string? ReturnCreationStartDate { get; init; }

    /// <summary>
    /// Limits the query to the return orders that were created before this returnCreationEndDate. Use one of the following UTC, ISO 8601 formats: Date example: 2013-08-16, Timestamp example: 2013-08-18T10:30:15Z
    /// For dates with timezone, use the format 2020-04-18T10:42:41.000+0000 and encode '+' as %20.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnCreationEndDate")]
    public string? ReturnCreationEndDate { get; init; }

    /// <summary>
    /// The status can be specified to query returns with a specific status. Valid values will be Initiated, Completed and Cancelled.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public IReadOnlyList<string>? Status { get; init; }

    /// <summary>
    /// The number of orders to be returned. Cannot be larger than 200.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("limit")]
    public int? Limit { get; init; }

    /// <summary>
    /// Flag to get WFS returns. Valid value is Y.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isWFSEnabled")]
    public string? IsWfsEnabled { get; init; }

    /// <summary>
    /// The cursor from which the next set of records will be retrieved.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cursorMark")]
    public string? CursorMark { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
