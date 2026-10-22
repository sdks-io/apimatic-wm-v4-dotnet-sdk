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
using WalmartApIs.Requests.Reviews;

namespace WalmartApIs.Api;

public sealed class Reviews
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Reviews(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Bulk update item status
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3GrowthReviewsAcceleratorItemsStatusResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="BulkUpdateItemStatusError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Use this API to enroll or disenroll items in the Review Accelerator Program (RAP).&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </remarks>
    public Task<V3GrowthReviewsAcceleratorItemsStatusResponse> BulkUpdateItemStatus(BulkUpdateItemStatusRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/growth/reviews-accelerator/items/status"),
            [],
            [],
            [
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3GrowthReviewsAcceleratorItemsStatusResponse>(),
            BulkUpdateItemStatusError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get categories
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3GrowthReviewsAcceleratorCategoriesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetIrpCategoriesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Use this API to get the set of categories the RAP post-purchase items belong to.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </remarks>
    public Task<V3GrowthReviewsAcceleratorCategoriesResponse> GetIrpCategories(GetIrpCategoriesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/growth/reviews-accelerator/categories"),
            [],
            [],
            [
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3GrowthReviewsAcceleratorCategoriesResponse>(),
            GetIrpCategoriesError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get RAP post-purchase items
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3GrowthReviewsAcceleratorItemsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetIrpItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// To get all eligible products that can be enrolled in the Reviews Accelerator post-purchase program, as well as to retrieve all products currently enrolled in the program, and all products that have attained target reviews after enrollment, you can use the following criteria:
    /// &lt;li&gt;Filter products by category and price.
    /// &lt;li&gt;Sort products by Walmart-recommended item priorities.
    /// &lt;li&gt;Search using wildcards to match the product name and SKU.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </remarks>
    public Task<V3GrowthReviewsAcceleratorItemsResponse> GetIrpItems(GetIrpItemsOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/growth/reviews-accelerator/items"),
            [],
            [new Param("scrollId", request.ScrollId)],
            [
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3GrowthReviewsAcceleratorItemsResponse>(),
            GetIrpItemsError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
