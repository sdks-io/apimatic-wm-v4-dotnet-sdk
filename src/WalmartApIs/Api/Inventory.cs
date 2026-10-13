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
using WalmartApIs.Requests.Inventory;

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
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BulkUpdateInventoryResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="BulkUpdateInventoryError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Bulk inventory update. Max 500 items per request.
    /// </remarks>
    public Task<BulkUpdateInventoryResponse> BulkUpdateInventory(BulkUpdateInventoryOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inventory/v4/items/bulk"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<BulkUpdateInventoryResponse>(),
            BulkUpdateInventoryError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns inventory summary for a single SKU
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="InventorySummary"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetInventoryForSkuError"/> when the server returns an error response.</exception>
    public Task<InventorySummary> GetInventoryForSku(GetInventoryForSkuRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inventory/v4/items/{sku}"),
            [new TemplateParam("sku", request.Sku)],
            [new Param("shipNode", request.ShipNode)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<InventorySummary>(),
            GetInventoryForSkuError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns a list of inventory summaries for seller items
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetInventorySummariesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetInventorySummariesError"/> when the server returns an error response.</exception>
    public Task<GetInventorySummariesResponse> GetInventorySummaries(GetInventorySummariesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inventory/v4/items"),
            [],
            [
                new Param("skus", request.Skus),
                new Param("shipNode", request.ShipNode),
                new Param("pageSize", request.PageSize),
                new Param("nextToken", request.NextToken),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetInventorySummariesResponse>(),
            GetInventorySummariesError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update inventory quantity for a single SKU
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UpdateInventoryResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateInventoryForSkuError"/> when the server returns an error response.</exception>
    public Task<UpdateInventoryResponse> UpdateInventoryForSku(UpdateInventoryForSkuRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inventory/v4/items/{sku}"),
            [new TemplateParam("sku", request.Sku)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<UpdateInventoryResponse>(),
            UpdateInventoryForSkuError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
