<!-- Generated file — do not edit; regenerated with the SDK. -->

# Uploads — operations

Accessor: `client.Uploads` · Source: `Api/Uploads.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateUploadDestinationForResource

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateUploadDestinationForResource(Resource resource, ContentType1 contentType, IReadOnlyList<string> marketplaceIds, string contentMd5, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `contentType` ← `contentType`, `marketplaceIds` ← `marketplaceIds`
- **Returns**: `CreateUploadDestinationResponse`
- **Error**: `SdkException<CreateUploadDestinationForResourceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `Resource` | `Models/Enums/Resource.cs` |
| `ContentType1` | `Models/Enums/ContentType1.cs` |
| `CreateUploadDestinationResponse` | `Models/CreateUploadDestinationResponse.cs` |
| `CreateUploadDestinationForResourceError` | `Errors/CreateUploadDestinationForResourceError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

