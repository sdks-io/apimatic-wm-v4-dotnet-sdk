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

public sealed class Messaging
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Messaging(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    public Task<object> CreateWarranty(string spApiOrderId,
        IReadOnlyList<string> marketplaceIds,
        object body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/warranty"),
            [new TemplateParam("sp-apiOrderId", spApiOrderId)],
            [new Param("marketplaceIds", marketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<object>(),
            CreateWarrantyErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> GetAttributes(string spApiOrderId,
        IReadOnlyList<string> marketplaceIds,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/messaging/v4/orders/{sp-apiOrderId}/attributes"),
            [new TemplateParam("sp-apiOrderId", spApiOrderId)],
            [new Param("marketplaceIds", marketplaceIds)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            GetAttributesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> ConfirmCustomizationDetails(string spApiOrderId,
        IReadOnlyList<string> marketplaceIds,
        object body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/confirmCustomizationDetails"),
            [new TemplateParam("sp-apiOrderId", spApiOrderId)],
            [new Param("marketplaceIds", marketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<object>(),
            ConfirmCustomizationDetailsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> CreateConfirmDeliveryDetails(string spApiOrderId,
        IReadOnlyList<string> marketplaceIds,
        object body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/confirmDeliveryDetails"),
            [new TemplateParam("sp-apiOrderId", spApiOrderId)],
            [new Param("marketplaceIds", marketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<object>(),
            CreateConfirmDeliveryDetailsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> CreateConfirmOrderDetails(string spApiOrderId,
        IReadOnlyList<string> marketplaceIds,
        object body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/confirmOrderDetails"),
            [new TemplateParam("sp-apiOrderId", spApiOrderId)],
            [new Param("marketplaceIds", marketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<object>(),
            CreateConfirmOrderDetailsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> CreateConfirmServiceDetails(string spApiOrderId,
        IReadOnlyList<string> marketplaceIds,
        object body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/confirmServiceDetails"),
            [new TemplateParam("sp-apiOrderId", spApiOrderId)],
            [new Param("marketplaceIds", marketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<object>(),
            CreateConfirmServiceDetailsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> CreateDigitalAccessKey(string spApiOrderId,
        IReadOnlyList<string> marketplaceIds,
        object body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/digitalAccessKey"),
            [new TemplateParam("sp-apiOrderId", spApiOrderId)],
            [new Param("marketplaceIds", marketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<object>(),
            CreateDigitalAccessKeyErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> CreateLegalDisclosure(string spApiOrderId,
        IReadOnlyList<string> marketplaceIds,
        object body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/legalDisclosure"),
            [new TemplateParam("sp-apiOrderId", spApiOrderId)],
            [new Param("marketplaceIds", marketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<object>(),
            CreateLegalDisclosureErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> CreateUnexpectedProblem(string spApiOrderId,
        IReadOnlyList<string> marketplaceIds,
        object body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/unexpectedProblem"),
            [new TemplateParam("sp-apiOrderId", spApiOrderId)],
            [new Param("marketplaceIds", marketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<object>(),
            CreateUnexpectedProblemErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> GetMessagingActionsForOrder(string spApiOrderId,
        IReadOnlyList<string> marketplaceIds,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/messaging/v4/orders/{sp-apiOrderId}"),
            [new TemplateParam("sp-apiOrderId", spApiOrderId)],
            [new Param("marketplaceIds", marketplaceIds)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            GetMessagingActionsForOrderErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> SendInvoice(string spApiOrderId,
        IReadOnlyList<string> marketplaceIds,
        object body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/invoice"),
            [new TemplateParam("sp-apiOrderId", spApiOrderId)],
            [new Param("marketplaceIds", marketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<object>(),
            SendInvoiceErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
