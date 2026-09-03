using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Api;

public sealed class Catalog
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Catalog(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Retrieve details for an item in the Walmart Marketplace catalog
    /// </summary>
    /// <param name="walmartItemId">Walmart Item ID (14-digit numeric identifier)</param>
    /// <param name="marketplaceIds">Walmart marketplace identifiers. Use WALMART_US for the US marketplace.</param>
    /// <param name="includedData">Data sections to include in the response</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Item"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetCatalogItemError"/> when the server returns an error response.</exception>
    public Task<Item> GetCatalogItem(string walmartItemId,
        IReadOnlyList<string> marketplaceIds,
        IReadOnlyList<IncludedDatum>? includedData,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/catalog/v4/items/{walmartItemId}"),
            [new TemplateParam("walmartItemId", walmartItemId)],
            [new Param("marketplaceIds", marketplaceIds), new Param("includedData", includedData)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Item>(),
            GetCatalogItemErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Search for items in the Walmart Marketplace catalog
    /// </summary>
    /// <param name="marketplaceIds">Walmart marketplace identifiers. Use WALMART_US for the US marketplace.</param>
    /// <param name="keywords">Keyword search terms</param>
    /// <param name="walmartItemIds">Comma-separated Walmart Item IDs (14-digit). Max 20.</param>
    /// <param name="sellerSku">Seller-defined SKU</param>
    /// <param name="gtin">Global Trade Item Number (14-digit)</param>
    /// <param name="upc">Universal Product Code (12-digit)</param>
    /// <param name="includedData">Data sections to include in the response</param>
    /// <param name="pageToken">Token for the next page of results, obtained from <c>pagination.nextToken</c> in a previous response. <b>Known limitation:</b> Cursor-based pagination is not currently supported for keyword search. The PIQS search backend (<c>/v3/items/walmart/search</c>) does not return a <c>nextCursor</c> and does not honour this parameter. Results are capped at 40 items per call. Reserved for future use once PIQS exposes pagination support.</param>
    /// <param name="pageSize">Number of results per page (1–20). <b>Known limitation:</b> The PIQS keyword search backend hard-caps results at 40 items per call regardless of this value.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ItemSearchResults"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SearchCatalogItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Search the Walmart Marketplace catalog using keywords, WalmartItemId,
    /// GTIN, UPC, or seller SKU. Returns matching catalog items.
    /// </remarks>
    public Task<ItemSearchResults> SearchCatalogItems(IReadOnlyList<string> marketplaceIds,
        string? keywords,
        string? walmartItemIds,
        string? sellerSku,
        string? gtin,
        string? upc,
        IReadOnlyList<IncludedDatum>? includedData,
        string? pageToken,
        int? pageSize = 10,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/catalog/v4/items"),
            [],
            [new Param("marketplaceIds", marketplaceIds),
                new Param("keywords", keywords),
                new Param("walmartItemIds", walmartItemIds),
                new Param("sellerSku", sellerSku),
                new Param("gtin", gtin),
                new Param("upc", upc),
                new Param("includedData", includedData),
                new Param("pageSize", pageSize),
                new Param("pageToken", pageToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ItemSearchResults>(),
            SearchCatalogItemsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
