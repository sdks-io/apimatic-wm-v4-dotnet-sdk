using System.Collections.Generic;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ListingsRestrictions;

/// <summary>
/// The inputs of the GetListingsRestrictions operation.
/// </summary>
public sealed record GetListingsRestrictionsRequest
{
    /// <summary>
    /// Walmart Item ID (maps to ASIN in Walmart Seller API)
    /// </summary>
    public required string Asin { get; init; }

    public required ConditionType1 ConditionType { get; init; }

    public required string SellerId { get; init; }

    public required IReadOnlyList<string> MarketplaceIds { get; init; }

    /// <summary>
    /// Locale for localized restriction reason messages
    /// </summary>
    public string ReasonLocale { get; init; } = "en_US";
}
