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
using WalmartApIs.Requests.Solicitations;

namespace WalmartApIs.Api;

public sealed class Solicitations
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Solicitations(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    public Task<object> CreateProductReviewAndSellerFeedbackSolicitation(CreateProductReviewAndSellerFeedbackSolicitationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/solicitations/v4/orders/{sp-apiOrderId}/solicitations/productReviewAndSellerFeedback"),
            [new TemplateParam("sp-apiOrderId", request.SpApiOrderId)],
            [new Param("marketplaceIds", request.MarketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            CreateProductReviewAndSellerFeedbackSolicitationError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> GetSolicitationActionsForOrder(GetSolicitationActionsForOrderRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/solicitations/v4/orders/{sp-apiOrderId}"),
            [new TemplateParam("sp-apiOrderId", request.SpApiOrderId)],
            [new Param("marketplaceIds", request.MarketplaceIds)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            GetSolicitationActionsForOrderError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
