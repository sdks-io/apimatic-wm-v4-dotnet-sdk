using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.TaxFormApIs;

/// <summary>
/// The inputs of the GetTaxForms operation.
/// </summary>
public sealed record GetTaxFormsRequest
{
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
    /// Specifies the tenant identifier for multi-tenant contexts. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmTenantId { get; init; }
}
