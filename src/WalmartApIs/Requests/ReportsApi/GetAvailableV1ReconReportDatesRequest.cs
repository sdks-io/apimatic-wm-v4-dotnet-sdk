namespace WalmartApIs.Requests.ReportsApi;

/// <summary>
/// The inputs of the GetAvailableV1ReconReportDates operation.
/// </summary>
public sealed record GetAvailableV1ReconReportDatesRequest
{
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
