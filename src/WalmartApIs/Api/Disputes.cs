using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;

namespace WalmartApIs.Api;

/// <summary>
/// Dispute eligibility for payment issues.
/// </summary>
public sealed class Disputes
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Disputes(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Check if a seller is eligible to raise a payment dispute
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="DisputeEligibilityResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CheckDisputeEligibilityError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns whether the authenticated seller is eligible to raise a payment
    /// dispute and, if not, the reason for ineligibility. Delegates to
    /// GMPPaymentsPlatform (Phase 5).
    /// </remarks>
    public Task<DisputeEligibilityResponse> CheckDisputeEligibility(RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/disbursements/v4/payment/disputeEligibilityCheck"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<DisputeEligibilityResponse>(),
            CheckDisputeEligibilityError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
