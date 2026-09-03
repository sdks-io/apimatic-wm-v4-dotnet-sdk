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

namespace WalmartApIs.Api;

/// <summary>
/// Final payout case management.
/// </summary>
public sealed class FinalPayout
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal FinalPayout(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Get the status of a final payout case
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FinalPayoutCaseStatusResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFinalPayoutCaseStatusError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the current state, case ID, and payable amount for the authenticated
    /// seller's final payout case (used when a seller account is being offboarded).
    /// Delegates to GMPPaymentsPlatform (Phase 5).
    /// </remarks>
    public Task<FinalPayoutCaseStatusResponse> GetFinalPayoutCaseStatus(RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/finalPayout/case/status"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FinalPayoutCaseStatusResponse>(),
            GetFinalPayoutCaseStatusErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Update the status of a final payout case
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FinalPayoutCaseStatusResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateFinalPayoutCaseStatusError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Transitions the authenticated seller's final payout case to Resolved or
    /// Closed, optionally including resolution notes. Requires disbursements:write
    /// scope. Delegates to GMPPaymentsPlatform (Phase 5).
    /// </remarks>
    public Task<FinalPayoutCaseStatusResponse> UpdateFinalPayoutCaseStatus(DisbursementsV4FinalPayoutCaseUpdateStatusRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/finalPayout/case/updateStatus"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(body),
            JsonResponse.Create<FinalPayoutCaseStatusResponse>(),
            UpdateFinalPayoutCaseStatusErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
