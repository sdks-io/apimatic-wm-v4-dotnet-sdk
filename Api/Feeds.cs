using System;
using System.Collections.Generic;
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
using WalmartApIs.Models.Enums;

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
    /// <param name="feedId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelFeedResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CancelFeedError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// <b>Placeholder — not yet implemented.</b> Cancels the feed identified by
    /// feedId if it is still queued or in progress. Mirrors Amazon SP-API
    /// <c>cancelFeed</c> (DELETE /feeds/2021-06-30/feeds/{feedId}) so partners can
    /// generate a client against the final contract now. A feed that has
    /// already reached DONE or ERROR cannot be cancelled.
    /// </remarks>
    public Task<CancelFeedResponse> CancelFeed(string feedId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/feeds/v4/feeds/{feedId}"),
            [new TemplateParam("feedId", feedId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<CancelFeedResponse>(),
            CancelFeedErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Submit a feed file for asynchronous processing
    /// </summary>
    /// <param name="feedType">The type of feed being submitted</param>
    /// <param name="marketplaceId">Marketplace identifier (opaque token). If omitted, the service applies WALMART_US.</param>
    /// <param name="file"></param>
    /// <param name="contentType"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateFeedResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateFeedError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Upload a feed file and submit it for asynchronous processing in a single call.
    /// The server handles document storage internally. Use the returned feedId to poll
    /// processing status via GET /feeds/v4/feeds/{feedId}.
    /// </remarks>
    public Task<CreateFeedResponse> CreateFeed(FeedType feedType,
        string? marketplaceId,
        BinaryContent file,
        ContentType? contentType,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/feeds/v4/feeds"),
            [],
            [new Param("feedType", feedType), new Param("marketplaceId", marketplaceId)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            FormRequest.Create([new MultipartParam("file", file), new MultipartParam("contentType", contentType)]),
            JsonResponse.Create<CreateFeedResponse>(),
            CreateFeedErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns feed details (including processing status) for the feed
    /// </summary>
    /// <param name="feedId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Feed"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFeedError"/> when the server returns an error response.</exception>
    public Task<Feed> GetFeed(string feedId, RequestOptions? requestOptions = null, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/feeds/v4/feeds/{feedId}"),
            [new TemplateParam("feedId", feedId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Feed>(),
            GetFeedErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Downloads the feed document as a binary file from PDR
    /// </summary>
    /// <param name="feedId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BinaryContent"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFeedDocumentError"/> when the server returns an error response.</exception>
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
    public Task<BinaryContent> GetFeedDocument(string feedId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/feeds/v4/feeds/{feedId}/document"),
            [new TemplateParam("feedId", feedId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            BinaryResponse.Instance,
            GetFeedDocumentErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns feed details for the feeds that match the filters
    /// </summary>
    /// <param name="feedTypes">Feed type filter</param>
    /// <param name="feedStatuses"></param>
    /// <param name="createdSince"></param>
    /// <param name="createdUntil"></param>
    /// <param name="nextToken"></param>
    /// <param name="pageSize"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFeedsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFeedsError"/> when the server returns an error response.</exception>
    public Task<GetFeedsResponse> GetFeeds(IReadOnlyList<FeedType>? feedTypes,
        IReadOnlyList<FeedStatus>? feedStatuses,
        DateTimeOffset? createdSince,
        DateTimeOffset? createdUntil,
        string? nextToken,
        int? pageSize = 10,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/feeds/v4/feeds"),
            [],
            [new Param("feedTypes", feedTypes),
                new Param("feedStatuses", feedStatuses),
                new Param("createdSince", createdSince?.ToIso8601()),
                new Param("createdUntil", createdUntil?.ToIso8601()),
                new Param("pageSize", pageSize),
                new Param("nextToken", nextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetFeedsResponse>(),
            GetFeedsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
