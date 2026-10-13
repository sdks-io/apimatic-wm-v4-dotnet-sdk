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
using WalmartApIs.Requests.ListingsRestrictions;

namespace WalmartApIs.Api;

public sealed class ListingsRestrictions
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ListingsRestrictions(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Returns listing restrictions for an item in the indicated marketplace
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="RestrictionList"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetListingsRestrictionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns restrictions on listing an item for a given ASIN and seller.
    /// A successful response does not guarantee the seller can list — check
    /// the restrictions array.
    /// </remarks>
    public Task<RestrictionList> GetListingsRestrictions(GetListingsRestrictionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/listings/v4/restrictions"),
            [],
            [
                new Param("asin", request.Asin),
                new Param("conditionType", request.ConditionType),
                new Param("sellerId", request.SellerId),
                new Param("marketplaceIds", request.MarketplaceIds),
                new Param("reasonLocale", request.ReasonLocale),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<RestrictionList>(),
            GetListingsRestrictionsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
