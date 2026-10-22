using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record TotalInsight1
{
    /// <summary>
    /// What you currently earn from seller-fulfilled items, based on your weekly average sales from the past 30 days.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerFulfilledPast30DaysSales")]
    public double? SellerFulfilledPast30DaysSales { get; init; }

    /// <summary>
    /// What we predict you’ll earn if you convert the following items to WFS and send the suggested quantities. This is the sum of your predicted WFS GMV in the 30 days after your items are available to sell. To leverage these suggestions, we recommend you convert and send your items to WFS within the next 4 weeks.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("walmartFulfilledEstimatedSales")]
    public double? WalmartFulfilledEstimatedSales { get; init; }

    /// <summary>
    /// Total estimated sales lift if these items are converted to WFS and sold within the next 30 days of recommendation generation. This is your Walmart-fulfilled GMV minus seller-fulfilled GMV.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalEstimatedSalesLift")]
    public double? TotalEstimatedSalesLift { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
