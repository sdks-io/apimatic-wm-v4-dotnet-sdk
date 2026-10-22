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
using WalmartApIs.Requests.RecommendationsApi;

namespace WalmartApIs.Api;

/// <summary>
/// APIs for providing recommendations to sellers.
/// </summary>
public sealed class RecommendationsApi
{
    private readonly RawClient _rawClient;
    private readonly Server _server;

    internal RecommendationsApi(RawClient rawClient, Server server)
    {
        _rawClient = rawClient;
        _server = server;
    }

    /// <summary>
    /// Fulfill with WFS Recommendations
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3WfsRecommendationFulfilWithWfsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetFulfillWithWfsRecommendationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Use <b>Fulfill With WFS Recommendations</b> to identify which seller-fulfilled items in your catalog Walmart suggests could potentially perform best when fulfilled by WFS. These suggestions are available on demand, and suggestions are refreshed the 1st and 15th of each month.
    /// <para>
    /// Key attributes include:
    /// </para>
    /// <list type="bullet">
    ///   <item><description><b>estimatedSalesLift</b>: The estimated increase in sales you could see if you converted the suggested items from seller-fulfilled to WFS.</description></item>
    /// </list>
    /// <list type="bullet">
    ///   <item><description><b>sellerFulfilledPast30DaysSales</b>: A historical view of your seller-fulfilled sales for the past 30 days.</description></item>
    ///   <item><description><b>walmartFulfilledEstimatedSales</b>: An estimated view of your potential sales if the suggested items were fulfilled by WFS.</description></item>
    /// </list>
    /// <para>
    /// You can use these suggestions to determine which items to convert to WFS.
    /// </para>
    /// </remarks>
    public Task<V3WfsRecommendationFulfilWithWfsResponse> GetFulfillWithWfsRecommendations(GetFulfillWithWfsRecommendationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/wfs/recommendation/fulfil-with-wfs"),
            [],
            [
                new Param("customerFavorite", request.CustomerFavorite),
                new Param("showInsights", request.ShowInsights),
                new Param("limit", request.Limit),
                new Param("offset", request.Offset),
                new Param("sort_by", request.SortBy),
                new Param("sort_order", request.SortOrder),
                new Param("showHiddenRecordsOnly", request.ShowHiddenRecordsOnly),
            ],
            [
                new HeaderParam("Content-Type", request.ContentType),
                new HeaderParam("Accept", request.Accept),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("wm_audit.origin_source", request.WmAuditOriginSource),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3WfsRecommendationFulfilWithWfsResponse>(),
            GetFulfillWithWfsRecommendationsError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Restock Recommendations
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3WfsRecommendationRestockResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetRestockRecommendationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Use <b>Restock Recommendations</b> to get Walmart-generated suggestions for the items you should restock with WFS based on your current inventory and forecasted sales demand. These suggestions are available on demand. Key attributes include:
    /// <list type="bullet">
    ///   <item><description><b>suggestedUnits</b>: The number of units we suggest you send of this item to WFS</description></item>
    ///   <item><description><b>forecastedSalesLift</b>: The estimated increase in sales you may see if your items are restocked according to our suggestions</description></item>
    ///   <item><description><b>totalForecastedSalesLost</b>: How much money you're estimated to lose out on if you don't restock your inventory</description></item>
    /// </list>
    /// <para>
    /// Once you determine which suggested items to restock, you can use the Create inbound shipment API to create a shipping plan to send inventory to WFS.
    /// </para>
    /// </remarks>
    public Task<V3WfsRecommendationRestockResponse> GetRestockRecommendations(GetRestockRecommendationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/wfs/recommendation/restock"),
            [],
            [
                new Param("customerFavorite", request.CustomerFavorite),
                new Param("showInsights", request.ShowInsights),
                new Param("limit", request.Limit),
                new Param("offset", request.Offset),
                new Param("sort_by", request.SortBy),
                new Param("sort_order", request.SortOrder),
                new Param("showHiddenRecordsOnly", request.ShowHiddenRecordsOnly),
            ],
            [
                new HeaderParam("Authorization", request.Authorization),
                new HeaderParam("Content-Type", request.ContentType),
                new HeaderParam("Accept", request.Accept),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("wm_audit.origin_source", request.WmAuditOriginSource),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3WfsRecommendationRestockResponse>(),
            GetRestockRecommendationsError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get WFS Recommended Shipment Quantity
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3WfsRecommendationShipmentQuantityResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetShipmentQuantityRecommendationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Use this API to get recommended shipment quantities for the items that you plan to send to Walmart Fulfillment Services (WFS) in order to achieve optimal inventory levels.
    /// </remarks>
    public Task<V3WfsRecommendationShipmentQuantityResponse> GetShipmentQuantityRecommendations(GetShipmentQuantityRecommendationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/wfs/recommendation/shipment-quantity"),
            [],
            [],
            [
                new HeaderParam("Authorization", request.Authorization),
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("Accept", request.Accept),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3WfsRecommendationShipmentQuantityResponse>(),
            GetShipmentQuantityRecommendationsError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Unpublished Recommendations
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3WfsRecommendationUnpublishedResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetUnpublishedRecommendationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This call helps you identify the estimated storage fees with Walmart for your unpublished WFS items.
    /// <para>
    /// Use <b>Unpublish Recommendations</b> to fetch a current list of your unpublished WFS items. This is available on demand.
    /// </para>
    /// <para>
    /// Key data attributes include:
    /// </para>
    /// <list type="bullet">
    ///   <item><description><b>unpublishedIssue</b>: The reason your item is currently unpublished with Walmart.</description></item>
    ///   <item><description><b>estimatedStorageFee</b>: The estimated storage costs associated with your unpublished WFS inventory.</description></item>
    ///   <item><description><b>totalunpublishedunitsstored</b>: The total quantity of units in WFS fulfillment centers for unpublished items.</description></item>
    /// </list>
    /// <para>
    /// Use this data to identify the reason these items are unpublished and the estimated costs associated with these unpublished items. By default, these suggestions will only include items that are active with an Available to Sell (ATS) quantity of 0.
    /// </para>
    /// </remarks>
    public Task<V3WfsRecommendationUnpublishedResponse> GetUnpublishedRecommendations(GetUnpublishedRecommendationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/wfs/recommendation/unpublished"),
            [],
            [
                new Param("customerFavorite", request.CustomerFavorite),
                new Param("showInsights", request.ShowInsights),
                new Param("limit", request.Limit),
                new Param("offset", request.Offset),
                new Param("sort_by", request.SortBy),
                new Param("sort_order", request.SortOrder),
            ],
            [
                new HeaderParam("Content-Type", request.ContentType),
                new HeaderParam("Accept", request.Accept),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("wm_audit.origin_source", request.WmAuditOriginSource),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3WfsRecommendationUnpublishedResponse>(),
            GetUnpublishedRecommendationsError.Response,
            [],
            requestOptions,
            cancellationToken);
}
