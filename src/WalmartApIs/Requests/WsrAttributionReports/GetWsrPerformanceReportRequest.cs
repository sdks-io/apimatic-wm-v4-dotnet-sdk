using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.WsrAttributionReports;

/// <summary>
/// The inputs of the GetWsrPerformanceReport operation.
/// </summary>
public sealed record GetWsrPerformanceReportRequest
{
    /// <summary>
    /// Access token obtained from the Token API. This is required for authenticating requests to Walmart Marketplace APIs.
    /// </summary>
    public required string WmSecAccessToken { get; init; }

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
    /// A unique ID to identify the consumer request by channel. Use the Consumer Channel Type received during onboarding.
    /// </summary>
    public string? WmConsumerChannelType { get; init; }

    /// <summary>
    /// Performance report request with date range and optional filters
    /// </summary>
    public required WsrReportRequest Body { get; init; }
}
