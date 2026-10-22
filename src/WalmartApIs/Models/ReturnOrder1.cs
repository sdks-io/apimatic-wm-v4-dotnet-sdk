using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

public record ReturnOrder1
{
    /// <summary>
    /// returnOrderId.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnOrderId")]
    public string? ReturnOrderId { get; init; }

    /// <summary>
    /// customerOrderId.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerOrderId")]
    public string? CustomerOrderId { get; init; }

    /// <summary>
    /// customerEmail.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerEmail")]
    [Format(FormatKind.Email)]
    public string? CustomerEmail { get; init; }

    /// <summary>
    /// returnOrderDate.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX | CA |CL&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnOrderDate")]
    public DateTimeOffset? ReturnOrderDate { get; init; }

    /// <summary>
    /// customerName.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerName")]
    public CustomerName1? CustomerName { get; init; }

    /// <summary>
    /// returnOrderLines.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnOrderLines")]
    public IReadOnlyList<ReturnOrderLine1>? ReturnOrderLines { get; init; }

    /// <summary>
    /// returnOrderShipments.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnOrderShipments")]
    public IReadOnlyList<ReturnOrderShipment1>? ReturnOrderShipments { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
