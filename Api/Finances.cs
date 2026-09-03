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

namespace WalmartApIs.Api;

/// <summary>
/// Financial event groups, financial events, and order-level financial events (consolidated from Pod 5).
/// </summary>
public sealed class Finances
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Finances(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Returns financial event groups for the seller.
    /// <para>
    /// <b>Status: stub</b> — no upstream endpoint found that models the SP-API
    /// FinancialEventGroup (requires eventGroupId keying, date-range filter,
    /// and cursor pagination). Returns empty response pending Phase 5.
    /// </para>
    /// </summary>
    /// <param name="maxResultsPerPage">The maximum number of results per page.</param>
    /// <param name="financialEventGroupStartedBefore">Financial event groups that opened before this date/time (ISO 8601).</param>
    /// <param name="financialEventGroupStartedAfter">Financial event groups that opened after this date/time (ISO 8601).</param>
    /// <param name="nextToken">Cursor token for the next page of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="object"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListFinancialEventGroupsError"/> when the server returns an error response.</exception>
    public Task<object> ListFinancialEventGroups(int? maxResultsPerPage,
        DateTimeOffset? financialEventGroupStartedBefore,
        DateTimeOffset? financialEventGroupStartedAfter,
        string? nextToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/finances/v4/financialEventGroups"),
            [],
            [new Param("MaxResultsPerPage", maxResultsPerPage),
                new Param("FinancialEventGroupStartedBefore", financialEventGroupStartedBefore?.ToIso8601()),
                new Param("FinancialEventGroupStartedAfter", financialEventGroupStartedAfter?.ToIso8601()),
                new Param("NextToken", nextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            ListFinancialEventGroupsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns financial events for the authenticated seller via GMP partnerTxnSearch.
    /// <para>
    /// <b>Best-effort implementation</b> — backed by GMP partnerTxnSearch.
    /// Returns transaction records for the seller keyed by partnerId.
    /// </para>
    /// <para>
    /// <b>Unsupported parameters:</b> PostedAfter, PostedBefore, and NextToken are not
    /// supported by the upstream. Supplying any of these parameters returns 400 Bad Request.
    /// </para>
    /// </summary>
    /// <param name="maxResultsPerPage">Ignored — GMP returns all results in a single page.</param>
    /// <param name="postedAfter">Not supported — returns 400 Bad Request if supplied.</param>
    /// <param name="postedBefore">Not supported — returns 400 Bad Request if supplied.</param>
    /// <param name="nextToken">Not supported — returns 400 Bad Request if supplied.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="object"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListFinancialEventsError"/> when the server returns an error response.</exception>
    public Task<object> ListFinancialEvents(int? maxResultsPerPage,
        DateTimeOffset? postedAfter,
        DateTimeOffset? postedBefore,
        string? nextToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/finances/v4/financialEvents"),
            [],
            [new Param("MaxResultsPerPage", maxResultsPerPage),
                new Param("PostedAfter", postedAfter?.ToIso8601()),
                new Param("PostedBefore", postedBefore?.ToIso8601()),
                new Param("NextToken", nextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            ListFinancialEventsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns financial events for a specific financial event group.
    /// <para>
    /// <b>Status: stub</b> — no upstream maps eventGroupId to a financial event
    /// set. Returns empty response pending Phase 5.
    /// </para>
    /// </summary>
    /// <param name="eventGroupId">The identifier of the financial event group.</param>
    /// <param name="maxResultsPerPage">The maximum number of results to return per page.</param>
    /// <param name="postedAfter">Financial events posted after (or on) this date (ISO 8601).</param>
    /// <param name="postedBefore">Financial events posted before (but not on) this date (ISO 8601).</param>
    /// <param name="nextToken">Cursor token for the next page of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="object"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListFinancialEventsByGroupIdError"/> when the server returns an error response.</exception>
    public Task<object> ListFinancialEventsByGroupId(string eventGroupId,
        int? maxResultsPerPage,
        DateTimeOffset? postedAfter,
        DateTimeOffset? postedBefore,
        string? nextToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/finances/v4/financialEventGroups/{eventGroupId}/financialEvents"),
            [new TemplateParam("eventGroupId", eventGroupId)],
            [new Param("MaxResultsPerPage", maxResultsPerPage),
                new Param("PostedAfter", postedAfter?.ToIso8601()),
                new Param("PostedBefore", postedBefore?.ToIso8601()),
                new Param("NextToken", nextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            ListFinancialEventsByGroupIdErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns financial events for a specific order via GMP commission endpoint.
    /// <para>
    /// <b>Best-effort implementation</b> — returns commission charges only;
    /// refunds, fees, and adjustments are absent. IDOR ownership gate enforced.
    /// </para>
    /// </summary>
    /// <param name="orderId">Walmart order number — must be numeric (1–50 digits).</param>
    /// <param name="maxResultsPerPage">Ignored — GMP returns all commission entries in one page.</param>
    /// <param name="nextToken">Not supported — returns 400 Bad Request if supplied.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="object"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListFinancialEventsByOrderIdError"/> when the server returns an error response.</exception>
    public Task<object> ListFinancialEventsByOrderId(string orderId,
        int? maxResultsPerPage,
        string? nextToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/finances/v4/orders/{orderId}/financialEvents"),
            [new TemplateParam("orderId", orderId)],
            [new Param("MaxResultsPerPage", maxResultsPerPage), new Param("NextToken", nextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            ListFinancialEventsByOrderIdErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
