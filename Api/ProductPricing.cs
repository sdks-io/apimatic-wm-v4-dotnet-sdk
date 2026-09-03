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
    /// <param name="marketplaceId">A marketplace identifier. Specifies the marketplace for which prices are returned.</param>
    /// <param name="itemType">Indicates whether Walmart Item ID values or seller SKU values are used to identify items.</param>
    /// <param name="skus">A list of up to twenty seller SKU values used to identify items in the given marketplace.</param>
    /// <param name="walmartItemIds">A list of up to twenty Walmart Item ID values used to identify items in the given marketplace.</param>
    /// <param name="customerType">Indicates whether to request pricing information from the point of view of Consumer or Business buyers. Default is Consumer.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetPricingResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetCompetitivePricingError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns competitive pricing information for a seller's offer listings based on seller SKU or Walmart Item ID .
    /// </remarks>
    public Task<GetPricingResponse> GetCompetitivePricing(string marketplaceId,
        ItemType itemType,
        IReadOnlyList<string>? skus,
        IReadOnlyList<string>? walmartItemIds,
        CustomerType? customerType,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/products/pricing/v4/competitivePrice"),
            [],
            [new Param("MarketplaceId", marketplaceId),
                new Param("ItemType", itemType),
                new Param("Skus", skus),
                new Param("walmartItemIds", walmartItemIds),
                new Param("CustomerType", customerType)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetPricingResponse>(),
            GetCompetitivePricingErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns competitive summary data for a batch of Walmart Item IDs
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CompetitiveSummaryBatchResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetCompetitiveSummaryError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// <b>Planned — not yet available in production.</b> Returns competitive summary including featured buying options and lowest priced offers
    /// for a batch of Walmart Item IDs .
    /// <para>
    /// <b>Phase 1 stub</b> — no upstream data source identified.
    /// Returns HTTP 501 until an upstream is confirmed.
    /// Track: .
    /// </para>
    /// </remarks>
    public Task<CompetitiveSummaryBatchResponse> GetCompetitiveSummary(CompetitiveSummaryBatchRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/batches/products/pricing/v4/items/competitiveSummary"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CompetitiveSummaryBatchResponse>(),
            GetCompetitiveSummaryErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the featured offer expected price for a batch of SKUs
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFeaturedOfferExpectedPriceBatchResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFeaturedOfferExpectedPriceBatchError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// <b>Planned — not yet available in production.</b> Returns the featured offer expected price (FOEP) for a batch of seller SKUs.
    /// <para>
    /// <b>Phase 1 stub</b> — no upstream data source identified.
    /// Returns HTTP 501 until an upstream is confirmed.
    /// Track: .
    /// </para>
    /// </remarks>
    public Task<GetFeaturedOfferExpectedPriceBatchResponse> GetFeaturedOfferExpectedPriceBatch(GetFeaturedOfferExpectedPriceBatchRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/batches/products/pricing/v4/offer/featuredOfferExpectedPrice"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<GetFeaturedOfferExpectedPriceBatchResponse>(),
            GetFeaturedOfferExpectedPriceBatchErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the lowest priced offers for a single item by Walmart Item ID
    /// </summary>
    /// <param name="itemId">The Walmart Item ID of the item.</param>
    /// <param name="marketplaceId">A marketplace identifier. Specifies the marketplace for which prices are returned.</param>
    /// <param name="itemCondition">Filters the offer listings based on item condition. Possible values: New, Used, Collectible, Refurbished, Club.</param>
    /// <param name="customerType">Indicates whether to request Consumer or Business offers. Default is Consumer.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetOffersResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetItemOffersError"/> when the server returns an error response.</exception>
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
    public Task<GetOffersResponse> GetItemOffers(string itemId,
        string marketplaceId,
        ConditionType2 itemCondition,
        CustomerType? customerType,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/products/pricing/v4/items/{itemId}/offers"),
            [new TemplateParam("itemId", itemId)],
            [new Param("MarketplaceId", marketplaceId),
                new Param("ItemCondition", itemCondition),
                new Param("CustomerType", customerType)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetOffersResponse>(),
            GetItemOffersErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the lowest priced offers for a batch of items by Walmart Item ID
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetItemOffersBatchResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetItemOffersBatchError"/> when the server returns an error response.</exception>
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
    public Task<GetItemOffersBatchResponse> GetItemOffersBatch(GetItemOffersBatchRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/batches/products/pricing/v4/itemOffers"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<GetItemOffersBatchResponse>(),
            GetItemOffersBatchErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the lowest priced offers for a single SKU listing
    /// </summary>
    /// <param name="sellerSku">Identifies an item in the given marketplace. SellerSKU is qualified by the seller's SellerId.</param>
    /// <param name="marketplaceId">A marketplace identifier. Specifies the marketplace for which prices are returned.</param>
    /// <param name="itemCondition">Filters the offer listings based on item condition. Possible values: New, Used, Collectible, Refurbished, Club.</param>
    /// <param name="customerType">Indicates whether to request Consumer or Business offers. Default is Consumer.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetOffersResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetListingOffersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the lowest priced offers for a single SKU listing, based on SKU and item condition.
    /// </remarks>
    public Task<GetOffersResponse> GetListingOffers(string sellerSku,
        string marketplaceId,
        ConditionType2 itemCondition,
        CustomerType? customerType,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/products/pricing/v4/listings/{SellerSKU}/offers"),
            [new TemplateParam("SellerSKU", sellerSku)],
            [new Param("MarketplaceId", marketplaceId),
                new Param("ItemCondition", itemCondition),
                new Param("CustomerType", customerType)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetOffersResponse>(),
            GetListingOffersErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the lowest priced offers for a batch of SKU listings
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetListingOffersBatchResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetListingOffersBatchError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Batch version of getListingOffers. Accepts up to 20 SKU requests.
    /// <para>
    /// Implemented as in-process fan-out over getListingOffers (IQS-backed).
    /// Each SKU gets its own per-item HTTP status code in the response body;
    /// the outer HTTP response is always 200.
    /// Implemented: .
    /// </para>
    /// </remarks>
    public Task<GetListingOffersBatchResponse> GetListingOffersBatch(GetListingOffersBatchRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/batches/products/pricing/v4/listingOffers"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<GetListingOffersBatchResponse>(),
            GetListingOffersBatchErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns pricing information for a seller's offer listings
    /// </summary>
    /// <param name="marketplaceId">A marketplace identifier. Specifies the marketplace for which prices are returned.</param>
    /// <param name="itemType">Indicates whether Walmart Item ID values or seller SKU values are used to identify items.</param>
    /// <param name="skus">A list of up to twenty seller SKU values used to identify items in the given marketplace.</param>
    /// <param name="walmartItemIds">A list of up to twenty Walmart Item ID values used to identify items in the given marketplace.</param>
    /// <param name="itemCondition">Filters the offer listings based on item condition. Possible values: New, Used, Collectible, Refurbished, Club.</param>
    /// <param name="offerType">Indicates whether to request pricing information for the seller's B2C or B2B offers. Default is B2C.</param>
    /// <param name="customerType">Indicates whether to request Consumer or Business offers. Default is Consumer.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetPricingResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetPricingError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns pricing information for a seller's active offer listings based on seller SKU or Walmart Item ID .
    /// </remarks>
    public Task<GetPricingResponse> GetPricing(string marketplaceId,
        ItemType itemType,
        IReadOnlyList<string>? skus,
        IReadOnlyList<string>? walmartItemIds,
        ConditionType2? itemCondition,
        OfferType? offerType,
        CustomerType? customerType,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/products/pricing/v4/price"),
            [],
            [new Param("MarketplaceId", marketplaceId),
                new Param("ItemType", itemType),
                new Param("Skus", skus),
                new Param("walmartItemIds", walmartItemIds),
                new Param("ItemCondition", itemCondition),
                new Param("OfferType", offerType),
                new Param("CustomerType", customerType)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetPricingResponse>(),
            GetPricingErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
