<!-- Generated file — do not edit; regenerated with the SDK. -->

# ProductTypeDefinitions — operations

Accessor: `client.ProductTypeDefinitions` · Source: `Api/ProductTypeDefinitions.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetDefinitionsProductType

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetDefinitionsProductType(string productType, string? sellerId, string? locale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `sellerId` — nullable, no default → **must pass explicitly**
  - defaults: `locale` = `"en_US"`
- **Query params (wire ← C#)**: `sellerId` ← `sellerId`, `locale` ← `locale`
- **Returns**: `ProductTypeDefinition`
- **Error**: `SdkException<GetDefinitionsProductTypeError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ProductTypeDefinition` | `Models/ProductTypeDefinition.cs` |
| `GetDefinitionsProductTypeError` | `Errors/GetDefinitionsProductTypeError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### SearchDefinitionsProductTypes

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SearchDefinitionsProductTypes(string? keywords, string? itemName, string? locale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `keywords` — nullable, no default → **must pass explicitly**
  - `itemName` — nullable, no default → **must pass explicitly**
  - defaults: `locale` = `"en_US"`
- **Query params (wire ← C#)**: `keywords` ← `keywords`, `itemName` ← `itemName`, `locale` ← `locale`
- **Returns**: `ProductTypeList`
- **Error**: `SdkException<SearchDefinitionsProductTypesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ProductTypeList` | `Models/ProductTypeList.cs` |
| `SearchDefinitionsProductTypesError` | `Errors/SearchDefinitionsProductTypesError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

