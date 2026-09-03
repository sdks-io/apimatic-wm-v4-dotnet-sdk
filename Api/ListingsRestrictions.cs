using System.Collections.Generic;
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
using WalmartApIs.Models.Enums;

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
    /// <param name="asin">Walmart Item ID (maps to ASIN in Walmart Seller API)</param>
    /// <param name="conditionType"></param>
    /// <param name="sellerId"></param>
    /// <param name="marketplaceIds"></param>
    /// <param name="reasonLocale">Locale for localized restriction reason messages</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="RestrictionList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetListingsRestrictionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns restrictions on listing an item for a given ASIN and seller.
    /// A successful response does not guarantee the seller can list — check
    /// the restrictions array.
    /// </remarks>
    public Task<RestrictionList> GetListingsRestrictions(string asin,
        ConditionType1 conditionType,
        string sellerId,
        IReadOnlyList<string> marketplaceIds,
        string? reasonLocale = "en_US",
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/listings/v4/restrictions"),
            [],
            [new Param("asin", asin),
                new Param("conditionType", conditionType),
                new Param("sellerId", sellerId),
                new Param("marketplaceIds", marketplaceIds),
                new Param("reasonLocale", reasonLocale)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<RestrictionList>(),
            GetListingsRestrictionsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
