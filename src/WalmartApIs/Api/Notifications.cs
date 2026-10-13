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
using WalmartApIs.Requests.Notifications;

namespace WalmartApIs.Api;

public sealed class Notifications
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Notifications(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    public Task<Channel> CreateDestination(CreateDestinationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/notifications/v4/destinations"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<Channel>(),
            CreateDestinationError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> CreateSubscription(CreateSubscriptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/notifications/v4/subscriptions/{notificationType}"),
            [new TemplateParam("notificationType", request.NotificationType)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<object>(),
            CreateSubscriptionError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<Channel> DeleteDestination(DeleteDestinationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/notifications/v4/destinations/{destinationId}"),
            [new TemplateParam("destinationId", request.DestinationId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<Channel>(),
            DeleteDestinationError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> DeleteSubscriptionById(DeleteSubscriptionByIdRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/notifications/v4/subscriptions/{notificationType}/{subscriptionId}"),
            [
                new TemplateParam("subscriptionId", request.SubscriptionId),
                new TemplateParam("notificationType", request.NotificationType),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            DeleteSubscriptionByIdError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<Channel> GetDestination(GetDestinationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/notifications/v4/destinations/{destinationId}"),
            [new TemplateParam("destinationId", request.DestinationId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Channel>(),
            GetDestinationError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<ChannelList> GetDestinations(RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/notifications/v4/destinations"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ChannelList>(),
            GetDestinationsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> GetSubscription(GetSubscriptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/notifications/v4/subscriptions/{notificationType}"),
            [new TemplateParam("notificationType", request.NotificationType)],
            [new Param("payloadVersion", request.PayloadVersion)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            GetSubscriptionError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> GetSubscriptionById(GetSubscriptionByIdRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/notifications/v4/subscriptions/{notificationType}/{subscriptionId}"),
            [
                new TemplateParam("subscriptionId", request.SubscriptionId),
                new TemplateParam("notificationType", request.NotificationType),
            ],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            GetSubscriptionByIdError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    public Task<object> SendTestNotification(SendTestNotificationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/notifications/v4/subscriptions/{notificationType}/testNotification"),
            [new TemplateParam("notificationType", request.NotificationType)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<object>(),
            SendTestNotificationError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
