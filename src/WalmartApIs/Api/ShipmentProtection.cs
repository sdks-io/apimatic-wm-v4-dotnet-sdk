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
using WalmartApIs.Requests.ShipmentProtection;

namespace WalmartApIs.Api;

public sealed class ShipmentProtection
{
    private readonly RawClient _rawClient;
    private readonly Server _server;

    internal ShipmentProtection(RawClient rawClient, Server server)
    {
        _rawClient = rawClient;
        _server = server;
    }

    /// <summary>
    /// Download claim documents
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BinaryContent"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DownloadClaimDocumentsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a ZIP file containing one or more uploaded claim documents.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US Only&lt;/b&gt;
    /// </remarks>
    public Task<BinaryContent> DownloadClaimDocuments(DownloadClaimDocumentsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/claims/shipment-protection/claim/{claimNumber}/documents"),
            [new TemplateParam("claimNumber", request.ClaimNumber)],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            BinaryResponse.Instance,
            DownloadClaimDocumentsError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get claim details
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="object"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetClaimDetailsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves detailed information for a single claim.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US Only&lt;/b&gt;
    /// </remarks>
    public Task<object> GetClaimDetails(GetClaimDetailsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/claims/shipment-protection/claim/{claimNumber}"),
            [new TemplateParam("claimNumber", request.ClaimNumber)],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            GetClaimDetailsError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get claim history
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ClaimsShipmentProtectionClaimHistoryResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetClaimHistoryError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a chronological log of status changes, notes, and uploaded documents.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US Only&lt;/b&gt;
    /// </remarks>
    public Task<V3ClaimsShipmentProtectionClaimHistoryResponse> GetClaimHistory(GetClaimHistoryRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/claims/shipment-protection/claim/{claimNumber}/history"),
            [new TemplateParam("claimNumber", request.ClaimNumber)],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3ClaimsShipmentProtectionClaimHistoryResponse>(),
            GetClaimHistoryError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get all claims
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="object"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListClaimsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a paginated list of claims, with optional filters.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US Only&lt;/b&gt;
    /// </remarks>
    public Task<object> ListClaims(ListClaimsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/claims/shipment-protection"),
            [],
            [
                new Param("limit", request.Limit),
                new Param("offset", request.Offset),
                new Param("claimsGroup", request.ClaimsGroup),
                new Param("claimNumber", request.ClaimNumber),
                new Param("purchaseOrderId", request.PurchaseOrderId),
                new Param("trackingNo", request.TrackingNo),
                new Param("claimTypes", request.ClaimTypes),
                new Param("claimStatuses", request.ClaimStatuses),
                new Param("sortBy", request.SortBy),
                new Param("sortOrder", request.SortOrder),
            ],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            ListClaimsError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Submit additional information
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="object"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="SubmitAdditionalInfoError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Adds documents or notes to an existing claim when Walmart requests more details.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US Only&lt;/b&gt;
    /// </remarks>
    public Task<object> SubmitAdditionalInfo(SubmitAdditionalInfoRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/claims/shipment-protection/claim/{claimNumber}"),
            [new TemplateParam("claimNumber", request.ClaimNumber)],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            new HttpMethod("PATCH"),
            FormRequest.Create(
                new MultipartParam("files", request.Files),
                new MultipartParam("documentTypes", request.DocumentTypes),
                new MultipartParam("notes", request.Notes)),
            JsonResponse.Create<object>(),
            SubmitAdditionalInfoError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Submit a claim
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="object"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="SubmitClaimError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a shipment-protection claim. Send multipart/form-data with files, documentTypes, and payload.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US Only&lt;/b&gt;
    /// </remarks>
    public Task<object> SubmitClaim(SubmitClaimRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/claims/shipment-protection/claim"),
            [],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            FormRequest.Create(
                new MultipartParam("files", request.Files),
                new MultipartParam("documentTypes", request.DocumentTypes),
                new MultipartParam("payload", request.Payload)),
            JsonResponse.Create<object>(),
            SubmitClaimError.Response,
            [],
            requestOptions,
            cancellationToken);
}
