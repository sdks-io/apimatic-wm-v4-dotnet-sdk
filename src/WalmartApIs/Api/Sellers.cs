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
/// Seller account and marketplace participation information
/// </summary>
public sealed class Sellers
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Sellers(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Returns the seller's account details and status
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SellerAccount"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetAccountError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the authenticated seller's account information including
    /// business name, email, account status, and seller type.
    /// </remarks>
    public Task<SellerAccount> GetAccount(RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/sellers/v4/account"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SellerAccount>(),
            GetAccountError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns marketplaces where the seller is registered and active
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetMarketplaceParticipationsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetMarketplaceParticipationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the list of marketplaces the authenticated seller participates in
    /// (e.g. Walmart US, Walmart Canada, Walmart Mexico).
    /// </remarks>
    public Task<GetMarketplaceParticipationsResponse> GetMarketplaceParticipations(RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/sellers/v4/marketplaceParticipations"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetMarketplaceParticipationsResponse>(),
            GetMarketplaceParticipationsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
