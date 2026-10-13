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
using WalmartApIs.Requests.DataKiosk;

namespace WalmartApIs.Api;

public sealed class DataKiosk
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal DataKiosk(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancels the query indicated by the queryId (only IN_QUEUE or IN_PROGRESS)
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelQueryResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelQueryError"/> when the server returns an error response.</exception>
    public Task<CancelQueryResponse> CancelQuery(CancelQueryRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/data-kiosk/v4/queries/{queryId}"),
            [new TemplateParam("queryId", request.QueryId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<CancelQueryResponse>(),
            CancelQueryError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Creates a Data Kiosk query request
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateQueryResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateQueryError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Submits a structured query for async processing.
    /// Query language TBD pending ADR (GraphQL vs REST hybrid — Pod 4).
    /// </remarks>
    public Task<CreateQueryResponse> CreateQuery(CreateQueryRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/data-kiosk/v4/queries"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CreateQueryResponse>(),
            CreateQueryError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns information required for retrieving a Data Kiosk document
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Document"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetDocumentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a pre-signed URL for downloading query result data.
    /// Do not log the pre-signed URL.
    /// </remarks>
    public Task<Document> GetDocument(GetDocumentRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/data-kiosk/v4/documents/{documentId}"),
            [new TemplateParam("documentId", request.DocumentId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Document>(),
            GetDocumentError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns details for the Data Kiosk queries that match the specified filters
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetQueriesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetQueriesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of Data Kiosk queries submitted by the seller,
    /// optionally filtered by processing status and creation date range.
    /// </remarks>
    public Task<GetQueriesResponse> GetQueries(GetQueriesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/data-kiosk/v4/queries"),
            [],
            [
                new Param("processingStatuses", request.ProcessingStatuses),
                new Param("pageSize", request.PageSize),
                new Param("createdSince", request.CreatedSince?.ToIso8601()),
                new Param("createdUntil", request.CreatedUntil?.ToIso8601()),
                new Param("paginationToken", request.PaginationToken),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetQueriesResponse>(),
            GetQueriesError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns details for the Data Kiosk query indicated by the queryId
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Query"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetQueryError"/> when the server returns an error response.</exception>
    public Task<Query> GetQuery(GetQueryRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/data-kiosk/v4/queries/{queryId}"),
            [new TemplateParam("queryId", request.QueryId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Query>(),
            GetQueryError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
