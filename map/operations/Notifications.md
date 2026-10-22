<!-- Generated file — do not edit; regenerated with the SDK. -->

# Notifications — operations

Accessor: `client.Notifications` · Source: `src/WalmartApIs/Api/Notifications.cs` · 6 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateSubscription

- **Auth**: `options.AccessToken`
- **Signature**: `CreateSubscription(CreateSubscriptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `V3WebhooksSubscriptionsResponse1`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `CreateSubscriptionOperationRequest` | `src/WalmartApIs/Requests/Notifications/CreateSubscriptionOperationRequest.cs` |
| `WmMarket2` | `src/WalmartApIs/Models/Enums/WmMarket2.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3WebhooksSubscriptionsRequest` | `src/WalmartApIs/Models/V3WebhooksSubscriptionsRequest.cs` |
| `V3WebhooksSubscriptionsResponse1` | `src/WalmartApIs/Models/V3WebhooksSubscriptionsResponse1.cs` |

### DeleteSubscription

- **Auth**: `options.AccessToken`
- **Signature**: `DeleteSubscription(DeleteSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Returns**: `V3WebhooksSubscriptionsResponse2`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `DeleteSubscriptionRequest` | `src/WalmartApIs/Requests/Notifications/DeleteSubscriptionRequest.cs` |
| `WmMarket2` | `src/WalmartApIs/Models/Enums/WmMarket2.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3WebhooksSubscriptionsResponse2` | `src/WalmartApIs/Models/V3WebhooksSubscriptionsResponse2.cs` |

### GetAllSubscriptions

- **Auth**: `options.AccessToken`
- **Signature**: `GetAllSubscriptions(GetAllSubscriptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `subscriptionId` ← `SubscriptionId`, `eventType` ← `EventType`, `resourceName` ← `ResourceName`, `status` ← `Status`
- **Returns**: `V3WebhooksSubscriptionsResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetAllSubscriptionsRequest` | `src/WalmartApIs/Requests/Notifications/GetAllSubscriptionsRequest.cs` |
| `WmMarket2` | `src/WalmartApIs/Models/Enums/WmMarket2.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3WebhooksSubscriptionsResponse` | `src/WalmartApIs/Models/V3WebhooksSubscriptionsResponse.cs` |

### GetEventTypes

- **Auth**: `options.AccessToken`
- **Signature**: `GetEventTypes(GetEventTypesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Returns**: `V3WebhooksEventTypesResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetEventTypesRequest` | `src/WalmartApIs/Requests/Notifications/GetEventTypesRequest.cs` |
| `WmMarket2` | `src/WalmartApIs/Models/Enums/WmMarket2.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3WebhooksEventTypesResponse` | `src/WalmartApIs/Models/V3WebhooksEventTypesResponse.cs` |

### TestNotification

- **Auth**: `options.AccessToken`
- **Signature**: `TestNotification(TestNotificationOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `RejectRecommendationsResponsePayload`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `TestNotificationOperationRequest` | `src/WalmartApIs/Requests/Notifications/TestNotificationOperationRequest.cs` |
| `WmMarket2` | `src/WalmartApIs/Models/Enums/WmMarket2.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3WebhooksTestRequest` | `src/WalmartApIs/Models/V3WebhooksTestRequest.cs` |
| `RejectRecommendationsResponsePayload` | `src/WalmartApIs/Models/RejectRecommendationsResponsePayload.cs` |

### UpdateSubscription

- **Auth**: `options.AccessToken`
- **Signature**: `UpdateSubscription(UpdateSubscriptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `V3WebhooksSubscriptionsResponse3`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `UpdateSubscriptionOperationRequest` | `src/WalmartApIs/Requests/Notifications/UpdateSubscriptionOperationRequest.cs` |
| `WmMarket2` | `src/WalmartApIs/Models/Enums/WmMarket2.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3WebhooksSubscriptionsRequest1` | `src/WalmartApIs/Models/V3WebhooksSubscriptionsRequest1.cs` |
| `V3WebhooksSubscriptionsResponse3` | `src/WalmartApIs/Models/V3WebhooksSubscriptionsResponse3.cs` |

