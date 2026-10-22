using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Filter request.
/// </summary>
public record FilterRequest
{
    /// <summary>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | ELIGIBLE | To get items which are eligible for the program | string |
    /// | ENROLLED | To get items which are currently enrolled into the program | string |
    /// | COMPLETE | To get items which have attained target reviews through the program | string |
    /// </summary>
    [JsonPropertyName("itemStatus")]
    public required ItemStatus3 ItemStatus { get; init; }

    /// <summary>
    /// Date range to filter impressions, page views, and sales.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dateRange")]
    public DateRange? DateRange { get; init; } = DateRange._7Days;

    /// <summary>
    /// Category of the items.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("category")]
    public string? Category { get; init; }

    /// <summary>
    /// Price range of the items.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price")]
    public PriceRequest? Price { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
