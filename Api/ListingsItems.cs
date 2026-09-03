using System;
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
    /// <param name="sellerId">Seller identifier</param>
    /// <param name="sku">Seller SKU identifying the listing</param>
    /// <param name="marketplaceIds"></param>
    /// <param name="issueLocale"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListingsItemSubmissionResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeleteListingsItemError"/> when the server returns an error response.</exception>
    public Task<ListingsItemSubmissionResponse> DeleteListingsItem(string sellerId,
        string sku,
        IReadOnlyList<string> marketplaceIds,
        string? issueLocale = "en_US",
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/listings/v4/items/{sellerId}/{sku}"),
            [new TemplateParam("sellerId", sellerId), new TemplateParam("sku", sku)],
            [new Param("marketplaceIds", marketplaceIds), new Param("issueLocale", issueLocale)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<ListingsItemSubmissionResponse>(),
            DeleteListingsItemErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns details about a listings item for a seller
    /// </summary>
    /// <param name="sellerId">Seller identifier</param>
    /// <param name="sku">Seller SKU identifying the listing</param>
    /// <param name="marketplaceIds"></param>
    /// <param name="includedData"></param>
    /// <param name="issueLocale">Locale for issue messages (e.g. en_US)</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Item1"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetListingsItemError"/> when the server returns an error response.</exception>
    public Task<Item1> GetListingsItem(string sellerId,
        string sku,
        IReadOnlyList<string> marketplaceIds,
        IReadOnlyList<IncludedDatum1>? includedData,
        string? issueLocale = "en_US",
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/listings/v4/items/{sellerId}/{sku}"),
            [new TemplateParam("sellerId", sellerId), new TemplateParam("sku", sku)],
            [new Param("marketplaceIds", marketplaceIds),
                new Param("issueLocale", issueLocale),
                new Param("includedData", includedData)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Item1>(),
            GetListingsItemErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Partially updates (patches) a listings item for a seller
    /// </summary>
    /// <param name="sellerId">Seller identifier</param>
    /// <param name="sku">Seller SKU identifying the listing</param>
    /// <param name="marketplaceIds"></param>
    /// <param name="body"></param>
    /// <param name="issueLocale"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListingsItemSubmissionResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="PatchListingsItemError"/> when the server returns an error response.</exception>
    public Task<ListingsItemSubmissionResponse> PatchListingsItem(string sellerId,
        string sku,
        IReadOnlyList<string> marketplaceIds,
        ListingsItemPatchRequest body,
        string? issueLocale = "en_US",
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/listings/v4/items/{sellerId}/{sku}"),
            [new TemplateParam("sellerId", sellerId), new TemplateParam("sku", sku)],
            [new Param("marketplaceIds", marketplaceIds), new Param("issueLocale", issueLocale)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            new HttpMethod("PATCH"),
            JsonRequest.Create(body),
            JsonResponse.Create<ListingsItemSubmissionResponse>(),
            PatchListingsItemErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Creates or fully updates an existing listings item for a seller
    /// </summary>
    /// <param name="sellerId">Seller identifier</param>
    /// <param name="sku">Seller SKU identifying the listing</param>
    /// <param name="marketplaceIds"></param>
    /// <param name="body"></param>
    /// <param name="issueLocale"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListingsItemSubmissionResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="PutListingsItemError"/> when the server returns an error response.</exception>
    public Task<ListingsItemSubmissionResponse> PutListingsItem(string sellerId,
        string sku,
        IReadOnlyList<string> marketplaceIds,
        ListingsItemPutRequest body,
        string? issueLocale = "en_US",
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/listings/v4/items/{sellerId}/{sku}"),
            [new TemplateParam("sellerId", sellerId), new TemplateParam("sku", sku)],
            [new Param("marketplaceIds", marketplaceIds), new Param("issueLocale", issueLocale)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(body),
            JsonResponse.Create<ListingsItemSubmissionResponse>(),
            PutListingsItemErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Search a seller's listings items
    /// </summary>
    /// <param name="sellerId">Seller identifier</param>
    /// <param name="marketplaceIds"></param>
    /// <param name="includedData"></param>
    /// <param name="pageToken">Opaque cursor returned by a previous call for the next page</param>
    /// <param name="pageSize">Maximum number of results per page</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ItemSearchResults1"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SearchListingsItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of the seller's listings items. Mirrors Amazon
    /// SP-API <c>searchListingsItems</c> so an existing SP-API client can call the
    /// seller-level collection endpoint (no SKU in the path) against v4.
    /// </remarks>
    public Task<ItemSearchResults1> SearchListingsItems(string sellerId,
        IReadOnlyList<string> marketplaceIds,
        IReadOnlyList<IncludedDatum1>? includedData,
        string? pageToken,
        int? pageSize = 10,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/listings/v4/items/{sellerId}"),
            [new TemplateParam("sellerId", sellerId)],
            [new Param("marketplaceIds", marketplaceIds),
                new Param("includedData", includedData),
                new Param("pageSize", pageSize),
                new Param("pageToken", pageToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ItemSearchResults1>(),
            SearchListingsItemsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
