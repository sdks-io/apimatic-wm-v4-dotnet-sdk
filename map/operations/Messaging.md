<!-- Generated file — do not edit; regenerated with the SDK. -->

# Messaging — operations

Accessor: `client.Messaging` · Source: `Api/Messaging.cs` · 11 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ConfirmCustomizationDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfirmCustomizationDetails(string spApiOrderId, IReadOnlyList<string> marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`
- **Returns**: `object`
- **Error**: `SdkException<ConfirmCustomizationDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ConfirmCustomizationDetailsError` | `Errors/ConfirmCustomizationDetailsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### CreateConfirmDeliveryDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateConfirmDeliveryDetails(string spApiOrderId, IReadOnlyList<string> marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`
- **Returns**: `object`
- **Error**: `SdkException<CreateConfirmDeliveryDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateConfirmDeliveryDetailsError` | `Errors/CreateConfirmDeliveryDetailsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### CreateConfirmOrderDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateConfirmOrderDetails(string spApiOrderId, IReadOnlyList<string> marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`
- **Returns**: `object`
- **Error**: `SdkException<CreateConfirmOrderDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateConfirmOrderDetailsError` | `Errors/CreateConfirmOrderDetailsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### CreateConfirmServiceDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateConfirmServiceDetails(string spApiOrderId, IReadOnlyList<string> marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`
- **Returns**: `object`
- **Error**: `SdkException<CreateConfirmServiceDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateConfirmServiceDetailsError` | `Errors/CreateConfirmServiceDetailsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### CreateDigitalAccessKey

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateDigitalAccessKey(string spApiOrderId, IReadOnlyList<string> marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`
- **Returns**: `object`
- **Error**: `SdkException<CreateDigitalAccessKeyError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateDigitalAccessKeyError` | `Errors/CreateDigitalAccessKeyError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### CreateLegalDisclosure

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateLegalDisclosure(string spApiOrderId, IReadOnlyList<string> marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`
- **Returns**: `object`
- **Error**: `SdkException<CreateLegalDisclosureError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateLegalDisclosureError` | `Errors/CreateLegalDisclosureError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### CreateUnexpectedProblem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateUnexpectedProblem(string spApiOrderId, IReadOnlyList<string> marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`
- **Returns**: `object`
- **Error**: `SdkException<CreateUnexpectedProblemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateUnexpectedProblemError` | `Errors/CreateUnexpectedProblemError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### CreateWarranty

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateWarranty(string spApiOrderId, IReadOnlyList<string> marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`
- **Returns**: `object`
- **Error**: `SdkException<CreateWarrantyError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateWarrantyError` | `Errors/CreateWarrantyError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetAttributes

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetAttributes(string spApiOrderId, IReadOnlyList<string> marketplaceIds, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`
- **Returns**: `object`
- **Error**: `SdkException<GetAttributesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetAttributesError` | `Errors/GetAttributesError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetMessagingActionsForOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetMessagingActionsForOrder(string spApiOrderId, IReadOnlyList<string> marketplaceIds, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`
- **Returns**: `object`
- **Error**: `SdkException<GetMessagingActionsForOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetMessagingActionsForOrderError` | `Errors/GetMessagingActionsForOrderError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### SendInvoice

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SendInvoice(string spApiOrderId, IReadOnlyList<string> marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`
- **Returns**: `object`
- **Error**: `SdkException<SendInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SendInvoiceError` | `Errors/SendInvoiceError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

