<!-- Generated file — do not edit; regenerated with the SDK. -->

# SimplifiedShippingSettings — operations

Accessor: `client.SimplifiedShippingSettings` · Source: `src/WalmartApIs/Api/SimplifiedShippingSettings.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### BulkMigrateOffersForSimplifiedShippingSettings

- **Signature**: `BulkMigrateOffersForSimplifiedShippingSettings(BulkMigrateOffersForSimplifiedShippingSettingsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Query params (wire ← C#)**: `feedType` ← `FeedType`, `requestType` ← `RequestType`
- **Returns**: `FeedId1`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `BulkMigrateOffersForSimplifiedShippingSettingsRequest` | `src/WalmartApIs/Requests/SimplifiedShippingSettings/BulkMigrateOffersForSimplifiedShippingSettingsRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3FeedsRequest1` | `src/WalmartApIs/Models/V3FeedsRequest1.cs` |
| `FeedId1` | `src/WalmartApIs/Models/FeedId1.cs` |

### CreateSimplifiedShippingSettings

- **Signature**: `CreateSimplifiedShippingSettings(CreateSimplifiedShippingSettingsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `IReadOnlyList<V3SettingsShippingSimplifiedshippingsettingsAccountResponse1>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `CreateSimplifiedShippingSettingsOperationRequest` | `src/WalmartApIs/Requests/SimplifiedShippingSettings/CreateSimplifiedShippingSettingsOperationRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3SettingsShippingSimplifiedshippingsettingsAccountRequest1` | `src/WalmartApIs/Models/V3SettingsShippingSimplifiedshippingsettingsAccountRequest1.cs` |
| `V3SettingsShippingSimplifiedshippingsettingsAccountResponse1` | `src/WalmartApIs/Models/V3SettingsShippingSimplifiedshippingsettingsAccountResponse1.cs` |

### GetSimplifiedShippingSettings

- **Signature**: `GetSimplifiedShippingSettings(GetSimplifiedShippingSettingsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Returns**: `IReadOnlyList<V3SettingsShippingSimplifiedshippingsettingsResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetSimplifiedShippingSettingsRequest` | `src/WalmartApIs/Requests/SimplifiedShippingSettings/GetSimplifiedShippingSettingsRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3SettingsShippingSimplifiedshippingsettingsResponse` | `src/WalmartApIs/Models/V3SettingsShippingSimplifiedshippingsettingsResponse.cs` |

### UpdateFcLevelSimplifiedShippingSettings

- **Signature**: `UpdateFcLevelSimplifiedShippingSettings(UpdateFcLevelSimplifiedShippingSettingsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `IReadOnlyList<V3SettingsShippingSimplifiedshippingsettingsFulfillmentcenterResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `UpdateFcLevelSimplifiedShippingSettingsOperationRequest` | `src/WalmartApIs/Requests/SimplifiedShippingSettings/UpdateFcLevelSimplifiedShippingSettingsOperationRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3SettingsShippingSimplifiedshippingsettingsFulfillmentcenterRequest` | `src/WalmartApIs/Models/V3SettingsShippingSimplifiedshippingsettingsFulfillmentcenterRequest.cs` |
| `V3SettingsShippingSimplifiedshippingsettingsFulfillmentcenterResponse` | `src/WalmartApIs/Models/V3SettingsShippingSimplifiedshippingsettingsFulfillmentcenterResponse.cs` |

### UpdateSimplifiedShippingSettings

- **Signature**: `UpdateSimplifiedShippingSettings(UpdateSimplifiedShippingSettingsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `IReadOnlyList<V3SettingsShippingSimplifiedshippingsettingsAccountResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `UpdateSimplifiedShippingSettingsOperationRequest` | `src/WalmartApIs/Requests/SimplifiedShippingSettings/UpdateSimplifiedShippingSettingsOperationRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3SettingsShippingSimplifiedshippingsettingsAccountRequest` | `src/WalmartApIs/Models/V3SettingsShippingSimplifiedshippingsettingsAccountRequest.cs` |
| `V3SettingsShippingSimplifiedshippingsettingsAccountResponse` | `src/WalmartApIs/Models/V3SettingsShippingSimplifiedshippingsettingsAccountResponse.cs` |

