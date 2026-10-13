using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Extensions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;
using WalmartApIs.Requests.Feeds;

namespace WalmartApIs.Api;

public sealed class Feeds
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Feeds(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancels a feed that has not yet finished processing
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelFeedResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelFeedError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// <b>Placeholder — not yet implemented.</b> Cancels the feed identified by
    /// feedId if it is still queued or in progress. Mirrors Amazon SP-API
    /// <c>cancelFeed</c> (DELETE /feeds/2021-06-30/feeds/{feedId}) so partners can
    /// generate a client against the final contract now. A feed that has
    /// already reached DONE or ERROR cannot be cancelled.
    /// </remarks>
    public Task<CancelFeedResponse> CancelFeed(CancelFeedRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/feeds/v4/feeds/{feedId}"),
            [new TemplateParam("feedId", request.FeedId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<CancelFeedResponse>(),
            CancelFeedError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Submit a feed file for asynchronous processing
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateFeedResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateFeedError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Upload a feed file and submit it for asynchronous processing in a single call.
    /// The server handles document storage internally. Use the returned feedId to poll
    /// processing status via GET /feeds/v4/feeds/{feedId}.
    /// </remarks>
    public Task<CreateFeedResponse> CreateFeed(CreateFeedRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/feeds/v4/feeds"),
            [],
            [new Param("feedType", request.FeedType), new Param("marketplaceId", request.MarketplaceId)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            FormRequest.Create(
                new MultipartParam("file", request.File),
                new MultipartParam("contentType", request.ContentType)),
            JsonResponse.Create<CreateFeedResponse>(),
            CreateFeedError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns feed details (including processing status) for the feed
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Feed"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetFeedError"/> when the server returns an error response.</exception>
    public Task<Feed> GetFeed(GetFeedRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/feeds/v4/feeds/{feedId}"),
            [new TemplateParam("feedId", request.FeedId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Feed>(),
            GetFeedError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Downloads the feed document as a binary file from PDR
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BinaryContent"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetFeedDocumentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Downloads the raw feed document file. The response is a binary stream
    /// (application/octet-stream). The Content-Disposition header contains the
    /// original filename when available. Content-Length header is always set
    /// to enable download progress tracking.
    /// <para>
    /// An IDOR check is performed before the download — the authenticated
    /// seller must own the feed referenced by feedId.
    /// </para>
    /// </remarks>
    public Task<BinaryContent> GetFeedDocument(GetFeedDocumentRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/feeds/v4/feeds/{feedId}/document"),
            [new TemplateParam("feedId", request.FeedId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            BinaryResponse.Instance,
            GetFeedDocumentError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns feed details for the feeds that match the filters
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFeedsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetFeedsError"/> when the server returns an error response.</exception>
    public Task<GetFeedsResponse> GetFeeds(GetFeedsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/feeds/v4/feeds"),
            [],
            [
                new Param("feedTypes", request.FeedTypes),
                new Param("feedStatuses", request.FeedStatuses),
                new Param("createdSince", request.CreatedSince?.ToIso8601()),
                new Param("createdUntil", request.CreatedUntil?.ToIso8601()),
                new Param("pageSize", request.PageSize),
                new Param("nextToken", request.NextToken),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetFeedsResponse>(),
            GetFeedsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
