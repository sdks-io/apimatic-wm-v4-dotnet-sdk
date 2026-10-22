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
using WalmartApIs.Requests.ShipWithWalmart;

namespace WalmartApIs.Api;

public sealed class ShipWithWalmart
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ShipWithWalmart(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create label
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ShippingLabelsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateLabelError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Generates a shipping label using the provided shipment information. A successful response includes a tracking number and a label file in the media type specified in the Accept header.&lt;br&gt;&lt;br&gt;This API is supported for &lt;b&gt;all shipping programs&lt;/b&gt;, including &lt;b&gt;Walmart Provided Shipping (WPS)&lt;/b&gt; and &lt;b&gt;Ship with Walmart (SWW)&lt;/b&gt;.&lt;br&gt;&lt;br&gt;&lt;b&gt;Media Type Options (via Accept header):&lt;/b&gt;&lt;br&gt;• application/json, application/pdf → Returns label in PDF format.
    /// • application/json, image/png → Returns label in PNG format.
    /// • application/json → Returns tracking info only in JSON. &lt;br&gt;&lt;br&gt; &lt;b&gt;Note:&lt;/b&gt; The &lt;b&gt;Ship with Walmart service from China to the U.S.&lt;/b&gt; is &lt;b&gt;paused until further notice&lt;/b&gt;.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3ShippingLabelsResponse> CreateLabel(CreateLabelRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/shipping/labels"),
            [],
            [],
            [
                new HeaderParam("Accept", request.Accept),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3ShippingLabelsResponse>(),
            CreateLabelError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create label with Multi Package
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ShippingMultiPackageLabelsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateLabelMpsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a shipping label for items, supporting multiple packages per request. A successful response includes a tracking number and a label file in the media type specified by the Accept header. This API supports &lt;b&gt;all shipping programs&lt;/b&gt;, including &lt;b&gt;Walmart Provided Shipping (WPS)&lt;/b&gt; and &lt;b&gt;Ship with Walmart (SWW)&lt;/b&gt;.&lt;br&gt;&lt;br&gt;&lt;b&gt;Media Type Options (via Accept header):&lt;/b&gt;&lt;br&gt;•application/json, application/pdf → Returns the label in PDF format.&lt;br&gt;•application/json → Returns tracking info only, in JSON format.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: CA | MX&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3ShippingMultiPackageLabelsResponse> CreateLabelMps(CreateLabelMpsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/shipping/multi-package/labels"),
            [],
            [],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("Accept", request.Accept),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3ShippingMultiPackageLabelsResponse>(),
            CreateLabelMpsError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Discard label
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ShippingLabelsCarriersTrackingsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DiscardLabelError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Marks a previously generated shipping label as discarded.
    /// This API is used when the label should no longer be used for shipment processing. &lt;br&gt;&lt;br&gt; &lt;b&gt;Applicable Shipping Programs:&lt;/b&gt;&lt;br&gt;This API is supported for the following &lt;b&gt;shipping programs:  Walmart Provided Shipping (WPS) and Ship with Walmart (SWW).&lt;/b&gt;
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3ShippingLabelsCarriersTrackingsResponse> DiscardLabel(DiscardLabelRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/shipping/labels/carriers/{carrierShortName}/trackings/{trackingNo}"),
            [
                new TemplateParam("carrierShortName", request.CarrierShortName),
                new TemplateParam("trackingNo", request.TrackingNo),
            ],
            [],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<V3ShippingLabelsCarriersTrackingsResponse>(),
            DiscardLabelError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Supported carrier package types
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ShippingLabelsCarriersPackageTypesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API retrieves all supported package types for the selected carrier.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3ShippingLabelsCarriersPackageTypesResponse> GetCarrierPackageTypes(GetCarrierPackageTypesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/shipping/labels/carriers/{carrierShortName}/package-types"),
            [new TemplateParam("carrierShortName", request.CarrierShortName)],
            [],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3ShippingLabelsCarriersPackageTypesResponse>(),
            RawErrorResponse.Instance,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Supported carriers
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ShippingLabelsCarriersResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API retrieves all carriers supported by Ship With Walmart.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3ShippingLabelsCarriersResponse> GetCarriers(GetCarriersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/shipping/labels/carriers"),
            [],
            [],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3ShippingLabelsCarriersResponse>(),
            RawErrorResponse.Instance,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Label details by purchase order ID
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ShippingLabelsPurchaseOrdersResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API retrieves all label details generated for a purchase order id.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3ShippingLabelsPurchaseOrdersResponse> GetLabel(GetLabelRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/shipping/labels/purchase-orders/{purchaseOrderId}"),
            [new TemplateParam("purchaseOrderId", request.PurchaseOrderId)],
            [],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3ShippingLabelsPurchaseOrdersResponse>(),
            RawErrorResponse.Instance,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Download label
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves the shipping label for a specific carrier and tracking number combination.
    /// The response includes the tracking number and the label in the requested media type (PDF or PNG), based on the Accept header provided. &lt;br&gt;&lt;br&gt; &lt;b&gt;Media Type Options:&lt;/b&gt;&lt;br&gt;•Accept: application/json,application/pdf → Returns label in PDF format.&lt;br&gt;•Accept: application/json,image/png → Returns label in PNG format. &lt;br&gt;&lt;br&gt;&lt;b&gt;Market and Shipment Program Applicability:&lt;/b&gt;&lt;br&gt;•&lt;b&gt;CL&lt;/b&gt; : Applicable for &lt;b&gt;International&lt;/b&gt; shipments only.&lt;br&gt;•&lt;b&gt;US, MX, CA&lt;/b&gt;: Applicable for &lt;b&gt;Domestic and International&lt;/b&gt; shipments across &lt;b&gt;all shipping programs&lt;/b&gt; (including &lt;b&gt;Walmart Provided Shipping (WPS)&lt;/b&gt; and &lt;b&gt;Ship with Walmart (SWW)&lt;/b&gt;).
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task GetLabelByTrackingAndCarrier(GetLabelByTrackingAndCarrierRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/shipping/labels/carriers/{carrierShortName}/trackings/{trackingNo}"),
            [
                new TemplateParam("carrierShortName", request.CarrierShortName),
                new TemplateParam("trackingNo", request.TrackingNo),
            ],
            [],
            [
                new HeaderParam("accept", request.Accept),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            VoidResponse.Instance,
            RawErrorResponse.Instance,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Download scan form
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BinaryContent"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API retrieves a scan form for a given manifest ID.
    /// <para>
    /// <b>Rate Limits:</b> This endpoint allows 100 requests per minute. Exceeding this limit returns a <c>429 Too Many Requests</c> response. See the <see href="https://developer.walmart.com/us-marketplace/docs/rate-limiting">Rate Limiting guide</see> for full details. The response includes <c>x-current-token-count</c> (remaining requests in the current window) and <c>X-Next-Replenishment-Time</c> (when the token count next increases).
    /// </para>
    /// <para>
    /// <b>Sandbox:</b> Use base URL <c>https://sandbox.walmartapis.com</c>. The sandbox returns a stub binary document for any valid sandbox <c>manifestId</c>. The <c>documentFormat</c> selection (PDF/ZPL/PNG) is honored in production; in sandbox, a PDF stub is always returned regardless of the format requested during scan form creation.
    /// </para>
    /// <para>
    /// <b>Note:</b> This endpoint returns a binary document stream (application/octet-stream). Treat the response body as bytes and save it to a file. The underlying document format aligns with the scan form documentFormat selected during creation (for example, PDF, ZPL, PNG).
    /// </para>
    /// </remarks>
    public Task<BinaryContent> GetScanFormByManifestId(GetScanFormByManifestIdRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/shipping/scan-form"),
            [],
            [new Param("manifestId", request.ManifestId)],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("Accept", request.Accept),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            BinaryResponse.Instance,
            RawErrorResponse.Instance,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Shipping estimates
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ShippingLabelsShippingEstimatesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetShippingEstimateError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API retrieves shipping cost estimates for available shipping services based on address and package (example, customer address, packaged weight.)
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3ShippingLabelsShippingEstimatesResponse> GetShippingEstimate(GetShippingEstimateRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/shipping/labels/shipping-estimates"),
            [],
            [],
            [
                new HeaderParam("Accept", request.Accept),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3ShippingLabelsShippingEstimatesResponse>(),
            GetShippingEstimateError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create scan form for labels
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ShippingScanFormResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ScanFormError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API generates a scan form using the provided tracking numbers. The scan form is a consolidated document that contains all the tracking numbers and shipping details for the packages being shipped out on a particular day. It is used by carriers to verify and process the shipments during pickup and delivery. Currently, only USPS supports scan forms.
    /// <para>
    /// <b>Idempotency:</b> <c>scanFormId</c> acts as a natural idempotency key — the client supplies it in the request body before the call. Submitting a second POST with a <c>scanFormId</c> that was already successfully processed returns <c>409 Conflict</c>; no duplicate scan form is created. On network failure or timeout, clients may safely retry using the same <c>scanFormId</c>. This guarantee is critical for EOD automation — a duplicate manifest can cause carrier processing errors and shipment delays.
    /// </para>
    /// <para>
    /// <b>Rate Limits:</b> This endpoint allows 100 requests per minute. Exceeding this limit returns a <c>429 Too Many Requests</c> response. See the <see href="https://developer.walmart.com/us-marketplace/docs/rate-limiting">Rate Limiting guide</see> for full details. The response includes <c>x-current-token-count</c> (remaining requests in the current window) and <c>X-Next-Replenishment-Time</c> (when the token count next increases).
    /// </para>
    /// <para>
    /// <b>Sandbox:</b> Use base URL <c>https://sandbox.walmartapis.com</c>. The sandbox accepts test tracking numbers and returns a synthetic <c>manifestId</c> (e.g. <c>SANDBOX-12345</c>). Use that <c>manifestId</c> with the GET endpoint to retrieve the stub scan form document.
    /// </para>
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3ShippingScanFormResponse> ScanForm(ScanFormRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/shipping/scan-form"),
            [],
            [],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("Accept", request.Accept),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3ShippingScanFormResponse>(),
            ScanFormError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
