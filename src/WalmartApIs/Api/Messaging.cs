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
using WalmartApIs.Requests.Messaging;

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

    public Task<object> CreateWarranty(CreateWarrantyRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/warranty"),
            [new TemplateParam("sp-apiOrderId", request.SpApiOrderId)],
            [new Param("marketplaceIds", request.MarketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<object>(),
            CreateWarrantyError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> GetAttributes(GetAttributesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/messaging/v4/orders/{sp-apiOrderId}/attributes"),
            [new TemplateParam("sp-apiOrderId", request.SpApiOrderId)],
            [new Param("marketplaceIds", request.MarketplaceIds)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            GetAttributesError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> ConfirmCustomizationDetails(ConfirmCustomizationDetailsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/confirmCustomizationDetails"),
            [new TemplateParam("sp-apiOrderId", request.SpApiOrderId)],
            [new Param("marketplaceIds", request.MarketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<object>(),
            ConfirmCustomizationDetailsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> CreateConfirmDeliveryDetails(CreateConfirmDeliveryDetailsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/confirmDeliveryDetails"),
            [new TemplateParam("sp-apiOrderId", request.SpApiOrderId)],
            [new Param("marketplaceIds", request.MarketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<object>(),
            CreateConfirmDeliveryDetailsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> CreateConfirmOrderDetails(CreateConfirmOrderDetailsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/confirmOrderDetails"),
            [new TemplateParam("sp-apiOrderId", request.SpApiOrderId)],
            [new Param("marketplaceIds", request.MarketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<object>(),
            CreateConfirmOrderDetailsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> CreateConfirmServiceDetails(CreateConfirmServiceDetailsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/confirmServiceDetails"),
            [new TemplateParam("sp-apiOrderId", request.SpApiOrderId)],
            [new Param("marketplaceIds", request.MarketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<object>(),
            CreateConfirmServiceDetailsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> CreateDigitalAccessKey(CreateDigitalAccessKeyRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/digitalAccessKey"),
            [new TemplateParam("sp-apiOrderId", request.SpApiOrderId)],
            [new Param("marketplaceIds", request.MarketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<object>(),
            CreateDigitalAccessKeyError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> CreateLegalDisclosure(CreateLegalDisclosureRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/legalDisclosure"),
            [new TemplateParam("sp-apiOrderId", request.SpApiOrderId)],
            [new Param("marketplaceIds", request.MarketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<object>(),
            CreateLegalDisclosureError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> CreateUnexpectedProblem(CreateUnexpectedProblemRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/unexpectedProblem"),
            [new TemplateParam("sp-apiOrderId", request.SpApiOrderId)],
            [new Param("marketplaceIds", request.MarketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<object>(),
            CreateUnexpectedProblemError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> GetMessagingActionsForOrder(GetMessagingActionsForOrderRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/messaging/v4/orders/{sp-apiOrderId}"),
            [new TemplateParam("sp-apiOrderId", request.SpApiOrderId)],
            [new Param("marketplaceIds", request.MarketplaceIds)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            GetMessagingActionsForOrderError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> SendInvoice(SendInvoiceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/messaging/v4/orders/{sp-apiOrderId}/messages/invoice"),
            [new TemplateParam("sp-apiOrderId", request.SpApiOrderId)],
            [new Param("marketplaceIds", request.MarketplaceIds)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<object>(),
            SendInvoiceError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
