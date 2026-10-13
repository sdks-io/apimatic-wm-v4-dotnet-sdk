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
using WalmartApIs.Requests.Settlement;

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
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SettlementDetailsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListSettlementDetailsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns paginated settlement transaction detail for the given partner and report date.
    /// Contains PII (purchase order IDs). Delegates to mp-payment-reporting
    /// GET /v3/report/reconreport/v1/getJson with offset-based pagination.
    /// nextToken is a Base64-encoded offset into the report file.
    /// </remarks>
    public Task<SettlementDetailsResponse> ListSettlementDetails(ListSettlementDetailsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/disbursements/v4/payment/settlementDetails"),
            [],
            [
                new Param("partnerId", request.PartnerId),
                new Param("reportDate", request.ReportDate),
                new Param("pageSize", request.PageSize),
                new Param("nextToken", request.NextToken),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SettlementDetailsResponse>(),
            ListSettlementDetailsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List settlement periods for the authenticated seller
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SettlementPeriodsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListSettlementPeriodsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns available settlement period dates for the authenticated seller.
    /// Delegates to mp-payment-reporting GET /v3/report/reconreport/v1/availableReconFiles.
    /// </remarks>
    public Task<SettlementPeriodsResponse> ListSettlementPeriods(ListSettlementPeriodsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/disbursements/v4/payment/settlementPeriods"),
            [],
            [new Param("pageSize", request.PageSize), new Param("nextToken", request.NextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SettlementPeriodsResponse>(),
            ListSettlementPeriodsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Search payment transactions across settlement periods
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TransactionSearchResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="SearchTransactionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of payment transactions for the authenticated seller
    /// filtered by optional date range. Contains PII (purchase order IDs).
    /// Delegates to GMPPaymentsPlatform (Phase 5).
    /// </remarks>
    public Task<TransactionSearchResponse> SearchTransactions(SearchTransactionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/disbursements/v4/payment/search/transactions"),
            [],
            [
                new Param("pageSize", request.PageSize),
                new Param("nextToken", request.NextToken),
                new Param("postedAfter", request.PostedAfter?.ToIso8601()),
                new Param("postedBefore", request.PostedBefore?.ToIso8601()),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<TransactionSearchResponse>(),
            SearchTransactionsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
