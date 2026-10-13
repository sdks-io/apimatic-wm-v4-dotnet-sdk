<!-- Generated file — do not edit; regenerated with the SDK. -->

# Messaging — operations

Accessor: `client.Messaging` · Source: `src/WalmartApIs/Api/Messaging.cs` · 11 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ConfirmCustomizationDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfirmCustomizationDetails(ConfirmCustomizationDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SpApiOrderId`, `MarketplaceIds`, `Body`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `object`
- **Error**: `ApiException<ConfirmCustomizationDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ConfirmCustomizationDetailsRequest` | `src/WalmartApIs/Requests/Messaging/ConfirmCustomizationDetailsRequest.cs` |
| `ConfirmCustomizationDetailsError` | `src/WalmartApIs/Errors/ConfirmCustomizationDetailsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### CreateConfirmDeliveryDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateConfirmDeliveryDetails(CreateConfirmDeliveryDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SpApiOrderId`, `MarketplaceIds`, `Body`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `object`
- **Error**: `ApiException<CreateConfirmDeliveryDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateConfirmDeliveryDetailsRequest` | `src/WalmartApIs/Requests/Messaging/CreateConfirmDeliveryDetailsRequest.cs` |
| `CreateConfirmDeliveryDetailsError` | `src/WalmartApIs/Errors/CreateConfirmDeliveryDetailsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### CreateConfirmOrderDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateConfirmOrderDetails(CreateConfirmOrderDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SpApiOrderId`, `MarketplaceIds`, `Body`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `object`
- **Error**: `ApiException<CreateConfirmOrderDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateConfirmOrderDetailsRequest` | `src/WalmartApIs/Requests/Messaging/CreateConfirmOrderDetailsRequest.cs` |
| `CreateConfirmOrderDetailsError` | `src/WalmartApIs/Errors/CreateConfirmOrderDetailsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### CreateConfirmServiceDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateConfirmServiceDetails(CreateConfirmServiceDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SpApiOrderId`, `MarketplaceIds`, `Body`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `object`
- **Error**: `ApiException<CreateConfirmServiceDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateConfirmServiceDetailsRequest` | `src/WalmartApIs/Requests/Messaging/CreateConfirmServiceDetailsRequest.cs` |
| `CreateConfirmServiceDetailsError` | `src/WalmartApIs/Errors/CreateConfirmServiceDetailsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### CreateDigitalAccessKey

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateDigitalAccessKey(CreateDigitalAccessKeyRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SpApiOrderId`, `MarketplaceIds`, `Body`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `object`
- **Error**: `ApiException<CreateDigitalAccessKeyError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateDigitalAccessKeyRequest` | `src/WalmartApIs/Requests/Messaging/CreateDigitalAccessKeyRequest.cs` |
| `CreateDigitalAccessKeyError` | `src/WalmartApIs/Errors/CreateDigitalAccessKeyError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### CreateLegalDisclosure

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateLegalDisclosure(CreateLegalDisclosureRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SpApiOrderId`, `MarketplaceIds`, `Body`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `object`
- **Error**: `ApiException<CreateLegalDisclosureError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateLegalDisclosureRequest` | `src/WalmartApIs/Requests/Messaging/CreateLegalDisclosureRequest.cs` |
| `CreateLegalDisclosureError` | `src/WalmartApIs/Errors/CreateLegalDisclosureError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### CreateUnexpectedProblem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateUnexpectedProblem(CreateUnexpectedProblemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SpApiOrderId`, `MarketplaceIds`, `Body`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `object`
- **Error**: `ApiException<CreateUnexpectedProblemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateUnexpectedProblemRequest` | `src/WalmartApIs/Requests/Messaging/CreateUnexpectedProblemRequest.cs` |
| `CreateUnexpectedProblemError` | `src/WalmartApIs/Errors/CreateUnexpectedProblemError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### CreateWarranty

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateWarranty(CreateWarrantyRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SpApiOrderId`, `MarketplaceIds`, `Body`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `object`
- **Error**: `ApiException<CreateWarrantyError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateWarrantyRequest` | `src/WalmartApIs/Requests/Messaging/CreateWarrantyRequest.cs` |
| `CreateWarrantyError` | `src/WalmartApIs/Errors/CreateWarrantyError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetAttributes

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetAttributes(GetAttributesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SpApiOrderId`, `MarketplaceIds`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `object`
- **Error**: `ApiException<GetAttributesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetAttributesRequest` | `src/WalmartApIs/Requests/Messaging/GetAttributesRequest.cs` |
| `GetAttributesError` | `src/WalmartApIs/Errors/GetAttributesError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetMessagingActionsForOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetMessagingActionsForOrder(GetMessagingActionsForOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SpApiOrderId`, `MarketplaceIds`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `object`
- **Error**: `ApiException<GetMessagingActionsForOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetMessagingActionsForOrderRequest` | `src/WalmartApIs/Requests/Messaging/GetMessagingActionsForOrderRequest.cs` |
| `GetMessagingActionsForOrderError` | `src/WalmartApIs/Errors/GetMessagingActionsForOrderError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### SendInvoice

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SendInvoice(SendInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SpApiOrderId`, `MarketplaceIds`, `Body`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `object`
- **Error**: `ApiException<SendInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SendInvoiceRequest` | `src/WalmartApIs/Requests/Messaging/SendInvoiceRequest.cs` |
| `SendInvoiceError` | `src/WalmartApIs/Errors/SendInvoiceError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

