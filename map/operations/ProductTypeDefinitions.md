<!-- Generated file — do not edit; regenerated with the SDK. -->

# ProductTypeDefinitions — operations

Accessor: `client.ProductTypeDefinitions` · Source: `src/WalmartApIs/Api/ProductTypeDefinitions.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetDefinitionsProductType

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetDefinitionsProductType(GetDefinitionsProductTypeRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductType`
- **Query params (wire ← C#)**: `sellerId` ← `SellerId`, `locale` ← `Locale`
- **Returns**: `ProductTypeDefinition`
- **Error**: `ApiException<GetDefinitionsProductTypeError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetDefinitionsProductTypeRequest` | `src/WalmartApIs/Requests/ProductTypeDefinitions/GetDefinitionsProductTypeRequest.cs` |
| `ProductTypeDefinition` | `src/WalmartApIs/Models/ProductTypeDefinition.cs` |
| `GetDefinitionsProductTypeError` | `src/WalmartApIs/Errors/GetDefinitionsProductTypeError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### SearchDefinitionsProductTypes

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SearchDefinitionsProductTypes(SearchDefinitionsProductTypesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `keywords` ← `Keywords`, `itemName` ← `ItemName`, `locale` ← `Locale`
- **Returns**: `ProductTypeList`
- **Error**: `ApiException<SearchDefinitionsProductTypesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SearchDefinitionsProductTypesRequest` | `src/WalmartApIs/Requests/ProductTypeDefinitions/SearchDefinitionsProductTypesRequest.cs` |
| `ProductTypeList` | `src/WalmartApIs/Models/ProductTypeList.cs` |
| `SearchDefinitionsProductTypesError` | `src/WalmartApIs/Errors/SearchDefinitionsProductTypesError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

