<!-- Generated file — do not edit; regenerated with the SDK. -->

# ShipWithWalmart — operations

Accessor: `client.ShipWithWalmart` · Source: `src/WalmartApIs/Api/ShipWithWalmart.cs` · 10 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateLabel

- **Auth**: `options.AccessToken`
- **Signature**: `CreateLabel(CreateLabelRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Accept`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `V3ShippingLabelsResponse`
- **Error**: `ApiException<CreateLabelError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3ShippingLabels500Error1(out V3ShippingLabels500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateLabelRequest` | `src/WalmartApIs/Requests/ShipWithWalmart/CreateLabelRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3ShippingLabelsRequest` | `src/WalmartApIs/Models/V3ShippingLabelsRequest.cs` |
| `V3ShippingLabelsResponse` | `src/WalmartApIs/Models/V3ShippingLabelsResponse.cs` |
| `CreateLabelError` | `src/WalmartApIs/Errors/CreateLabelError.cs` |
| `V3ShippingLabels500Error1` | `src/WalmartApIs/Models/V3ShippingLabels500Error1.cs` |

### CreateLabelMps

- **Auth**: `options.AccessToken`
- **Signature**: `CreateLabelMps(CreateLabelMpsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Accept`, `Body`
- **Returns**: `V3ShippingMultiPackageLabelsResponse`
- **Error**: `ApiException<CreateLabelMpsError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError5(out IReadOnlyList<Error5>)` [400] · `TryGetV3ShippingMultiPackageLabels500Error1(out V3ShippingMultiPackageLabels500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateLabelMpsRequest` | `src/WalmartApIs/Requests/ShipWithWalmart/CreateLabelMpsRequest.cs` |
| `WmMarket11` | `src/WalmartApIs/Models/Enums/WmMarket11.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3ShippingMultiPackageLabelsRequest` | `src/WalmartApIs/Models/V3ShippingMultiPackageLabelsRequest.cs` |
| `V3ShippingMultiPackageLabelsResponse` | `src/WalmartApIs/Models/V3ShippingMultiPackageLabelsResponse.cs` |
| `CreateLabelMpsError` | `src/WalmartApIs/Errors/CreateLabelMpsError.cs` |
| `Error5` | `src/WalmartApIs/Models/Error5.cs` |
| `V3ShippingMultiPackageLabels500Error1` | `src/WalmartApIs/Models/V3ShippingMultiPackageLabels500Error1.cs` |

### DiscardLabel

