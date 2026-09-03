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

public sealed class Inventory
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Inventory(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Update inventory for multiple SKUs in a single request
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BulkUpdateInventoryResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="BulkUpdateInventoryError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Bulk inventory update. Max 500 items per request.
    /// </remarks>
    public Task<BulkUpdateInventoryResponse> BulkUpdateInventory(BulkUpdateInventoryRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inventory/v4/items/bulk"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<BulkUpdateInventoryResponse>(),
            BulkUpdateInventoryErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns inventory summary for a single SKU
    /// </summary>
    /// <param name="sku"></param>
    /// <param name="shipNode">Walmart Ship Node ID (for multi-node sellers)</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="InventorySummary"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetInventoryForSkuError"/> when the server returns an error response.</exception>
    public Task<InventorySummary> GetInventoryForSku(string sku,
        string? shipNode,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inventory/v4/items/{sku}"),
            [new TemplateParam("sku", sku)],
            [new Param("shipNode", shipNode)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<InventorySummary>(),
            GetInventoryForSkuErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns a list of inventory summaries for seller items
    /// </summary>
    /// <param name="skus">Comma-separated seller SKUs (max 50)</param>
    /// <param name="shipNode">Walmart Ship Node ID (for multi-node sellers)</param>
    /// <param name="nextToken"></param>
    /// <param name="pageSize"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetInventorySummariesResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetInventorySummariesError"/> when the server returns an error response.</exception>
    public Task<GetInventorySummariesResponse> GetInventorySummaries(string? skus,
        string? shipNode,
        string? nextToken,
        int? pageSize = 100,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inventory/v4/items"),
            [],
            [new Param("skus", skus),
                new Param("shipNode", shipNode),
                new Param("pageSize", pageSize),
                new Param("nextToken", nextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetInventorySummariesResponse>(),
            GetInventorySummariesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Update inventory quantity for a single SKU
    /// </summary>
    /// <param name="sku"></param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UpdateInventoryResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateInventoryForSkuError"/> when the server returns an error response.</exception>
    public Task<UpdateInventoryResponse> UpdateInventoryForSku(string sku,
        UpdateInventoryRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inventory/v4/items/{sku}"),
            [new TemplateParam("sku", sku)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(body),
            JsonResponse.Create<UpdateInventoryResponse>(),
            UpdateInventoryForSkuErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
