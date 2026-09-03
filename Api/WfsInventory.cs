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
    /// <param name="skus">Comma-separated seller SKUs to filter (max 50). Omit to return all WFS items.</param>
    /// <param name="nextToken"></param>
    /// <param name="pageSize"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetWfsInventoryResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetWfsInventoryItemsError"/> when the server returns an error response.</exception>
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
    public Task<GetWfsInventoryResponse> GetWfsInventoryItems(string? skus,
        string? nextToken,
        int? pageSize = 100,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inventory/v4/wfs/items"),
            [],
            [new Param("skus", skus), new Param("pageSize", pageSize), new Param("nextToken", nextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetWfsInventoryResponse>(),
            GetWfsInventoryItemsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
