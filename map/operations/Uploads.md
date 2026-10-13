<!-- Generated file — do not edit; regenerated with the SDK. -->

# Uploads — operations

Accessor: `client.Uploads` · Source: `src/WalmartApIs/Api/Uploads.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateUploadDestinationForResource

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateUploadDestinationForResource(CreateUploadDestinationForResourceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Resource`, `ContentType`, `MarketplaceIds`, `ContentMd5`
- **Query params (wire ← C#)**: `contentType` ← `ContentType`, `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `CreateUploadDestinationResponse`
- **Error**: `ApiException<CreateUploadDestinationForResourceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateUploadDestinationForResourceRequest` | `src/WalmartApIs/Requests/Uploads/CreateUploadDestinationForResourceRequest.cs` |
| `Resource` | `src/WalmartApIs/Models/Enums/Resource.cs` |
| `ContentType1` | `src/WalmartApIs/Models/Enums/ContentType1.cs` |
| `CreateUploadDestinationResponse` | `src/WalmartApIs/Models/CreateUploadDestinationResponse.cs` |
| `CreateUploadDestinationForResourceError` | `src/WalmartApIs/Errors/CreateUploadDestinationForResourceError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

