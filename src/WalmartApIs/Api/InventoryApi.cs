using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;
using WalmartApIs.Requests.InventoryApi;

namespace WalmartApIs.Api;

public sealed class InventoryApi
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal InventoryApi(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Inventory
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Inventory1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetInventoryError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// You can use this API to get the inventory for a given item.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </remarks>
    public Task<Inventory1> GetInventory(GetInventoryRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/inventory"),
            [],
            [new Param("sku", request.Sku), new Param("shipNode", request.ShipNode)],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Inventory1>(),
            GetInventoryError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Multiple Item Inventory for All Ship Nodes
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="MultiNodeInventoryFetchResponseDto"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetMultiNodeInventoryForAllSkuAndAllShipNodesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API will retrieve the inventory count for all of a seller's items across all ship nodes by item to ship node mapping. Inventory can be zero or non-zero. Please note that NextCursor value changes and it needs to be passed on from the previous call to next call.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </remarks>
    public Task<MultiNodeInventoryFetchResponseDto> GetMultiNodeInventoryForAllSkuAndAllShipNodes(GetMultiNodeInventoryForAllSkuAndAllShipNodesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/inventories"),
            [],
            [new Param("limit", request.Limit), new Param("nextCursor", request.NextCursor)],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<MultiNodeInventoryFetchResponseDto>(),
            GetMultiNodeInventoryForAllSkuAndAllShipNodesError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Single Item Inventory by Ship Node
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="InventoriesDto"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetMultiNodeInventoryForSkuAndAllShipnodesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API will retrieve the inventory count for an item across all ship nodes or one specific ship node. You can specify the ship node for which you want to fetch the inventory
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </remarks>
    public Task<InventoriesDto> GetMultiNodeInventoryForSkuAndAllShipnodes(GetMultiNodeInventoryForSkuAndAllShipnodesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/inventories/{sku}"),
            [new TemplateParam("sku", request.Sku)],
            [new Param("shipNode", request.ShipNode)],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<InventoriesDto>(),
            GetMultiNodeInventoryForSkuAndAllShipnodesError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// WFS Inventory
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3FulfillmentInventoryResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetWfsInventoryError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// You can use this API to get the current Available to Sell inventory quantities for all WFS items in your catalog. You can also query specific SKUs or filter to only items updated after a specific date in order to reduce the response size.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </remarks>
    public Task<V3FulfillmentInventoryResponse> GetWfsInventory(GetWfsInventoryRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/fulfillment/inventory"),
            [],
            [
                new Param("sku", request.Sku),
                new Param("fromModifiedDate", request.FromModifiedDate),
                new Param("toModifiedDate", request.ToModifiedDate),
                new Param("limit", request.Limit),
                new Param("offset", request.Offset),
                new Param("shipNodeType", request.ShipNodeType),
            ],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3FulfillmentInventoryResponse>(),
            GetWfsInventoryError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Bulk Item Inventory Update
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeedId"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates inventory for items in bulk.
    /// Seller Can either use feed type "inventory" or "MP_INVENTORY"
    /// * Inventory spec 1.4 feed type: inventory
    /// * Inventory spec 1.5 feed type: MP_INVENTORY
    /// <para>
    /// Note: Multi Node Inventory Update Feed (feedType=MP_INVENTORY) only supports JSON Request and Responses.
    /// </para>
    /// <para>
    ///  Refer to the throttling limits before uploading the Feed Files.
    /// </para>
    /// <para>
    /// &lt;b&gt;Download the request body sample from &lt;/b&gt;
    /// </para>
    /// <para>
    ///  &lt;a href="/file/mp/us/inventory-samples.zip"&gt;US Samples JSON&lt;/a&gt;
    /// &lt;a href="/file/mp/ca/inventory-samples.zip"&gt;CA Samples JSON&lt;/a&gt;
    /// &lt;a href="/file/mp/mx/inventory-samples.zip"&gt;MX Samples JSON&lt;/a&gt;
    /// &lt;a href="/file/mp/cl/inventory-samples.zip"&gt;CL Samples JSON&lt;/a&gt;
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<FeedId> UpdateBulkInventory(UpdateBulkInventoryRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/feeds"),
            [],
            [new Param("feedType", request.FeedType), new Param("shipNode", request.ShipNode)],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            FormRequest.Create(new MultipartParam("file", request.File)),
            JsonResponse.Create<FeedId>(),
            RawErrorResponse.Instance,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update inventory
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Inventory1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateInventoryForAnItemError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the inventory for a given item.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </remarks>
    public Task<Inventory1> UpdateInventoryForAnItem(UpdateInventoryForAnItemRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/inventory"),
            [],
            [new Param("sku", request.Sku), new Param("shipNode", request.ShipNode)],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<Inventory1>(),
            UpdateInventoryForAnItemError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Item Inventory per Ship Node
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="MultiNodeInventoryUpdateResponseDto"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateMultiNodeInventoryError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API will update the inventory for an item across one or more fulfillment centers, known as ship nodes.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </remarks>
    public Task<MultiNodeInventoryUpdateResponseDto> UpdateMultiNodeInventory(UpdateMultiNodeInventoryRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/inventories/{sku}"),
            [new TemplateParam("sku", request.Sku)],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<MultiNodeInventoryUpdateResponseDto>(),
            UpdateMultiNodeInventoryError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
