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
/// Payout status, eligibility, and initiation.
/// </summary>
public sealed class Payouts
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Payouts(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Enable or disable automatic payout scheduling
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PayoutStatusResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ConfigureAutoPayoutError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Enables or disables automatic scheduled payouts for the authenticated seller.
    /// When enabled, payouts are triggered automatically on the standard settlement
    /// cadence. Returns updated payout status. Requires disbursements:write scope.
    /// Delegates to GMPPaymentsPlatform (Phase 5).
    /// </remarks>
    public Task<PayoutStatusResponse> ConfigureAutoPayout(DisbursementsV4PaymentAutoPayoutRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/payment/autoPayout"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(body),
            JsonResponse.Create<PayoutStatusResponse>(),
            ConfigureAutoPayoutErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Get annual statement options and opt-in status
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AnnualStatementOptsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetAnnualStatementOptsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns whether the authenticated seller is opted in to annual statement
    /// generation and the current statement year. Delegates to GMPPaymentsPlatform
    /// GET /annualStatementOpts/{partnerId}.
    /// </remarks>
    public Task<AnnualStatementOptsResponse> GetAnnualStatementOpts(RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/payment/annualStatementOpts"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AnnualStatementOptsResponse>(),
            GetAnnualStatementOptsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Check eligibility for on-demand accelerated payout
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FasterPayoutEligibilityResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFasterPayoutEligibilityError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns whether the authenticated seller is eligible for an on-demand
    /// faster payout, along with the approved amount and any ineligibility reason.
    /// Delegates to GMPPaymentsPlatform GET /fasterPayout/eligibility/{partnerId}.
    /// </remarks>
    public Task<FasterPayoutEligibilityResponse> GetFasterPayoutEligibility(RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/payment/fasterPayoutEligibility"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FasterPayoutEligibilityResponse>(),
            GetFasterPayoutEligibilityErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Get current payout status for the authenticated seller
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PayoutStatusResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetPaymentStatusError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the current payout status for the authenticated seller, including
    /// scheduled payout date, amount, and lifecycle state (Pending, Processing,
    /// Completed, Failed, OnHold). Delegates to GMPPaymentsPlatform (Phase 5).
    /// </remarks>
    public Task<PayoutStatusResponse> GetPaymentStatus(RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/payment/paymentstatus"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PayoutStatusResponse>(),
            GetPaymentStatusErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Initiate an on-demand accelerated payout
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="InitiatePayoutResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="InitiateFasterPayoutError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Triggers an immediate on-demand payout for the authenticated seller,
    /// bypassing the standard settlement schedule. Returns the payout ID and
    /// initial status. Requires disbursements:write scope.
    /// Delegates to GMPPaymentsPlatform (Phase 5).
    /// </remarks>
    public Task<InitiatePayoutResponse> InitiateFasterPayout(RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/payment/fasterPayout"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<InitiatePayoutResponse>(),
            InitiateFasterPayoutErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
