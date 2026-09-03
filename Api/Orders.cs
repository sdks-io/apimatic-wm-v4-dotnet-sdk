using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Extensions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Api;

public sealed class Orders
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Orders(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Acknowledge receipt of an order
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AcknowledgeOrderResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="AcknowledgeOrderError"/> when the server returns an error response.</exception>
    public Task<AcknowledgeOrderResponse> AcknowledgeOrder(string purchaseOrderId,
        AcknowledgeOrderRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders/{purchaseOrderId}/acknowledge"),
            [new TemplateParam("purchaseOrderId", purchaseOrderId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<AcknowledgeOrderResponse>(),
            AcknowledgeOrderErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Cancel order line items
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelOrderLinesResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CancelOrderLinesError"/> when the server returns an error response.</exception>
    public Task<CancelOrderLinesResponse> CancelOrderLines(string purchaseOrderId,
        CancelOrderLinesRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders/{purchaseOrderId}/cancel"),
            [new TemplateParam("purchaseOrderId", purchaseOrderId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CancelOrderLinesResponse>(),
            CancelOrderLinesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Mark order line items as delivered
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="DeliverOrderLinesResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeliverOrderLinesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Records the terminal <c>Delivered</c> event for one or more order
    /// lines, optionally with package-level proof-of-delivery
    /// (tracking number, package number, delivery timestamp). This is
    /// separated from <c>/shipment-status</c> because delivery is a
    /// terminal state and carries different downstream semantics
    /// (invoicing windows open, return windows start).
    /// <para>
    /// Walmart parity from gmp-orders-mono <c>deliverOrder</c>.
    /// </para>
    /// </remarks>
    public Task<DeliverOrderLinesResponse> DeliverOrderLines(string purchaseOrderId,
        DeliverOrderLinesRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders/{purchaseOrderId}/deliver"),
            [new TemplateParam("purchaseOrderId", purchaseOrderId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<DeliverOrderLinesResponse>(),
            DeliverOrderLinesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the order that you specify
    /// </summary>
    /// <param name="purchaseOrderId">Walmart Purchase Order ID</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetOrderResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetOrderError"/> when the server returns an error response.</exception>
    public Task<GetOrderResponse> GetOrder(string purchaseOrderId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders/{purchaseOrderId}"),
            [new TemplateParam("purchaseOrderId", purchaseOrderId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetOrderResponse>(),
            GetOrderErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the shipping address for the order you specify
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetOrderAddressResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetOrderAddressError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the ship-to postal address for a single purchase order.
    /// Mirrors Amazon SP-API <c>getOrderAddress</c>. PII-restricted endpoint:
    /// handlers are marked <c>@RestrictedData</c> server-side and the
    /// response body must NOT be logged.
    /// </remarks>
    public Task<GetOrderAddressResponse> GetOrderAddress(string purchaseOrderId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders/{purchaseOrderId}/address"),
            [new TemplateParam("purchaseOrderId", purchaseOrderId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetOrderAddressResponse>(),
            GetOrderAddressErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns buyer contact info for the order you specify
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetOrderBuyerInfoResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetOrderBuyerInfoError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the buyer's display name, email address, and an
    /// anonymized phone (last 4 digits only). Mirrors Amazon SP-API
    /// <c>getOrderBuyerInfo</c>. PII-restricted endpoint: handlers are
    /// marked <c>@RestrictedData</c> server-side and request/response
    /// bodies must NOT be logged.
    /// </remarks>
    public Task<GetOrderBuyerInfoResponse> GetOrderBuyerInfo(string purchaseOrderId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders/{purchaseOrderId}/buyerInfo"),
            [new TemplateParam("purchaseOrderId", purchaseOrderId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetOrderBuyerInfoResponse>(),
            GetOrderBuyerInfoErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the line items of the order you specify
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFulfillmentOrderShipmentsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetOrderItemsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the SKU / quantity / item-price projection of a single
    /// purchase order. Mirrors Amazon SP-API <c>getOrderItems</c>. Not
    /// PII-restricted: only product, quantity, and price are returned.
    /// </remarks>
    public Task<GetFulfillmentOrderShipmentsResponse> GetOrderItems(string purchaseOrderId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders/{purchaseOrderId}/items"),
            [new TemplateParam("purchaseOrderId", purchaseOrderId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetFulfillmentOrderShipmentsResponse>(),
            GetOrderItemsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns regulated-information for an age-restricted order
    /// </summary>
    /// <param name="purchaseOrderId">Walmart Purchase Order ID</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetOrderRegulatedInfoResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetOrderRegulatedInfoError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Parity with Amazon SP-API Orders v0 <c>getOrderRegulatedInfo</c>. Returns
    /// the verification requirements that apply to an order containing
    /// regulated items (alcohol, tobacco, age-restricted goods): the
    /// required ID-verification method, the minimum buyer age, the
    /// regulated category, and any value-added services the order ships
    /// with.
    /// <para>
    /// <b>Walmart OMS coverage gap .</b> The the underlying service Order
    /// Lookup response does not currently surface regulated-item
    /// metadata. Until upstream support lands (tracked separately as a
    /// follow-up to this PR), every order returns the safe default
    /// <c>regulatedCategory=NOT_REGULATED</c> with <c>requiredVerificationMethod=NONE</c>.
    /// The endpoint shape and contract are stable; only the projected
    /// values will become richer once OMS exposes the fields.
    /// </para>
    /// </remarks>
    public Task<GetOrderRegulatedInfoResponse> GetOrderRegulatedInfo(string purchaseOrderId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders/{purchaseOrderId}/regulatedInfo"),
            [new TemplateParam("purchaseOrderId", purchaseOrderId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetOrderRegulatedInfoResponse>(),
            GetOrderRegulatedInfoErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns orders created or updated during the specified time period
    /// </summary>
    /// <param name="createdAfter">Filter orders created after this date-time (ISO 8601).  <b>the roadmap — not yet supported.</b> Sending this parameter today returns <c>400 FILTER_NOT_SUPPORTED</c>; the Orders service does not accept date-range filters at the order level. Tracked by . Retained in the contract so SDKs generated today stay forward-compatible.</param>
    /// <param name="createdBefore">Filter orders created before this date-time (ISO 8601).  <b>the roadmap — not yet supported.</b> See <c>createdAfter</c> for the rationale and the tracking ticket.</param>
    /// <param name="lastUpdatedAfter">Filter orders updated after this date-time (ISO 8601).  <b>the roadmap — not yet supported.</b> Sending this parameter today returns <c>400 FILTER_NOT_SUPPORTED</c>; the Orders service has no order-level update-date index. Tracked by .</param>
    /// <param name="orderStatuses">Filter by order status.  <b>the roadmap limitation:</b> the Orders service accepts AT MOST ONE status per call. Passing multiple values today returns <c>400 FILTER_NOT_SUPPORTED</c>; pass a single value or omit to match all. Multi-status fan-out tracked by .</param>
    /// <param name="fulfillmentTypes">Filter by fulfillment type.  <b>the roadmap — not yet supported.</b> Sending this parameter today returns <c>400 FILTER_NOT_SUPPORTED</c>; the underlying service accepts one shipNodeType per call and multi-type fan-out is Phase 2. Tracked by .</param>
    /// <param name="nextToken"></param>
    /// <param name="pageSize"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFulfillmentOrderResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetOrdersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns orders matching the given filters. Orders are fulfilled by
    /// sellers (WFS or seller-fulfilled). Maps to Walmart OMS order queries.
    /// <para>
    /// ### Current limitations (roadmap)
    /// </para>
    /// <para>
    /// The underlying the Orders service backend does not yet support
    /// every filter declared below. Calls using any of the following will
    /// return <c>400 Bad Request</c> with <c>code=FILTER_NOT_SUPPORTED</c> and a
    /// human-readable <c>message</c> explaining the specific rejection. Phase
    /// 2
    /// will lift these one-by-one as the underlying service adds capability.
    /// </para>
    /// <para>
    /// | Filter | Status today | Reason |
    /// |---|---|---|
    /// | <c>createdAfter</c>, <c>createdBefore</c> | Rejected (400) | the Orders service does not accept date-range filters at the order level. |
    /// | <c>lastUpdatedAfter</c> | Rejected (400) | the underlying service has no order-level update-date index. |
    /// | <c>orderStatuses</c> with &gt;1 value | Rejected (400) | the underlying service accepts one status per call; pass a single value or omit to match all. |
    /// | <c>fulfillmentTypes</c> | Rejected (400) | the underlying service accepts one shipNodeType per call; multi-type fan-out is Phase 2. |
    /// </para>
    /// <para>
    /// These parameters remain in the contract (rather than being removed)
    /// so that SDKs generated today stay forward-compatible with the
    /// the roadmap surface — your code keeps compiling, only the runtime
    /// behaviour changes when Phase 2 ships. Until then, omit them or
    /// handle the documented 400 gracefully. The <c>tools/loadgen-orders.sh --contract</c>
    /// smoke sweep exercises the rejection contract on every run.
    /// </para>
    /// </remarks>
    public Task<GetFulfillmentOrderResponse> GetOrders(DateTimeOffset? createdAfter,
        DateTimeOffset? createdBefore,
        DateTimeOffset? lastUpdatedAfter,
        IReadOnlyList<OrderStatus>? orderStatuses,
        IReadOnlyList<FulfillmentType>? fulfillmentTypes,
        string? nextToken,
        int? pageSize = 100,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders"),
            [],
            [new Param("createdAfter", createdAfter?.ToIso8601()),
                new Param("createdBefore", createdBefore?.ToIso8601()),
                new Param("lastUpdatedAfter", lastUpdatedAfter?.ToIso8601()),
                new Param("orderStatuses", orderStatuses),
                new Param("fulfillmentTypes", fulfillmentTypes),
                new Param("pageSize", pageSize),
                new Param("nextToken", nextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetFulfillmentOrderResponse>(),
            GetOrdersErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Issue a seller-initiated refund for one or more order lines
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="RefundOrderLinesResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RefundOrderLinesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Walmart-specific write — no Amazon SP-API Orders v0 equivalent
    /// (Amazon refunds live in the Finance API). Mirrors
    /// gmp-orders-mono's legacy <c>/partner-api/{market}/v3/orders/{po}/refund</c>
    /// contract, simplified for the v4 surface: a flat <c>orderLines[]</c> with
    /// per-line refund amount + reason instead of the legacy three-level
    /// nesting (<c>orderLines → refunds → refundCharges</c>).
    /// </remarks>
    public Task<RefundOrderLinesResponse> RefundOrderLines(string purchaseOrderId,
        RefundOrderLinesRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders/{purchaseOrderId}/refund"),
            [new TemplateParam("purchaseOrderId", purchaseOrderId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<RefundOrderLinesResponse>(),
            RefundOrderLinesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Ship order line items and confirm shipment with tracking info
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ShipOrderLinesResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ShipOrderLinesError"/> when the server returns an error response.</exception>
    public Task<ShipOrderLinesResponse> ShipOrderLines(string purchaseOrderId,
        ShipOrderLinesRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders/{purchaseOrderId}/shipping"),
            [new TemplateParam("purchaseOrderId", purchaseOrderId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<ShipOrderLinesResponse>(),
            ShipOrderLinesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Ship an order across multiple packages
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="MultiPackageShipResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ShipOrderMultiPackageError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Walmart-specific extension of <c>/shipping</c>. Each package carries
    /// its own tracking number, carrier, dimensions, and the order
    /// lines it covers. Maps onto FMS's existing <c>shipments[]</c> envelope
    /// (one FMS shipment per v4 package). Inspired by gmp-orders-mono's
    /// <c>shipOrderV2</c> (multiPackageShipping) operation; we hoist
    /// <c>packages[]</c> to the top level rather than nesting it under each
    /// line so the request stays self-evidently package-oriented.
    /// </remarks>
    public Task<MultiPackageShipResponse> ShipOrderMultiPackage(string purchaseOrderId,
        MultiPackageShipRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders/{purchaseOrderId}/multi-package-shipping"),
            [new TemplateParam("purchaseOrderId", purchaseOrderId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<MultiPackageShipResponse>(),
            ShipOrderMultiPackageErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Update the in-transit shipment status of an order
    /// </summary>
    /// <param name="purchaseOrderId"></param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UpdateShipmentStatusResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateShipmentStatusError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Records a non-terminal shipment-lifecycle event for an order
    /// (ready for pickup, picked up, in transit, out for delivery).
    /// Use the dedicated <c>/deliver</c> endpoint for terminal delivery —
    /// it carries proof-of-delivery semantics this endpoint does not.
    /// <para>
    /// Amazon SP-API Orders v0 <c>updateShipmentStatus</c> parity.
    /// </para>
    /// </remarks>
    public Task<UpdateShipmentStatusResponse> UpdateShipmentStatus(string purchaseOrderId,
        UpdateShipmentStatusRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders/{purchaseOrderId}/shipment-status"),
            [new TemplateParam("purchaseOrderId", purchaseOrderId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<UpdateShipmentStatusResponse>(),
            UpdateShipmentStatusErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Seller confirms that buyer identity was verified at delivery
    /// </summary>
    /// <param name="purchaseOrderId">Walmart Purchase Order ID</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UpdateVerificationStatusResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateVerificationStatusError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Parity with Amazon SP-API Orders v0 <c>updateVerificationStatus</c>. The
    /// seller calls this after delivering a regulated-item order to
    /// record whether the buyer's identity / age was verified at the
    /// doorstep. An APPROVED status releases the order for settlement;
    /// REJECTED requires a <c>rejectionReason</c> and triggers downstream
    /// return-processing.
    /// <para>
    /// Gated by the CCM-managed <c>orders.features.regulatedInfoEnabled</c>
    /// kill-switch (live-refreshable, parity with the cancel kill-switch).
    /// </para>
    /// </remarks>
    public Task<UpdateVerificationStatusResponse> UpdateVerificationStatus(string purchaseOrderId,
        UpdateVerificationStatusRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/orders/v4/orders/{purchaseOrderId}/regulatedInfo"),
            [new TemplateParam("purchaseOrderId", purchaseOrderId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            new HttpMethod("PATCH"),
            JsonRequest.Create(body),
            JsonResponse.Create<UpdateVerificationStatusResponse>(),
            UpdateVerificationStatusErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
