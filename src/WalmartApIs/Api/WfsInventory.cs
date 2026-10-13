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
using WalmartApIs.Requests.WfsInventory;

namespace WalmartApIs.Api;

public sealed class WfsInventory
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal WfsInventory(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Returns WFS-managed inventory with fulfillment insights
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetWfsInventoryResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetWfsInventoryItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns inventory for items managed by Walmart Fulfillment Services (WFS).
    /// Includes stock health, age buckets, and demand-intelligence fields
    /// not available on seller-fulfilled inventory.
    /// <para>
    /// <b>Rate limit:</b> 300 items per page maximum.
    /// Requests retrieving more than 100 items per page will receive
    /// <c>X-RateLimit-Limit</c> and <c>X-RateLimit-Remaining</c> headers in the response.
    /// </para>
    /// </remarks>
    public Task<GetWfsInventoryResponse> GetWfsInventoryItems(GetWfsInventoryItemsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inventory/v4/wfs/items"),
            [],
            [
                new Param("skus", request.Skus),
                new Param("pageSize", request.PageSize),
                new Param("nextToken", request.NextToken),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetWfsInventoryResponse>(),
            GetWfsInventoryItemsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
