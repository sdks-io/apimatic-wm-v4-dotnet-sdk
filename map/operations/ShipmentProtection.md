<!-- Generated file — do not edit; regenerated with the SDK. -->

# ShipmentProtection — operations

Accessor: `client.ShipmentProtection` · Source: `src/WalmartApIs/Api/ShipmentProtection.cs` · 6 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### DownloadClaimDocuments

- **Signature**: `DownloadClaimDocuments(DownloadClaimDocumentsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ClaimNumber`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `Body`
- **Returns**: `BinaryContent`
- **Error**: `ApiException<DownloadClaimDocumentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3ClaimsShipmentProtectionClaimDocuments400Error1(out V3ClaimsShipmentProtectionClaimDocuments400Error1)` [400] · `TryGetV3ClaimsShipmentProtectionClaimDocuments404Error1(out V3ClaimsShipmentProtectionClaimDocuments404Error1)` [404] · `TryGetV3ClaimsShipmentProtectionClaimDocuments500Error1(out V3ClaimsShipmentProtectionClaimDocuments500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DownloadClaimDocumentsRequest` | `src/WalmartApIs/Requests/ShipmentProtection/DownloadClaimDocumentsRequest.cs` |
| `V3ClaimsShipmentProtectionClaimDocumentsRequest` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaimDocumentsRequest.cs` |
| `DownloadClaimDocumentsError` | `src/WalmartApIs/Errors/DownloadClaimDocumentsError.cs` |
| `V3ClaimsShipmentProtectionClaimDocuments400Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaimDocuments400Error1.cs` |
| `V3ClaimsShipmentProtectionClaimDocuments404Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaimDocuments404Error1.cs` |
| `V3ClaimsShipmentProtectionClaimDocuments500Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaimDocuments500Error1.cs` |

### GetClaimDetails

- **Signature**: `GetClaimDetails(GetClaimDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ClaimNumber`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `object`
- **Error**: `ApiException<GetClaimDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3ClaimsShipmentProtectionClaim400Error1(out V3ClaimsShipmentProtectionClaim400Error1)` [400] · `TryGetV3ClaimsShipmentProtectionClaim404Error1(out V3ClaimsShipmentProtectionClaim404Error1)` [404] · `TryGetV3ClaimsShipmentProtectionClaim500Error1(out V3ClaimsShipmentProtectionClaim500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetClaimDetailsRequest` | `src/WalmartApIs/Requests/ShipmentProtection/GetClaimDetailsRequest.cs` |
| `GetClaimDetailsError` | `src/WalmartApIs/Errors/GetClaimDetailsError.cs` |
| `V3ClaimsShipmentProtectionClaim400Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaim400Error1.cs` |
| `V3ClaimsShipmentProtectionClaim404Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaim404Error1.cs` |
| `V3ClaimsShipmentProtectionClaim500Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaim500Error1.cs` |

### GetClaimHistory

- **Signature**: `GetClaimHistory(GetClaimHistoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ClaimNumber`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `V3ClaimsShipmentProtectionClaimHistoryResponse`
- **Error**: `ApiException<GetClaimHistoryError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3ClaimsShipmentProtectionClaimHistory400Error1(out V3ClaimsShipmentProtectionClaimHistory400Error1)` [400] · `TryGetV3ClaimsShipmentProtectionClaimHistory404Error1(out V3ClaimsShipmentProtectionClaimHistory404Error1)` [404] · `TryGetV3ClaimsShipmentProtectionClaimHistory500Error1(out V3ClaimsShipmentProtectionClaimHistory500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetClaimHistoryRequest` | `src/WalmartApIs/Requests/ShipmentProtection/GetClaimHistoryRequest.cs` |
| `V3ClaimsShipmentProtectionClaimHistoryResponse` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaimHistoryResponse.cs` |
| `GetClaimHistoryError` | `src/WalmartApIs/Errors/GetClaimHistoryError.cs` |
| `V3ClaimsShipmentProtectionClaimHistory400Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaimHistory400Error1.cs` |
| `V3ClaimsShipmentProtectionClaimHistory404Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaimHistory404Error1.cs` |
| `V3ClaimsShipmentProtectionClaimHistory500Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaimHistory500Error1.cs` |

### ListClaims

- **Signature**: `ListClaims(ListClaimsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Query params (wire ← C#)**: `limit` ← `Limit`, `offset` ← `Offset`, `claimsGroup` ← `ClaimsGroup`, `claimNumber` ← `ClaimNumber`, `purchaseOrderId` ← `PurchaseOrderId`, `trackingNo` ← `TrackingNo`, `claimTypes` ← `ClaimTypes`, `claimStatuses` ← `ClaimStatuses`, `sortBy` ← `SortBy`, `sortOrder` ← `SortOrder`
- **Returns**: `object`
- **Error**: `ApiException<ListClaimsError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3ClaimsShipmentProtection400Error1(out V3ClaimsShipmentProtection400Error1)` [400] · `TryGetV3ClaimsShipmentProtection401Error1(out V3ClaimsShipmentProtection401Error1)` [401] · `TryGetV3ClaimsShipmentProtection500Error1(out V3ClaimsShipmentProtection500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListClaimsRequest` | `src/WalmartApIs/Requests/ShipmentProtection/ListClaimsRequest.cs` |
| `ClaimsGroup` | `src/WalmartApIs/Models/Enums/ClaimsGroup.cs` |
| `SortBy` | `src/WalmartApIs/Models/Enums/SortBy.cs` |
| `Order` | `src/WalmartApIs/Models/Enums/Order.cs` |
| `ListClaimsError` | `src/WalmartApIs/Errors/ListClaimsError.cs` |
| `V3ClaimsShipmentProtection400Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtection400Error1.cs` |
| `V3ClaimsShipmentProtection401Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtection401Error1.cs` |
| `V3ClaimsShipmentProtection500Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtection500Error1.cs` |

### SubmitAdditionalInfo

- **Signature**: `SubmitAdditionalInfo(SubmitAdditionalInfoRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ClaimNumber`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `Files`, `DocumentTypes`
- **Returns**: `object`
- **Error**: `ApiException<SubmitAdditionalInfoError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3ClaimsShipmentProtectionClaim400Error1(out V3ClaimsShipmentProtectionClaim400Error1)` [400] · `TryGetV3ClaimsShipmentProtectionClaim404Error1(out V3ClaimsShipmentProtectionClaim404Error1)` [404] · `TryGetV3ClaimsShipmentProtectionClaim500Error1(out V3ClaimsShipmentProtectionClaim500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SubmitAdditionalInfoRequest` | `src/WalmartApIs/Requests/ShipmentProtection/SubmitAdditionalInfoRequest.cs` |
| `DocumentType1` | `src/WalmartApIs/Models/DocumentType1.cs` |
| `SubmitAdditionalInfoError` | `src/WalmartApIs/Errors/SubmitAdditionalInfoError.cs` |
| `V3ClaimsShipmentProtectionClaim400Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaim400Error1.cs` |
| `V3ClaimsShipmentProtectionClaim404Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaim404Error1.cs` |
| `V3ClaimsShipmentProtectionClaim500Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaim500Error1.cs` |

### SubmitClaim

- **Signature**: `SubmitClaim(SubmitClaimRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `Files`, `DocumentTypes`, `Payload`
- **Returns**: `object`
- **Error**: `ApiException<SubmitClaimError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3ClaimsShipmentProtectionClaim400Error1(out V3ClaimsShipmentProtectionClaim400Error1)` [400] · `TryGetV3ClaimsShipmentProtectionClaim401Error1(out V3ClaimsShipmentProtectionClaim401Error1)` [401] · `TryGetV3ClaimsShipmentProtectionClaim500Error1(out V3ClaimsShipmentProtectionClaim500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SubmitClaimRequest` | `src/WalmartApIs/Requests/ShipmentProtection/SubmitClaimRequest.cs` |
| `DocumentType` | `src/WalmartApIs/Models/DocumentType.cs` |
| `Payload` | `src/WalmartApIs/Models/Payload.cs` |
| `SubmitClaimError` | `src/WalmartApIs/Errors/SubmitClaimError.cs` |
| `V3ClaimsShipmentProtectionClaim400Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaim400Error1.cs` |
| `V3ClaimsShipmentProtectionClaim401Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaim401Error1.cs` |
| `V3ClaimsShipmentProtectionClaim500Error1` | `src/WalmartApIs/Models/V3ClaimsShipmentProtectionClaim500Error1.cs` |

