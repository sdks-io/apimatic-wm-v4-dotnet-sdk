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
using WalmartApIs.Requests.Catalog;

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
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Item"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetCatalogItemError"/> when the server returns an error response.</exception>
    public Task<Item> GetCatalogItem(GetCatalogItemRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/catalog/v4/items/{walmartItemId}"),
            [new TemplateParam("walmartItemId", request.WalmartItemId)],
            [new Param("marketplaceIds", request.MarketplaceIds), new Param("includedData", request.IncludedData)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Item>(),
            GetCatalogItemError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Search for items in the Walmart Marketplace catalog
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ItemSearchResults"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="SearchCatalogItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Search the Walmart Marketplace catalog using keywords, WalmartItemId,
    /// GTIN, UPC, or seller SKU. Returns matching catalog items.
    /// </remarks>
    public Task<ItemSearchResults> SearchCatalogItems(SearchCatalogItemsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/catalog/v4/items"),
            [],
            [
                new Param("marketplaceIds", request.MarketplaceIds),
                new Param("keywords", request.Keywords),
                new Param("walmartItemIds", request.WalmartItemIds),
                new Param("sellerSku", request.SellerSku),
                new Param("gtin", request.Gtin),
                new Param("upc", request.Upc),
                new Param("includedData", request.IncludedData),
                new Param("pageSize", request.PageSize),
                new Param("pageToken", request.PageToken),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ItemSearchResults>(),
            SearchCatalogItemsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
