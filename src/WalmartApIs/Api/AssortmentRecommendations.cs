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
using WalmartApIs.Requests.AssortmentRecommendations;

namespace WalmartApIs.Api;

public sealed class AssortmentRecommendations
{
    private readonly RawClient _rawClient;
    private readonly Server _server;

    internal AssortmentRecommendations(RawClient rawClient, Server server)
    {
        _rawClient = rawClient;
        _server = server;
    }

    /// <summary>
    /// Get Recommendation Trends
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3GrowthAssortmentRecommendationsTrendsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetAssortmentRecommendationTrendsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// You can fetch the monthly and weekly trends for both demand and price, for the assortment recommendations that are recommended for you. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </remarks>
    public Task<V3GrowthAssortmentRecommendationsTrendsResponse> GetAssortmentRecommendationTrends(GetAssortmentRecommendationTrendsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/growth/assortment/recommendations/trends"),
            [],
            [
                new Param("recommendationUniqueId", request.RecommendationUniqueId),
                new Param("trendTypes", request.TrendTypes),
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
            JsonResponse.Create<V3GrowthAssortmentRecommendationsTrendsResponse>(),
            GetAssortmentRecommendationTrendsError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get Variants
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3GrowthAssortmentRecommendationsVariantsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetAssortmentRecommendationVariantsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// You can fetch variant items corresponding to a recommended primary variant item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </remarks>
    public Task<V3GrowthAssortmentRecommendationsVariantsResponse> GetAssortmentRecommendationVariants(GetAssortmentRecommendationVariantsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/growth/assortment/recommendations/variants"),
            [],
            [
                new Param("primaryVariantItemId", request.PrimaryVariantItemId),
                new Param("nextCursor", request.NextCursor),
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
            JsonResponse.Create<V3GrowthAssortmentRecommendationsVariantsResponse>(),
            GetAssortmentRecommendationVariantsError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get Recommendations
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3GrowthAssortmentRecommendationsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetAssortmentRecommendationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// You can fetch the list of recommendations that are recommended for you.
    /// <para>
    /// Using ITEM as a recommendationType,
    /// *   You can get the list of ITEM recommendations. You can apply filters to fetch selective item recommendations. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3GrowthAssortmentRecommendationsResponse> GetAssortmentRecommendations(GetAssortmentRecommendationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/growth/assortment/recommendations"),
            [],
            [],
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
            JsonResponse.Create<V3GrowthAssortmentRecommendationsResponse>(),
            GetAssortmentRecommendationsError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get Categorization
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3GrowthAssortmentRecommendationsCategorizationCountsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetCategorizationDetailsOfAssortmentRecommendationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// You can get the list of brands or categories associated with the items recommendations that are recommended for you.
    /// <para>
    /// Using BRAND as a categorizationType
    /// *   You can get the list of brands sorted by the number of item recommendations associated with it. This is then sorted in lexicographic order of brand name.
    /// </para>
    /// <para>
    /// Using CATEGORY as a categorizationType
    /// *   You can get the list of categories sorted by the number of item recommendations associated with it. This is then sorted in lexicographic order of category name.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3GrowthAssortmentRecommendationsCategorizationCountsResponse> GetCategorizationDetailsOfAssortmentRecommendations(GetCategorizationDetailsOfAssortmentRecommendationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/growth/assortment/recommendations/categorization/counts"),
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
            JsonResponse.Create<V3GrowthAssortmentRecommendationsCategorizationCountsResponse>(),
            GetCategorizationDetailsOfAssortmentRecommendationsError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Reject Recommendations
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3GrowthAssortmentRecommendationsRejectionsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RejectAssortmentRecommendationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// You can reject a list of recommendations that are recommended for you.
    /// <para>
    /// Using ITEM as a recommendationType,
    /// *   You can reject specific item recommendations using the filterCriteria or by providing the list of itemRecommendationUniqueIds.
    /// *   You will need to provide valid rejection code(s) while submitting the reject request. You are required to send the custom rejection message if the rejection code is OTHER_REASON
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3GrowthAssortmentRecommendationsRejectionsResponse> RejectAssortmentRecommendations(RejectAssortmentRecommendationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/growth/assortment/recommendations/rejections"),
            [],
            [],
            [
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3GrowthAssortmentRecommendationsRejectionsResponse>(),
            RejectAssortmentRecommendationsError.Response,
            [],
            requestOptions,
            cancellationToken);
}
