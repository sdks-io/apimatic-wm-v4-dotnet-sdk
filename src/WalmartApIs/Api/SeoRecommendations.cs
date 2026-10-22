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
using WalmartApIs.Requests.SeoRecommendations;

namespace WalmartApIs.Api;

public sealed class SeoRecommendations
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal SeoRecommendations(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Get SEO Recommendations
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3SeoRecommendationGetItemsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetSeoRecommendationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Get list of items with SEO recommendations. Sellers can filter items by status (all, new, accepted, rejected), search for specific items using identifiers like (itemId, sku, or name) and paginate results for large datasets..
    /// </remarks>
    public Task<V3SeoRecommendationGetItemsResponse> GetSeoRecommendations(GetSeoRecommendationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/seo/recommendation/getItems"),
            [],
            [
                new Param("status", request.Status),
                new Param("limit", request.Limit),
                new Param("next_cursor", request.NextCursor),
                new Param("previous_cursor", request.PreviousCursor),
            ],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("Accept", request.Accept),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3SeoRecommendationGetItemsResponse>(),
            GetSeoRecommendationsError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update SEO recommendation decision
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3SeoRecommendationUpdateItemsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateSeoRecommendationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Sellers can accept or reject SEO recommendations with optimal feedback for rejected recommendations
    /// </remarks>
    public Task<V3SeoRecommendationUpdateItemsResponse> UpdateSeoRecommendations(UpdateSeoRecommendationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/seo/recommendation/updateItems/{itemId}/{decision}"),
            [new TemplateParam("itemId", request.ItemId), new TemplateParam("decision", request.Decision)],
            [],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("Accept", request.Accept),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3SeoRecommendationUpdateItemsResponse>(),
            UpdateSeoRecommendationsError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
