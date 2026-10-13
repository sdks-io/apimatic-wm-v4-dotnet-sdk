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
using WalmartApIs.Requests.Finances;

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
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="object"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListFinancialEventGroupsError"/> when the server returns an error response.</exception>
    public Task<object> ListFinancialEventGroups(ListFinancialEventGroupsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/finances/v4/financialEventGroups"),
            [],
            [
                new Param("MaxResultsPerPage", request.MaxResultsPerPage),
                new Param("FinancialEventGroupStartedBefore", request.FinancialEventGroupStartedBefore?.ToIso8601()),
                new Param("FinancialEventGroupStartedAfter", request.FinancialEventGroupStartedAfter?.ToIso8601()),
                new Param("NextToken", request.NextToken),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            ListFinancialEventGroupsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

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
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="object"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListFinancialEventsError"/> when the server returns an error response.</exception>
    public Task<object> ListFinancialEvents(ListFinancialEventsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/finances/v4/financialEvents"),
            [],
            [
                new Param("MaxResultsPerPage", request.MaxResultsPerPage),
                new Param("PostedAfter", request.PostedAfter?.ToIso8601()),
                new Param("PostedBefore", request.PostedBefore?.ToIso8601()),
                new Param("NextToken", request.NextToken),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            ListFinancialEventsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns financial events for a specific financial event group.
    /// <para>
    /// <b>Status: stub</b> — no upstream maps eventGroupId to a financial event
    /// set. Returns empty response pending Phase 5.
    /// </para>
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="object"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListFinancialEventsByGroupIdError"/> when the server returns an error response.</exception>
    public Task<object> ListFinancialEventsByGroupId(ListFinancialEventsByGroupIdRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/finances/v4/financialEventGroups/{eventGroupId}/financialEvents"),
            [new TemplateParam("eventGroupId", request.EventGroupId)],
            [
                new Param("MaxResultsPerPage", request.MaxResultsPerPage),
                new Param("PostedAfter", request.PostedAfter?.ToIso8601()),
                new Param("PostedBefore", request.PostedBefore?.ToIso8601()),
                new Param("NextToken", request.NextToken),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            ListFinancialEventsByGroupIdError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns financial events for a specific order via GMP commission endpoint.
    /// <para>
    /// <b>Best-effort implementation</b> — returns commission charges only;
    /// refunds, fees, and adjustments are absent. IDOR ownership gate enforced.
    /// </para>
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="object"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListFinancialEventsByOrderIdError"/> when the server returns an error response.</exception>
    public Task<object> ListFinancialEventsByOrderId(ListFinancialEventsByOrderIdRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/finances/v4/orders/{orderId}/financialEvents"),
            [new TemplateParam("orderId", request.OrderId)],
            [new Param("MaxResultsPerPage", request.MaxResultsPerPage), new Param("NextToken", request.NextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            ListFinancialEventsByOrderIdError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
