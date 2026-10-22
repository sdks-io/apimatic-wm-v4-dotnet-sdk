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
using WalmartApIs.Requests.Prices;

namespace WalmartApIs.Api;

public sealed class Prices
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Prices(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create Repricer Strategy
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3RepricerStrategyResponse2"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateStrategyError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a new strategy for the seller.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </remarks>
    public Task<V3RepricerStrategyResponse2> CreateStrategy(CreateStrategyRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/repricer/strategy"),
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
            JsonResponse.Create<V3RepricerStrategyResponse2>(),
            CreateStrategyError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete Repricer Strategy
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="RejectRecommendationsResponsePayload"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteStrategyError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deletes the strategy.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </remarks>
    public Task<RejectRecommendationsResponsePayload> DeleteStrategy(DeleteStrategyRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/repricer/strategy/{strategyCollectionId}"),
            [new TemplateParam("strategyCollectionId", request.StrategyCollectionId)],
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
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<RejectRecommendationsResponsePayload>(),
            DeleteStrategyError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List of Price Incentive Items
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3PriceIncentivesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetAllIncentivesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Get Incentives API endpoint gives you the list of all price incentives for items in your catalog.
    /// <para>
    /// The details include Item Id, Product Name, Product Url, SKU Id, Target Price, current Price, Incentive Type, Incentive Status, Base referral fee, Reduced Referral Fee, Enrollment Type, Inventory count, Enrollment Date (epoch Timestamp), Start date (epoch Timestamp), Expiration date (epoch Timestamp), and Incentive Id.
    /// </para>
    /// <para>
    /// Target Price, Expiration date, Start date, Incentive Id, and Reduced Ref fee and Enrollment Type for WF items would not be shown (null values).
    /// </para>
    /// <para>
    /// Enrollment Type and Date for Eligible Reduced Referral Fee incentives will not show up.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3PriceIncentivesResponse> GetAllIncentives(GetAllIncentivesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/price/incentives"),
            [],
            [
                new Param("incentiveStatus", request.IncentiveStatus),
                new Param("limit", request.Limit),
                new Param("offset", request.Offset),
                new Param("sortBy", request.SortBy),
                new Param("sortOrder", request.SortOrder),
                new Param("incentiveType", request.IncentiveType),
            ],
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
            JsonResponse.Create<V3PriceIncentivesResponse>(),
            GetAllIncentivesError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Assign or Unassign Items to or from Repricer Strategy
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeedId1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetRepricerFeedError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Add/Remove one or more items from a strategy.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </remarks>
    public Task<FeedId1> GetRepricerFeed(GetRepricerFeedRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/repricerFeeds"),
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
            JsonResponse.Create<FeedId1>(),
            GetRepricerFeedError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List of Repricer Strategies
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3RepricerStrategiesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetStrategiesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Get the list of strategies.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </remarks>
    public Task<V3RepricerStrategiesResponse> GetStrategies(GetStrategiesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/repricer/strategies"),
            [],
            [new Param("offset", request.Offset), new Param("limit", request.Limit)],
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
            JsonResponse.Create<V3RepricerStrategiesResponse>(),
            GetStrategiesError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update pricing for multiple items in bulk
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeedId"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="PriceAndPromotionBulkUploadsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates prices and promotions in bulk for multiple items. You can modify the prices of multiple items in bulk using a price feed. This is useful for implementing pricing strategies across your catalog, such as seasonal discounts, competitive pricing adjustments, or clearance sales.
    /// <para>
    /// Each price feed can contain up to 10,000 items. To ensure optimal performance (feed processing time), we recommend limiting feeds to 1,000 items and keeping the payload under 10 MB.
    /// </para>
    /// <para>
    /// Use this API instead of the single price update API when updating prices for multiple items. For newly created items, ensure that the Walmart Part ID (WPID) has been assigned and that at least 24 hours have passed since item creation before submitting a bulk price update feed. The bulk price update Service Level Agreement (SLA) is 15 minutes.
    /// </para>
    /// <para>
    /// The price sequence guarantee is observed by the bulk price update functionality, subject to the following rules:
    /// </para>
    /// <para>
    /// &lt;ul&gt;&lt;li&gt;You may include the same Stock Keeping Unit (SKU) multiple times in a single feed. However, if a SKU is repeated in a feed, only one price will be applied.&lt;/li&gt;&lt;li&gt;The price sequence guarantee ensures that the latest price update, based on its creation timestamp, is the one that changes the item's price, overwriting the previous version.&lt;/li&gt;&lt;li&gt;Price updates received with an earlier timestamp are ignored. We recommend using UTC timestamps for the value of &lt;code&gt;feedDate&lt;/code&gt; in all feed-based bulk updates.&lt;/li&gt;&lt;/ul&gt;
    /// </para>
    /// <para>
    /// After submitting the price feed, wait at least 5 minutes before checking whether the bulk price update was successful. If a price update fails, for example, due to duplicate SKU entries, an error response will be returned.
    /// </para>
    /// <para>
    /// For more information and usage examples, refer to the &lt;a href="https://developer.walmart.com/global-marketplace/docs/update-pricing-for-multiple-items-bulk"&gt;Pricing API Guide&lt;/a&gt;.
    /// </para>
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </remarks>
    public Task<FeedId> PriceAndPromotionBulkUploads(PriceAndPromotionBulkUploadsRequest request,
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
            JsonResponse.Create<FeedId>(),
            PriceAndPromotionBulkUploadsError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update reduced referral fee incentives enrollment
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3FeedsFeedTypeIncentiveEnrollmentResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ReducedReferralFeeIncentivesEnrollmentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// You can use this API endpoint to enroll any eligible reduced referral fee incentive and unenroll any active reduced referral fee incentives.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </remarks>
    public Task<V3FeedsFeedTypeIncentiveEnrollmentResponse> ReducedReferralFeeIncentivesEnrollment(ReducedReferralFeeIncentivesEnrollmentRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/feeds?feedType=INCENTIVE_ENROLLMENT"),
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
            JsonResponse.Create<V3FeedsFeedTypeIncentiveEnrollmentResponse>(),
            ReducedReferralFeeIncentivesEnrollmentError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update pricing for a single item
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3PriceResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdatePriceError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the price of an item listed on Walmart Marketplace. Use this API to change the price of a single item. If you want to update pricing for multiple items, we recommend using the &lt;a href="https://developer.walmart.com/global-marketplace/reference/priceandpromotionbulkuploads"&gt;Update pricing for multiple items in bulk&lt;/a&gt; API.
    /// <para>
    /// For more information and usage examples, refer to the &lt;a href="https://developer.walmart.com/us-marketplace/docs/update-pricing-for-a-single-item"&gt;Pricing API Guide&lt;/a&gt;.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3PriceResponse> UpdatePrice(UpdatePriceRequest request,
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
            UpdatePriceError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Repricer Strategy
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3RepricerStrategyResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateStrategyError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the existing strategy.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </remarks>
    public Task<V3RepricerStrategyResponse> UpdateStrategy(UpdateStrategyRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/repricer/strategy/{strategyCollectionId}"),
            [new TemplateParam("strategyCollectionId", request.StrategyCollectionId)],
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
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3RepricerStrategyResponse>(),
            UpdateStrategyError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update the enrollment status of Walmart-funded incentive items
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3PriceIncentivesWfpreferenceResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateWalmartFundedIncentivesEnrollmentStatusError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// If you wish to permanently disable Walmart-funded incentives for all items of your catalog, you can use this API to set the Walmart-funded incentives program as OFF.
    /// <para>
    /// The default value of this variable is ON.
    /// </para>
    /// <para>
    /// Any changes to preferences will lock in (disable) the preference option for a period of 4 hours as indicated by isDisabled response field of the API.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3PriceIncentivesWfpreferenceResponse> UpdateWalmartFundedIncentivesEnrollmentStatus(UpdateWalmartFundedIncentivesEnrollmentStatusRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/price/incentives/wfpreference"),
            [],
            [new Param("autoEnrollEnabled", request.AutoEnrollEnabled)],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Put,
            EmptyBody.Instance,
            JsonResponse.Create<V3PriceIncentivesWfpreferenceResponse>(),
            UpdateWalmartFundedIncentivesEnrollmentStatusError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update walmart funded incentives enrollment
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeedId"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="WalmartFundedIncentivesEnrollmentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// While all Walmart-funded incentives are auto-enrolled by default, you can use this API endpoint to 'Opt-out' specific Walmart-funded items whose price you don't wish to lower.
    /// <para>
    /// You can also 'Opt-in' items which were previously Opted-out by you at any time using this API.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<FeedId> WalmartFundedIncentivesEnrollment(WalmartFundedIncentivesEnrollmentRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/feeds?feedType=WALMART_FUNDED_INCENTIVES_ENROLLMENT"),
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
            JsonResponse.Create<FeedId>(),
            WalmartFundedIncentivesEnrollmentError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
