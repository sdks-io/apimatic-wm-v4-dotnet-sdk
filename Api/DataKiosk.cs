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
    /// <param name="queryId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelQueryResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CancelQueryError"/> when the server returns an error response.</exception>
    public Task<CancelQueryResponse> CancelQuery(string queryId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/data-kiosk/v4/queries/{queryId}"),
            [new TemplateParam("queryId", queryId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<CancelQueryResponse>(),
            CancelQueryErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Creates a Data Kiosk query request
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateQueryResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateQueryError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Submits a structured query for async processing.
    /// Query language TBD pending ADR (GraphQL vs REST hybrid — Pod 4).
    /// </remarks>
    public Task<CreateQueryResponse> CreateQuery(CreateQuerySpecification body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/data-kiosk/v4/queries"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CreateQueryResponse>(),
            CreateQueryErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns information required for retrieving a Data Kiosk document
    /// </summary>
    /// <param name="documentId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Document"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetDocumentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a pre-signed URL for downloading query result data.
    /// Do not log the pre-signed URL.
    /// </remarks>
    public Task<Document> GetDocument(string documentId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/data-kiosk/v4/documents/{documentId}"),
            [new TemplateParam("documentId", documentId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Document>(),
            GetDocumentErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns details for the Data Kiosk queries that match the specified filters
    /// </summary>
    /// <param name="processingStatuses"></param>
    /// <param name="createdSince"></param>
    /// <param name="createdUntil"></param>
    /// <param name="paginationToken"></param>
    /// <param name="pageSize"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetQueriesResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetQueriesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of Data Kiosk queries submitted by the seller,
    /// optionally filtered by processing status and creation date range.
    /// </remarks>
    public Task<GetQueriesResponse> GetQueries(IReadOnlyList<ProcessingStatus>? processingStatuses,
        DateTimeOffset? createdSince,
        DateTimeOffset? createdUntil,
        string? paginationToken,
        int? pageSize = 10,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/data-kiosk/v4/queries"),
            [],
            [new Param("processingStatuses", processingStatuses),
                new Param("pageSize", pageSize),
                new Param("createdSince", createdSince?.ToIso8601()),
                new Param("createdUntil", createdUntil?.ToIso8601()),
                new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetQueriesResponse>(),
            GetQueriesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns details for the Data Kiosk query indicated by the queryId
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Query"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetQueryError"/> when the server returns an error response.</exception>
    public Task<Query> GetQuery(string queryId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/data-kiosk/v4/queries/{queryId}"),
            [new TemplateParam("queryId", queryId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Query>(),
            GetQueryErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
