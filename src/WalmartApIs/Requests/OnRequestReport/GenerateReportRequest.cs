using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.OnRequestReport;

/// <summary>
/// The inputs of the GenerateReport operation.
/// </summary>
public sealed record GenerateReportRequest
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
    /// Version of report for which the request is created.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// <para>
    ///  |ReportType |Market Availabilty |Version Supported
    /// |--------|----------|----------
    /// | ITEM   |Global|  v1  (<b>v3 to v6 : US only</b>)
    /// |INVENTORY|Global| v1
    /// |LAGTIME|US,CA,MX| v1
    /// |DELIVERY_DEFECT|US only| v1
    /// |ITEM_PERFORMANCE|US only| v1 to v3
    /// |PROMO|US only| v1
    /// |RETURN_OVERRIDES|US only| v1
    /// |CPA|US only| v1
    /// |SHIPPING_CONFIGURATION|US only| v1
    /// |SHIPPING_PROGRAM|US only| v1
    /// |FITMENT_MISSING_ATTR|US only| v1
    /// |FITMENT_ACES_COVERAGE|US only| v1
    /// |BUYBOX|US only| v1
    /// |ASSORTMENT_RECOMMENDATIONS|US only| v1
    /// |CANCELLATION|US only| v1
    /// |INVENTORY_RECOMMENDATIONS|US only| v1 |
    /// </para>
    /// </summary>
    public required string ReportVersion { get; init; }

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

    /// <summary>
    /// Request body
    /// </summary>
    public V3ReportsReportRequestsRequest? Body { get; init; }
}
