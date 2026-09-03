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

namespace WalmartApIs.Api;

/// <summary>
/// Settlement periods and detailed transaction records.
/// </summary>
public sealed class Settlement
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Settlement(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Paginated settlement transaction detail for a period
    /// </summary>
    /// <param name="partnerId">Numeric partner/seller ID</param>
    /// <param name="reportDate">Report date in MMddyyyy format (e.g. 06172026)</param>
    /// <param name="nextToken">Opaque cursor from a prior response; omit for first page</param>
    /// <param name="pageSize"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SettlementDetailsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListSettlementDetailsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns paginated settlement transaction detail for the given partner and report date.
    /// Contains PII (purchase order IDs). Delegates to mp-payment-reporting
    /// GET /v3/report/reconreport/v1/getJson with offset-based pagination.
    /// nextToken is a Base64-encoded offset into the report file.
    /// </remarks>
    public Task<SettlementDetailsResponse> ListSettlementDetails(string partnerId,
        string reportDate,
        string? nextToken,
        int? pageSize = 10,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/payment/settlementDetails"),
            [],
            [new Param("partnerId", partnerId),
                new Param("reportDate", reportDate),
                new Param("pageSize", pageSize),
                new Param("nextToken", nextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SettlementDetailsResponse>(),
            ListSettlementDetailsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// List settlement periods for the authenticated seller
    /// </summary>
    /// <param name="nextToken">Opaque cursor from a prior response; omit for first page</param>
    /// <param name="pageSize"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SettlementPeriodsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListSettlementPeriodsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns available settlement period dates for the authenticated seller.
    /// Delegates to mp-payment-reporting GET /v3/report/reconreport/v1/availableReconFiles.
    /// </remarks>
    public Task<SettlementPeriodsResponse> ListSettlementPeriods(string? nextToken,
        int? pageSize = 10,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/payment/settlementPeriods"),
            [],
            [new Param("pageSize", pageSize), new Param("nextToken", nextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SettlementPeriodsResponse>(),
            ListSettlementPeriodsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Search payment transactions across settlement periods
    /// </summary>
    /// <param name="nextToken">Opaque cursor from a prior response; omit for first page</param>
    /// <param name="postedAfter"></param>
    /// <param name="postedBefore"></param>
    /// <param name="pageSize"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TransactionSearchResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SearchTransactionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of payment transactions for the authenticated seller
    /// filtered by optional date range. Contains PII (purchase order IDs).
    /// Delegates to GMPPaymentsPlatform (Phase 5).
    /// </remarks>
    public Task<TransactionSearchResponse> SearchTransactions(string? nextToken,
        DateTimeOffset? postedAfter,
        DateTimeOffset? postedBefore,
        int? pageSize = 10,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/payment/search/transactions"),
            [],
            [new Param("pageSize", pageSize),
                new Param("nextToken", nextToken),
                new Param("postedAfter", postedAfter?.ToIso8601()),
                new Param("postedBefore", postedBefore?.ToIso8601())],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<TransactionSearchResponse>(),
            SearchTransactionsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
