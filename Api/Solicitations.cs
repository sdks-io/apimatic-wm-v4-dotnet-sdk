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

    public Task<object> CreateProductReviewAndSellerFeedbackSolicitation(string spApiOrderId,
        IReadOnlyList<string> marketplaceIds,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/solicitations/v4/orders/{sp-apiOrderId}/solicitations/productReviewAndSellerFeedback"),
            [new TemplateParam("sp-apiOrderId", spApiOrderId)],
            [new Param("marketplaceIds", marketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            CreateProductReviewAndSellerFeedbackSolicitationErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> GetSolicitationActionsForOrder(string spApiOrderId,
        IReadOnlyList<string> marketplaceIds,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/solicitations/v4/orders/{sp-apiOrderId}"),
            [new TemplateParam("sp-apiOrderId", spApiOrderId)],
            [new Param("marketplaceIds", marketplaceIds)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            GetSolicitationActionsForOrderErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
