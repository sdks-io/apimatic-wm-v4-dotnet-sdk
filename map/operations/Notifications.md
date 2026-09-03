<!-- Generated file — do not edit; regenerated with the SDK. -->

# Notifications — operations

Accessor: `client.Notifications` · Source: `Api/Notifications.cs` · 9 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateDestination

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateDestination(object body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `Channel`
- **Error**: `SdkException<CreateDestinationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `Channel` | `Models/Channel.cs` |
| `CreateDestinationError` | `Errors/CreateDestinationError.cs` |

### CreateSubscription

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateSubscription(string notificationType, object body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `object`
- **Error**: `SdkException<CreateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateSubscriptionError` | `Errors/CreateSubscriptionError.cs` |

### DeleteDestination

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DeleteDestination(string destinationId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `Channel`
- **Error**: `SdkException<DeleteDestinationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `Channel` | `Models/Channel.cs` |
| `DeleteDestinationError` | `Errors/DeleteDestinationError.cs` |

### DeleteSubscriptionById

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DeleteSubscriptionById(string subscriptionId, string notificationType, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `object`
- **Error**: `SdkException<DeleteSubscriptionByIdError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteSubscriptionByIdError` | `Errors/DeleteSubscriptionByIdError.cs` |

### GetDestination

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetDestination(string destinationId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `Channel`
- **Error**: `SdkException<GetDestinationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `Channel` | `Models/Channel.cs` |
| `GetDestinationError` | `Errors/GetDestinationError.cs` |

### GetDestinations

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetDestinations(RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `ChannelList`
- **Error**: `SdkException<GetDestinationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ChannelList` | `Models/ChannelList.cs` |
| `GetDestinationsError` | `Errors/GetDestinationsError.cs` |

### GetSubscription

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetSubscription(string notificationType, string? payloadVersion, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `payloadVersion` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `payloadVersion` ← `payloadVersion`
- **Returns**: `object`
- **Error**: `SdkException<GetSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetSubscriptionError` | `Errors/GetSubscriptionError.cs` |

### GetSubscriptionById

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetSubscriptionById(string subscriptionId, string notificationType, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `object`
- **Error**: `SdkException<GetSubscriptionByIdError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetSubscriptionByIdError` | `Errors/GetSubscriptionByIdError.cs` |

### SendTestNotification

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SendTestNotification(string notificationType, object body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `object`
- **Error**: `SdkException<SendTestNotificationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SendTestNotificationError` | `Errors/SendTestNotificationError.cs` |

