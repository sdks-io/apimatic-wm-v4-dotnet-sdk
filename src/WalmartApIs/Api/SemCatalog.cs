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
using WalmartApIs.Requests.SemCatalog;

namespace WalmartApIs.Api;

/// <summary>
/// Endpoints for managing catalog items for SEM campaigns
/// </summary>
public sealed class SemCatalog
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal SemCatalog(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Check eligibility of items
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SemCatalogueResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetEligibleItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API allows you to check whether an item from your catalog meets the required conditions for Search Engine Marketing ads.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </remarks>
    public Task<SemCatalogueResponse> GetEligibleItems(GetEligibleItemsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/advertising/sem/items/eligibility"),
            [],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SemCatalogueResponse>(),
            GetEligibleItemsError.Response,
            [_auth.BearerAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get top recommended items from your catalog
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SemCatalogueResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetItemRecommendationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API allows you to fetch a list of top recommended items from your catalog. You can customize the number of recommendations to be returned by adjusting the request parameter.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </remarks>
    public Task<SemCatalogueResponse> GetItemRecommendations(GetItemRecommendationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/advertising/sem/items/recommendations"),
            [],
            [new Param("limit", request.Limit)],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SemCatalogueResponse>(),
            GetItemRecommendationsError.Response,
            [_auth.BearerAuth],
            requestOptions,
            cancellationToken);
}
