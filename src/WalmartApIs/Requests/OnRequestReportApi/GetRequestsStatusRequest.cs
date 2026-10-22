using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.OnRequestReportApi;

/// <summary>
/// The inputs of the GetRequestsStatus operation.
/// </summary>
public sealed record GetRequestsStatusRequest
{
    /// <summary>
    /// Type of report for which the request is created. Example, ITEM for Item Report.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability:
    /// </para>
    /// <para>
    ///  ITEM: Global
    /// INVENTORY: Global
    /// LAGTIME: US|CA|MX
    /// Other Reports: US only&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required ReportType4 ReportType { get; init; }

    /// <summary>
    /// Version of report for which the request is created. Example, v1.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? ReportVersion { get; init; }

    /// <summary>
    /// Status of report request. Possible values are RECEIVED, INPROGRESS, READY, ERROR.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public RequestStatus4? RequestStatus { get; init; }

    /// <summary>
    /// Report request submittal start date for range of reports requested, in format: YYYY-MM-DDTHH:mm:ssZ
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? RequestSubmissionStartDate { get; init; }

    /// <summary>
    /// Report request submittal end date for range of reports requested, in format YYYY-MM-DDTHH:mm:ssZ
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? RequestSubmissionEndDate { get; init; }

    /// <summary>
    /// Access token obtained from the Token API. Required for authenticating requests to Walmart Marketplace APIs.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string WmSecAccessToken { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and used to track and debug issues; use a random generated GUID for this ID.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Specifies the name of the Walmart service being called.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// The target market of the API call.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required WmMarket1 WmMarket { get; init; }

    /// <summary>
    /// The version of the global API used.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

    /// <summary>
    /// Only supported Media Type : application/json
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string Accept { get; init; }

    /// <summary>
    /// A unique ID to track the consumer request by channel. Use the Consumer Channel Type received during onboarding.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? WmConsumerChannelType { get; init; }
}
