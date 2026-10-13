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
using WalmartApIs.Requests.ProductPricing;

namespace WalmartApIs.Api;

/// <summary>
/// Product pricing and competitive pricing operations
/// </summary>
public sealed class ProductPricing
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ProductPricing(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Returns competitive pricing information for a seller's offer listings
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetPricingResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetCompetitivePricingError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns competitive pricing information for a seller's offer listings based on seller SKU or Walmart Item ID .
    /// </remarks>
    public Task<GetPricingResponse> GetCompetitivePricing(GetCompetitivePricingRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/products/pricing/v4/competitivePrice"),
            [],
            [
                new Param("MarketplaceId", request.MarketplaceId),
                new Param("ItemType", request.ItemType),
                new Param("Skus", request.Skus),
                new Param("walmartItemIds", request.WalmartItemIds),
                new Param("CustomerType", request.CustomerType),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetPricingResponse>(),
            GetCompetitivePricingError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns competitive summary data for a batch of Walmart Item IDs
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CompetitiveSummaryBatchResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetCompetitiveSummaryError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// <b>Planned — not yet available in production.</b> Returns competitive summary including featured buying options and lowest priced offers
    /// for a batch of Walmart Item IDs .
    /// <para>
    /// <b>Phase 1 stub</b> — no upstream data source identified.
    /// Returns HTTP 501 until an upstream is confirmed.
    /// Track: .
    /// </para>
    /// </remarks>
    public Task<CompetitiveSummaryBatchResponse> GetCompetitiveSummary(GetCompetitiveSummaryRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/batches/products/pricing/v4/items/competitiveSummary"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CompetitiveSummaryBatchResponse>(),
            GetCompetitiveSummaryError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns the featured offer expected price for a batch of SKUs
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFeaturedOfferExpectedPriceBatchResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetFeaturedOfferExpectedPriceBatchError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// <b>Planned — not yet available in production.</b> Returns the featured offer expected price (FOEP) for a batch of seller SKUs.
    /// <para>
    /// <b>Phase 1 stub</b> — no upstream data source identified.
    /// Returns HTTP 501 until an upstream is confirmed.
    /// Track: .
    /// </para>
    /// </remarks>
    public Task<GetFeaturedOfferExpectedPriceBatchResponse> GetFeaturedOfferExpectedPriceBatch(GetFeaturedOfferExpectedPriceBatchOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/batches/products/pricing/v4/offer/featuredOfferExpectedPrice"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<GetFeaturedOfferExpectedPriceBatchResponse>(),
            GetFeaturedOfferExpectedPriceBatchError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns the lowest priced offers for a single item by Walmart Item ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetOffersResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetItemOffersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the lowest priced offers for a single item based on Walmart Item ID and item condition.
    /// <para>
    /// Uses Walmart Item ID as the primary identifier(ASIN not supported —
    /// no ASIN resolver exists in the Walmart platform; IQS queries by product.item_id).
    /// </para>
    /// <para>
    /// Backed by IQS catalog_index cross-seller query (same as getListingOffers hop-2).
    /// Returns 404 when no offers are found for the given itemId.
    /// </para>
    /// </remarks>
    public Task<GetOffersResponse> GetItemOffers(GetItemOffersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/products/pricing/v4/items/{itemId}/offers"),
            [new TemplateParam("itemId", request.ItemId)],
            [
                new Param("MarketplaceId", request.MarketplaceId),
                new Param("ItemCondition", request.ItemCondition),
                new Param("CustomerType", request.CustomerType),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetOffersResponse>(),
            GetItemOffersError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns the lowest priced offers for a batch of items by Walmart Item ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetItemOffersBatchResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetItemOffersBatchError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Batch version of getItemOffers. Accepts up to 20 Walmart Item ID requests.
    /// Uses Walmart Item ID as the primary identifier.
    /// <para>
    /// Implemented as in-process fan-out over getItemOffers.
    /// Each item gets its own per-item HTTP status code in the response body;
    /// the outer HTTP response is always 200.
    /// Implemented: .
    /// </para>
    /// </remarks>
    public Task<GetItemOffersBatchResponse> GetItemOffersBatch(GetItemOffersBatchOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/batches/products/pricing/v4/itemOffers"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<GetItemOffersBatchResponse>(),
            GetItemOffersBatchError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns the lowest priced offers for a single SKU listing
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetOffersResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetListingOffersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the lowest priced offers for a single SKU listing, based on SKU and item condition.
    /// </remarks>
    public Task<GetOffersResponse> GetListingOffers(GetListingOffersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/products/pricing/v4/listings/{SellerSKU}/offers"),
            [new TemplateParam("SellerSKU", request.SellerSku)],
            [
                new Param("MarketplaceId", request.MarketplaceId),
                new Param("ItemCondition", request.ItemCondition),
                new Param("CustomerType", request.CustomerType),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetOffersResponse>(),
            GetListingOffersError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns the lowest priced offers for a batch of SKU listings
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetListingOffersBatchResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetListingOffersBatchError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Batch version of getListingOffers. Accepts up to 20 SKU requests.
    /// <para>
    /// Implemented as in-process fan-out over getListingOffers (IQS-backed).
    /// Each SKU gets its own per-item HTTP status code in the response body;
    /// the outer HTTP response is always 200.
    /// Implemented: .
    /// </para>
    /// </remarks>
    public Task<GetListingOffersBatchResponse> GetListingOffersBatch(GetListingOffersBatchOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/batches/products/pricing/v4/listingOffers"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<GetListingOffersBatchResponse>(),
            GetListingOffersBatchError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns pricing information for a seller's offer listings
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetPricingResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetPricingError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns pricing information for a seller's active offer listings based on seller SKU or Walmart Item ID .
    /// </remarks>
    public Task<GetPricingResponse> GetPricing(GetPricingRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/products/pricing/v4/price"),
            [],
            [
                new Param("MarketplaceId", request.MarketplaceId),
                new Param("ItemType", request.ItemType),
                new Param("Skus", request.Skus),
                new Param("walmartItemIds", request.WalmartItemIds),
                new Param("ItemCondition", request.ItemCondition),
                new Param("OfferType", request.OfferType),
                new Param("CustomerType", request.CustomerType),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetPricingResponse>(),
            GetPricingError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
