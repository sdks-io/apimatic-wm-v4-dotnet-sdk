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
using WalmartApIs.Requests.RichMedia;

namespace WalmartApIs.Api;

public sealed class RichMedia
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal RichMedia(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Get all assets
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AssetsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetAllAssetsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Use this API to retrieve rich media assets, including 360-spin images and videos, from the seller catalog. Assets can be created in seller center media library or programmatically through the API. Use this endpoint to retrieve the asset hash, which uniquely identifies each media asset for future management.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<AssetsResponse> GetAllAssets(GetAllAssetsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/items/assets"),
            [],
            [
                new Param("page", request.Page),
                new Param("limit", request.Limit),
                new Param("linkedGtins", request.LinkedGtins),
                new Param("richMediaTitle", request.RichMediaTitle),
                new Param("richMediaType", request.RichMediaType),
            ],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AssetsResponse>(),
            GetAllAssetsError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Manage rich media assets (Add, Edit, Delete)
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeedId1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RichMediaOperationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Use this API to create, update, or delink rich media assets for items in the seller catalog. Supported asset types are <c>IMAGES360</c> and <c>VIDEO</c>. Use this API to 1) add new rich media, 2) update associations for existing rich media, or 3) delink item association on existing rich media. Provide accessible media URLs and related metadata in the request body. Video assets require one video URL. 360-spin image assets require 24 image URLs.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<FeedId1> RichMediaOperation(RichMediaOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/feeds?feedType=OMNI_RICH_MEDIA"),
            [],
            [],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<FeedId1>(),
            RichMediaOperationError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
