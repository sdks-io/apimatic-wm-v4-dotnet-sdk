using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.TaxFormApIs;

/// <summary>
/// The inputs of the DownloadTaxForm operation.
/// </summary>
public sealed record DownloadTaxFormRequest
{
    /// <summary>
    /// The tax year associated with the payout (for example, 2024). &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    public required string PayoutYear { get; init; }

    /// <summary>
    /// The tax form type to download (for example, 1099-K).&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    public required string TaxFormType { get; init; }

    /// <summary>
    /// The unique form ID returned by the list tax forms endpoint.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    public required string FormId { get; init; }

    /// <summary>
    /// Access token obtained from the Token API. This is required for authenticating requests to Walmart Marketplace APIs.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmSecAccessToken { get; init; }

    /// <summary>
    /// A unique ID that identifies each API call and is used to track and debug issues. Use a randomly generated GUID for this ID. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Specifies the name of the Walmart service being called. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// The version of the global API used.
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

    /// <summary>
    /// Identifies the Walmart Marketplace region for the request. If not specified, US is used by default. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmMarket { get; init; }

    /// <summary>
    /// The partner (seller) identifier registered in Walmart Marketplace. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmPartnerId { get; init; }

    /// <summary>
    /// Specifies the tenant identifier. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmTenantId { get; init; }
}
