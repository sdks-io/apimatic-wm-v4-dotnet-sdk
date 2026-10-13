<!-- Generated file — do not edit; regenerated with the SDK. -->

# ListingsRestrictions — operations

Accessor: `client.ListingsRestrictions` · Source: `src/WalmartApIs/Api/ListingsRestrictions.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetListingsRestrictions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetListingsRestrictions(GetListingsRestrictionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Asin`, `ConditionType`, `SellerId`, `MarketplaceIds`
- **Query params (wire ← C#)**: `asin` ← `Asin`, `conditionType` ← `ConditionType`, `sellerId` ← `SellerId`, `marketplaceIds` ← `MarketplaceIds`, `reasonLocale` ← `ReasonLocale`
- **Returns**: `RestrictionList`
- **Error**: `ApiException<GetListingsRestrictionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetListingsRestrictionsRequest` | `src/WalmartApIs/Requests/ListingsRestrictions/GetListingsRestrictionsRequest.cs` |
| `ConditionType1` | `src/WalmartApIs/Models/Enums/ConditionType1.cs` |
| `RestrictionList` | `src/WalmartApIs/Models/RestrictionList.cs` |
| `GetListingsRestrictionsError` | `src/WalmartApIs/Errors/GetListingsRestrictionsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

