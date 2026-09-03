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

    public Task<Channel> CreateDestination(object body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/notifications/v4/destinations"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<Channel>(),
            CreateDestinationErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> CreateSubscription(string notificationType,
        object body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/notifications/v4/subscriptions/{notificationType}"),
            [new TemplateParam("notificationType", notificationType)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<object>(),
            CreateSubscriptionErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<Channel> DeleteDestination(string destinationId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/notifications/v4/destinations/{destinationId}"),
            [new TemplateParam("destinationId", destinationId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<Channel>(),
            DeleteDestinationErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> DeleteSubscriptionById(string subscriptionId,
        string notificationType,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/notifications/v4/subscriptions/{notificationType}/{subscriptionId}"),
            [new TemplateParam("subscriptionId", subscriptionId),
                new TemplateParam("notificationType", notificationType)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            DeleteSubscriptionByIdErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<Channel> GetDestination(string destinationId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/notifications/v4/destinations/{destinationId}"),
            [new TemplateParam("destinationId", destinationId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Channel>(),
            GetDestinationErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<ChannelList> GetDestinations(RequestOptions? requestOptions = null, CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/notifications/v4/destinations"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ChannelList>(),
            GetDestinationsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> GetSubscription(string notificationType,
        string? payloadVersion,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/notifications/v4/subscriptions/{notificationType}"),
            [new TemplateParam("notificationType", notificationType)],
            [new Param("payloadVersion", payloadVersion)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            GetSubscriptionErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> GetSubscriptionById(string subscriptionId,
        string notificationType,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/notifications/v4/subscriptions/{notificationType}/{subscriptionId}"),
            [new TemplateParam("subscriptionId", subscriptionId),
                new TemplateParam("notificationType", notificationType)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            GetSubscriptionByIdErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    public Task<object> SendTestNotification(string notificationType,
        object body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/notifications/v4/subscriptions/{notificationType}/testNotification"),
            [new TemplateParam("notificationType", notificationType)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<object>(),
            SendTestNotificationErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
