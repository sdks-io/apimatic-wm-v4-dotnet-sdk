namespace WalmartApIs.Requests.ReportsApi;

/// <summary>
/// The inputs of the GetReconReport operation.
/// </summary>
public sealed record GetReconReportRequest
{
    /// <summary>
    /// The date for which the reconcilation file is available
    /// </summary>
    public required string ReportDate { get; init; }

    /// <summary>
    /// The access token retrieved in the Token API call
    /// </summary>
    public required string WmSecAccessToken { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and used to track and debug issues; use a random generated GUID for this ID
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Walmart Service Name
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// A unique ID to track the consumer request by channel. Use the Consumer Channel Type received during onboarding
    /// </summary>
    public string? WmConsumerChannelType { get; init; }
}
