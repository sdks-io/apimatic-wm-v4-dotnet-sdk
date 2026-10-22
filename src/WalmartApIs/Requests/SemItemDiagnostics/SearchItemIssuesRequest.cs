using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.SemItemDiagnostics;

/// <summary>
/// The inputs of the SearchItemIssues operation.
/// </summary>
public sealed record SearchItemIssuesRequest
{
    /// <summary>
    /// Specifies the name of the Walmart service being called.
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// A unique ID that identifies each API call and is used to track and debug issues. Use a randomly generated GUID for this ID.
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// The version of the global API used.
    /// </summary>
    public WmGlobalVersion WmGlobalVersion { get; init; } = WmGlobalVersion._31;

    /// <summary>
    /// Identifies the Walmart Marketplace region for the request.
    /// </summary>
    public WmMarket WmMarket { get; init; } = WmMarket.Us;

    /// <summary>
    /// The expected response content type.
    /// </summary>
    public Accept Accept { get; init; } = Accept.ApplicationJson;

    /// <summary>
    /// A unique ID to identify the consumer request by channel. Use the Consumer Channel Type received during onboarding.
    /// </summary>
    public string? WmConsumerChannelType { get; init; }

    /// <summary>
    /// Optional search request with pagination and filters.
    /// Defaults to <c>offset=0</c>, <c>limit=100</c> with no filters if body is absent.
    /// When no <c>issueCategory</c> filter is provided, only items with issues (<c>BLOCKED</c> or <c>LIMITED</c>) are returned.
    /// This reduces payload size and improves relevance — diagnostics API consumers typically want problems, not healthy-item confirmation.
    /// To include all items, explicitly pass <c>issueCategory</c> filter with all three values: <c>LIMITED</c>, <c>BLOCKED</c>, <c>NO_ISSUES</c>.
    /// </summary>
    public ItemDiagnosticSearchRequest? Body { get; init; }
}
