using System;
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

namespace WalmartApIs.Api;

/// <summary>
/// Fee estimate operations for seller items
/// </summary>
public sealed class ProductFees
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ProductFees(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Returns fee estimate for a single item by Walmart Item ID
    /// </summary>
    /// <param name="walmartItemId">The Walmart Item ID of the item. Replaces SP-API ASIN.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetMyFeesEstimateResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetMyFeesEstimateForItemError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns an estimated fee for a single item identified by Walmart Item ID.
    /// Walmart Item ID replaces the SP-API ASIN path parameter.
    /// <para>
    /// SP-API equivalent: <c>getMyFeesEstimateForASIN</c> (identifier changed from
    /// ASIN to Walmart Item ID; request/response shape is otherwise 1:1).
    /// </para>
    /// </remarks>
    public Task<GetMyFeesEstimateResponse> GetMyFeesEstimateForItem(string walmartItemId,
        GetMyFeesEstimateRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/products/fees/v4/items/{WalmartItemId}/feesEstimate"),
            [new TemplateParam("WalmartItemId", walmartItemId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<GetMyFeesEstimateResponse>(),
            GetMyFeesEstimateForItemErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns fee estimate for a single item by Seller SKU
    /// </summary>
    /// <param name="sellerSku">The seller's SKU for the listing. Scoped to the authenticated seller.</param>
    /// <param name="marketplaceId">Marketplace identifier.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetMyFeesEstimateResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetMyFeesEstimateForSkuError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns an estimated fee for a seller listing identified by Seller SKU.
    /// </remarks>
    public Task<GetMyFeesEstimateResponse> GetMyFeesEstimateForSku(string sellerSku,
        string marketplaceId,
        GetMyFeesEstimateRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/products/fees/v4/listings/{SellerSKU}/feesEstimate"),
            [new TemplateParam("SellerSKU", sellerSku)],
            [new Param("MarketplaceId", marketplaceId)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<GetMyFeesEstimateResponse>(),
            GetMyFeesEstimateForSkuErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns fee estimates for a list of items
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="FeesEstimateResult"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetMyFeesEstimatesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns estimated Walmart fees for a list of items identified by
    /// Walmart Item ID or Seller SKU.
    /// </remarks>
    public Task<IReadOnlyList<FeesEstimateResult>> GetMyFeesEstimates(IReadOnlyList<FeesEstimateByIdRequest> body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/products/fees/v4/feesEstimate"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<IReadOnlyList<FeesEstimateResult>>(),
            GetMyFeesEstimatesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
