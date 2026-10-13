using System;
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
using WalmartApIs.Requests.ListingsItems;

namespace WalmartApIs.Api;

public sealed class ListingsItems
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ListingsItems(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Deletes a listings item for a seller
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListingsItemSubmissionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteListingsItemError"/> when the server returns an error response.</exception>
    public Task<ListingsItemSubmissionResponse> DeleteListingsItem(DeleteListingsItemRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/listings/v4/items/{sellerId}/{sku}"),
            [new TemplateParam("sellerId", request.SellerId), new TemplateParam("sku", request.Sku)],
            [new Param("marketplaceIds", request.MarketplaceIds), new Param("issueLocale", request.IssueLocale)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<ListingsItemSubmissionResponse>(),
            DeleteListingsItemError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns details about a listings item for a seller
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Item1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetListingsItemError"/> when the server returns an error response.</exception>
    public Task<Item1> GetListingsItem(GetListingsItemRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/listings/v4/items/{sellerId}/{sku}"),
            [new TemplateParam("sellerId", request.SellerId), new TemplateParam("sku", request.Sku)],
            [
                new Param("marketplaceIds", request.MarketplaceIds),
                new Param("issueLocale", request.IssueLocale),
                new Param("includedData", request.IncludedData),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Item1>(),
            GetListingsItemError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Partially updates (patches) a listings item for a seller
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListingsItemSubmissionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="PatchListingsItemError"/> when the server returns an error response.</exception>
    public Task<ListingsItemSubmissionResponse> PatchListingsItem(PatchListingsItemRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/listings/v4/items/{sellerId}/{sku}"),
            [new TemplateParam("sellerId", request.SellerId), new TemplateParam("sku", request.Sku)],
            [new Param("marketplaceIds", request.MarketplaceIds), new Param("issueLocale", request.IssueLocale)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            new HttpMethod("PATCH"),
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ListingsItemSubmissionResponse>(),
            PatchListingsItemError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Creates or fully updates an existing listings item for a seller
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListingsItemSubmissionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="PutListingsItemError"/> when the server returns an error response.</exception>
    public Task<ListingsItemSubmissionResponse> PutListingsItem(PutListingsItemRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/listings/v4/items/{sellerId}/{sku}"),
            [new TemplateParam("sellerId", request.SellerId), new TemplateParam("sku", request.Sku)],
            [new Param("marketplaceIds", request.MarketplaceIds), new Param("issueLocale", request.IssueLocale)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ListingsItemSubmissionResponse>(),
            PutListingsItemError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Search a seller's listings items
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ItemSearchResults1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="SearchListingsItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of the seller's listings items. Mirrors Amazon
    /// SP-API <c>searchListingsItems</c> so an existing SP-API client can call the
    /// seller-level collection endpoint (no SKU in the path) against v4.
    /// </remarks>
    public Task<ItemSearchResults1> SearchListingsItems(SearchListingsItemsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/listings/v4/items/{sellerId}"),
            [new TemplateParam("sellerId", request.SellerId)],
            [
                new Param("marketplaceIds", request.MarketplaceIds),
                new Param("includedData", request.IncludedData),
                new Param("pageSize", request.PageSize),
                new Param("pageToken", request.PageToken),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ItemSearchResults1>(),
            SearchListingsItemsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
