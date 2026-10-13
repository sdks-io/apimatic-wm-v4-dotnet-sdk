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
using WalmartApIs.Requests.ProductFees;

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
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetMyFeesEstimateResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetMyFeesEstimateForItemError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns an estimated fee for a single item identified by Walmart Item ID.
    /// Walmart Item ID replaces the SP-API ASIN path parameter.
    /// <para>
    /// SP-API equivalent: <c>getMyFeesEstimateForASIN</c> (identifier changed from
    /// ASIN to Walmart Item ID; request/response shape is otherwise 1:1).
    /// </para>
    /// </remarks>
    public Task<GetMyFeesEstimateResponse> GetMyFeesEstimateForItem(GetMyFeesEstimateForItemRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/products/fees/v4/items/{WalmartItemId}/feesEstimate"),
            [new TemplateParam("WalmartItemId", request.WalmartItemId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<GetMyFeesEstimateResponse>(),
            GetMyFeesEstimateForItemError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns fee estimate for a single item by Seller SKU
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetMyFeesEstimateResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetMyFeesEstimateForSkuError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns an estimated fee for a seller listing identified by Seller SKU.
    /// </remarks>
    public Task<GetMyFeesEstimateResponse> GetMyFeesEstimateForSku(GetMyFeesEstimateForSkuRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/products/fees/v4/listings/{SellerSKU}/feesEstimate"),
            [new TemplateParam("SellerSKU", request.SellerSku)],
            [new Param("MarketplaceId", request.MarketplaceId)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<GetMyFeesEstimateResponse>(),
            GetMyFeesEstimateForSkuError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns fee estimates for a list of items
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="FeesEstimateResult"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetMyFeesEstimatesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns estimated Walmart fees for a list of items identified by
    /// Walmart Item ID or Seller SKU.
    /// </remarks>
    public Task<IReadOnlyList<FeesEstimateResult>> GetMyFeesEstimates(GetMyFeesEstimatesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/products/fees/v4/feesEstimate"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<IReadOnlyList<FeesEstimateResult>>(),
            GetMyFeesEstimatesError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