- **Auth**: `options.AccessToken`
- **Signature**: `DiscardLabel(DiscardLabelRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CarrierShortName`, `TrackingNo`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Returns**: `V3ShippingLabelsCarriersTrackingsResponse`
- **Error**: `ApiException<DiscardLabelError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfV3ShippingLabelsCarriersTrackings400Error1(out IReadOnlyList<V3ShippingLabelsCarriersTrackings400Error1>)` [400] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DiscardLabelRequest` | `src/WalmartApIs/Requests/ShipWithWalmart/DiscardLabelRequest.cs` |
| `WmMarket6` | `src/WalmartApIs/Models/Enums/WmMarket6.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3ShippingLabelsCarriersTrackingsResponse` | `src/WalmartApIs/Models/V3ShippingLabelsCarriersTrackingsResponse.cs` |
| `DiscardLabelError` | `src/WalmartApIs/Errors/DiscardLabelError.cs` |
| `V3ShippingLabelsCarriersTrackings400Error1` | `src/WalmartApIs/Models/V3ShippingLabelsCarriersTrackings400Error1.cs` |

### GetCarrierPackageTypes

- **Auth**: `options.AccessToken`
- **Signature**: `GetCarrierPackageTypes(GetCarrierPackageTypesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CarrierShortName`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Returns**: `V3ShippingLabelsCarriersPackageTypesResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetCarrierPackageTypesRequest` | `src/WalmartApIs/Requests/ShipWithWalmart/GetCarrierPackageTypesRequest.cs` |
| `WmMarket11` | `src/WalmartApIs/Models/Enums/WmMarket11.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3ShippingLabelsCarriersPackageTypesResponse` | `src/WalmartApIs/Models/V3ShippingLabelsCarriersPackageTypesResponse.cs` |

### GetCarriers

- **Auth**: `options.AccessToken`
- **Signature**: `GetCarriers(GetCarriersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Returns**: `V3ShippingLabelsCarriersResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetCarriersRequest` | `src/WalmartApIs/Requests/ShipWithWalmart/GetCarriersRequest.cs` |
| `WmMarket11` | `src/WalmartApIs/Models/Enums/WmMarket11.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3ShippingLabelsCarriersResponse` | `src/WalmartApIs/Models/V3ShippingLabelsCarriersResponse.cs` |

### GetLabel

- **Auth**: `options.AccessToken`
- **Signature**: `GetLabel(GetLabelRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Returns**: `V3ShippingLabelsPurchaseOrdersResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetLabelRequest` | `src/WalmartApIs/Requests/ShipWithWalmart/GetLabelRequest.cs` |
| `WmMarket11` | `src/WalmartApIs/Models/Enums/WmMarket11.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3ShippingLabelsPurchaseOrdersResponse` | `src/WalmartApIs/Models/V3ShippingLabelsPurchaseOrdersResponse.cs` |

### GetLabelByTrackingAndCarrier

- **Auth**: `options.AccessToken`
- **Signature**: `GetLabelByTrackingAndCarrier(GetLabelByTrackingAndCarrierRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CarrierShortName`, `TrackingNo`, `Accept`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetLabelByTrackingAndCarrierRequest` | `src/WalmartApIs/Requests/ShipWithWalmart/GetLabelByTrackingAndCarrierRequest.cs` |
| `WmMarket11` | `src/WalmartApIs/Models/Enums/WmMarket11.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |

### GetScanFormByManifestId

- **Auth**: `options.AccessToken`
- **Signature**: `GetScanFormByManifestId(GetScanFormByManifestIdRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ManifestId`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Accept`
- **Query params (wire ← C#)**: `manifestId` ← `ManifestId`
- **Returns**: `BinaryContent`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetScanFormByManifestIdRequest` | `src/WalmartApIs/Requests/ShipWithWalmart/GetScanFormByManifestIdRequest.cs` |
| `WmMarket` | `src/WalmartApIs/Models/Enums/WmMarket.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |

### GetShippingEstimate

- **Auth**: `options.AccessToken`
- **Signature**: `GetShippingEstimate(GetShippingEstimateRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Accept`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `V3ShippingLabelsShippingEstimatesResponse`
- **Error**: `ApiException<GetShippingEstimateError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfV3ShippingLabelsShippingEstimates400Error1(out IReadOnlyList<V3ShippingLabelsShippingEstimates400Error1>)` [400] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetShippingEstimateRequest` | `src/WalmartApIs/Requests/ShipWithWalmart/GetShippingEstimateRequest.cs` |
| `WmMarket11` | `src/WalmartApIs/Models/Enums/WmMarket11.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3ShippingLabelsShippingEstimatesRequest` | `src/WalmartApIs/Models/V3ShippingLabelsShippingEstimatesRequest.cs` |
| `V3ShippingLabelsShippingEstimatesResponse` | `src/WalmartApIs/Models/V3ShippingLabelsShippingEstimatesResponse.cs` |
| `GetShippingEstimateError` | `src/WalmartApIs/Errors/GetShippingEstimateError.cs` |
| `V3ShippingLabelsShippingEstimates400Error1` | `src/WalmartApIs/Models/V3ShippingLabelsShippingEstimates400Error1.cs` |

### ScanForm

- **Auth**: `options.AccessToken`
- **Signature**: `ScanForm(ScanFormRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Accept`, `Body`
- **Returns**: `V3ShippingScanFormResponse`
- **Error**: `ApiException<ScanFormError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 409] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ScanFormRequest` | `src/WalmartApIs/Requests/ShipWithWalmart/ScanFormRequest.cs` |
| `WmMarket` | `src/WalmartApIs/Models/Enums/WmMarket.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3ShippingScanFormRequest` | `src/WalmartApIs/Models/V3ShippingScanFormRequest.cs` |
| `V3ShippingScanFormResponse` | `src/WalmartApIs/Models/V3ShippingScanFormResponse.cs` |
| `ScanFormError` | `src/WalmartApIs/Errors/ScanFormError.cs` |

