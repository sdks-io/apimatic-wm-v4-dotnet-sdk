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
using WalmartApIs.Requests.Promotions;

namespace WalmartApIs.Api;

public sealed class Promotions
{
    private readonly RawClient _rawClient;
    private readonly Server _server;

    internal Promotions(RawClient rawClient, Server server)
    {
        _rawClient = rawClient;
        _server = server;
    }

    /// <summary>
    /// Promotional prices
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3PromoSkuResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetPromotionalPricesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves a list of promotional prices for a single SKU.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </remarks>
    public Task<V3PromoSkuResponse> GetPromotionalPrices(GetPromotionalPricesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/promo/sku/{sku}"),
            [new TemplateParam("sku", request.Sku)],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3PromoSkuResponse>(),
            GetPromotionalPricesError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update bulk promotional price
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeedId1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="PriceBulkUploadsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// The price and promotional price API allows you to creates, updates, or deletes promotional prices for multiple SKUs
    /// <para>
    ///  To set a new promotional price, set the "promotionSettingAction" attribute to "Create". To update an existing one, set the "promotionSettingAction" attribute to "Create" with promoId. To delete a promotional price, set the "promotionSettingAction" attribute to "Delete". To delete all promotions for a SKU, set the "promotionSettingAction" attribute to "Replace All"
    /// </para>
    /// <para>
    ///  Please Note:
    /// - The effective start date for a given promotion should be within 365 days from the current date and time.
    /// - The end date of a given promotion should be within 180 days from the start date and time. Any promotions beyond 180 days will result in an error &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<FeedId1> PriceBulkUploads(PriceBulkUploadsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/feeds?feedType=PRICE_AND_PROMOTION"),
            [],
            [new Param("feedType", request.FeedType)],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<FeedId1>(),
            PriceBulkUploadsError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update a promotional price
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3PriceResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdatePromotionalPricesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// The update a promotional price API allows you to creates, updates, or deletes promotional prices for single SKUs
    /// <para>
    ///  To set a new promotional price, set the "promotionSettingAction" attribute to "Create". To update an existing one, set the "promotionSettingAction" attribute to "Create" with promoId. To delete a promotional price, set the "promotionSettingAction" attribute to "Delete". To delete all promotions for a SKU, set the "promotionSettingAction" attribute to "Replace All"
    /// </para>
    /// <para>
    ///  Please Note:
    /// - The effective start date for a given promotion should be within 365 days from the current date and time.
    /// - The end date of a given promotion should be within 180 days from the start date and time. Any promotions beyond 180 days will result in an error &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3PriceResponse> UpdatePromotionalPrices(UpdatePromotionalPricesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/price"),
            [],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3PriceResponse>(),
            UpdatePromotionalPricesError.Response,
            [],
            requestOptions,
            cancellationToken);
}
