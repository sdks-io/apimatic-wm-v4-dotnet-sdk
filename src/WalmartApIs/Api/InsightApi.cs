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
using WalmartApIs.Requests.InsightApi;

namespace WalmartApIs.Api;

public sealed class InsightApi
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal InsightApi(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Item count with listing quality issues
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3InsightsItemsListingQualityCountResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetCategoriesListError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Get a list of all item categories that have items with listing quality issues or brands for a seller.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </remarks>
    public Task<V3InsightsItemsListingQualityCountResponse> GetCategoriesList(GetCategoriesListRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/insights/items/listingQuality/count"),
            [],
            [
                new Param("viewTrendingItems", request.ViewTrendingItems),
                new Param("wfsFlag", request.WfsFlag),
                new Param("hasIssue", request.HasIssue),
                new Param("type", request.Type),
                new Param("inDemandIndicator", request.InDemandIndicator),
                new Param("limit", request.Limit),
                new Param("offset", request.Offset),
            ],
            [
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3InsightsItemsListingQualityCountResponse>(),
            GetCategoriesListError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Seller Listing Quality Score
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3InsightsItemsListingQualityScoreResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetListingQualityScoreError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Get the total Listing Quality Score for a seller's entire item catalog.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </remarks>
    public Task<V3InsightsItemsListingQualityScoreResponse> GetListingQualityScore(GetListingQualityScoreRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/insights/items/listingQuality/score"),
            [],
            [new Param("viewTrendingItems", request.ViewTrendingItems), new Param("wfsFlag", request.WfsFlag)],
            [
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3InsightsItemsListingQualityScoreResponse>(),
            GetListingQualityScoreError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Pro Seller Badge Status
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3InsightsProsellerbadgeResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetProSellerBadgeInfoError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// The Pro Seller badge status will provide you with information regarding your current badge status as well as the progress you've made in meeting the criteria.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </remarks>
    public Task<V3InsightsProsellerbadgeResponse> GetProSellerBadgeInfo(GetProSellerBadgeInfoRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/insights/prosellerbadge"),
            [],
            [],
            [
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3InsightsProsellerbadgeResponse>(),
            GetProSellerBadgeInfoError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Pro Seller Tier and Rewards Status
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3InsightsSellerIncentivesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetSellerIncentivesInfoError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// The Pro Seller Tier and Rewards Status API allows you to check your seller’s current tier status within the Pro Seller program, a three-tier incentive structure consisting of Rising, Advanced, and Pro Seller levels in US and a single-tier i.e Pro Seller in CA.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </remarks>
    public Task<V3InsightsSellerIncentivesResponse> GetSellerIncentivesInfo(GetSellerIncentivesInfoRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/insights/sellerIncentives"),
            [],
            [],
            [
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3InsightsSellerIncentivesResponse>(),
            GetSellerIncentivesInfoError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Unpublished Item Counts
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3InsightsItemsUnpublishedCountsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetUnpublishedItemCountError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API allows you to get the count of unpublished items.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </remarks>
    public Task<V3InsightsItemsUnpublishedCountsResponse> GetUnpublishedItemCount(GetUnpublishedItemCountRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/insights/items/unpublished/counts"),
            [],
            [new Param("fromDate", request.FromDate)],
            [
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3InsightsItemsUnpublishedCountsResponse>(),
            GetUnpublishedItemCountError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Unpublished Items
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3InsightsItemsUnpublishedItemsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetUnpublishedItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Get Unpublished Items&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </remarks>
    public Task<V3InsightsItemsUnpublishedItemsResponse> GetUnpublishedItems(GetUnpublishedItemsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/insights/items/unpublished/items"),
            [],
            [
                new Param("fromDate", request.FromDate),
                new Param("unpublishedReasonCode", request.UnpublishedReasonCode),
                new Param("limit", request.Limit),
                new Param("offerLifecycleStatus", request.OfferLifecycleStatus),
                new Param("marketTrending", request.MarketTrending),
                new Param("itemsWithInventory", request.ItemsWithInventory),
                new Param("isCustomerFavorite", request.IsCustomerFavorite),
            ],
            [
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3InsightsItemsUnpublishedItemsResponse>(),
            GetUnpublishedItemsError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Item Listing Quality Details
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3InsightsItemsListingQualityItemsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ItemsDetailsForListingError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Get each item's listing quality details including: item quality score, offer score, content score and issues, and item performance.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </remarks>
    public Task<V3InsightsItemsListingQualityItemsResponse> ItemsDetailsForListing(ItemsDetailsForListingRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/insights/items/listingQuality/items"),
            [],
            [
                new Param("limit", request.Limit),
                new Param("nextCursor", request.NextCursor),
                new Param("offset", request.Offset),
            ],
            [
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3InsightsItemsListingQualityItemsResponse>(),
            ItemsDetailsForListingError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
