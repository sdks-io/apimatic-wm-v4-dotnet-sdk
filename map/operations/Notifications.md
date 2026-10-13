<!-- Generated file — do not edit; regenerated with the SDK. -->

# Notifications — operations

Accessor: `client.Notifications` · Source: `src/WalmartApIs/Api/Notifications.cs` · 9 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateDestination

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateDestination(CreateDestinationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `Channel`
- **Error**: `ApiException<CreateDestinationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateDestinationRequest` | `src/WalmartApIs/Requests/Notifications/CreateDestinationRequest.cs` |
| `Channel` | `src/WalmartApIs/Models/Channel.cs` |
| `CreateDestinationError` | `src/WalmartApIs/Errors/CreateDestinationError.cs` |

### CreateSubscription

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateSubscription(CreateSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `NotificationType`, `Body`
- **Returns**: `object`
- **Error**: `ApiException<CreateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateSubscriptionRequest` | `src/WalmartApIs/Requests/Notifications/CreateSubscriptionRequest.cs` |
| `CreateSubscriptionError` | `src/WalmartApIs/Errors/CreateSubscriptionError.cs` |

### DeleteDestination

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DeleteDestination(DeleteDestinationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `DestinationId`
- **Returns**: `Channel`
- **Error**: `ApiException<DeleteDestinationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteDestinationRequest` | `src/WalmartApIs/Requests/Notifications/DeleteDestinationRequest.cs` |
| `Channel` | `src/WalmartApIs/Models/Channel.cs` |
| `DeleteDestinationError` | `src/WalmartApIs/Errors/DeleteDestinationError.cs` |

### DeleteSubscriptionById

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DeleteSubscriptionById(DeleteSubscriptionByIdRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `NotificationType`
- **Returns**: `object`
- **Error**: `ApiException<DeleteSubscriptionByIdError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteSubscriptionByIdRequest` | `src/WalmartApIs/Requests/Notifications/DeleteSubscriptionByIdRequest.cs` |
| `DeleteSubscriptionByIdError` | `src/WalmartApIs/Errors/DeleteSubscriptionByIdError.cs` |

### GetDestination

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetDestination(GetDestinationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `DestinationId`
- **Returns**: `Channel`
- **Error**: `ApiException<GetDestinationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetDestinationRequest` | `src/WalmartApIs/Requests/Notifications/GetDestinationRequest.cs` |
| `Channel` | `src/WalmartApIs/Models/Channel.cs` |
| `GetDestinationError` | `src/WalmartApIs/Errors/GetDestinationError.cs` |

### GetDestinations

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetDestinations(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `ChannelList`
- **Error**: `ApiException<GetDestinationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ChannelList` | `src/WalmartApIs/Models/ChannelList.cs` |
| `GetDestinationsError` | `src/WalmartApIs/Errors/GetDestinationsError.cs` |

### GetSubscription

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetSubscription(GetSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `NotificationType`
- **Query params (wire ← C#)**: `payloadVersion` ← `PayloadVersion`
- **Returns**: `object`
- **Error**: `ApiException<GetSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetSubscriptionRequest` | `src/WalmartApIs/Requests/Notifications/GetSubscriptionRequest.cs` |
| `GetSubscriptionError` | `src/WalmartApIs/Errors/GetSubscriptionError.cs` |

### GetSubscriptionById

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetSubscriptionById(GetSubscriptionByIdRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `NotificationType`
- **Returns**: `object`
- **Error**: `ApiException<GetSubscriptionByIdError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetSubscriptionByIdRequest` | `src/WalmartApIs/Requests/Notifications/GetSubscriptionByIdRequest.cs` |
| `GetSubscriptionByIdError` | `src/WalmartApIs/Errors/GetSubscriptionByIdError.cs` |

### SendTestNotification

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SendTestNotification(SendTestNotificationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `NotificationType`, `Body`
- **Returns**: `object`
- **Error**: `ApiException<SendTestNotificationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SendTestNotificationRequest` | `src/WalmartApIs/Requests/Notifications/SendTestNotificationRequest.cs` |
| `SendTestNotificationError` | `src/WalmartApIs/Errors/SendTestNotificationError.cs` |

