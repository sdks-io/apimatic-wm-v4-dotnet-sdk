<!-- Generated file — do not edit; regenerated with the SDK. -->

# ListingsRestrictions — operations

Accessor: `client.ListingsRestrictions` · Source: `Api/ListingsRestrictions.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetListingsRestrictions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetListingsRestrictions(string asin, ConditionType1 conditionType, string sellerId, IReadOnlyList<string> marketplaceIds, string? reasonLocale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `reasonLocale` = `"en_US"`
- **Query params (wire ← C#)**: `asin` ← `asin`, `conditionType` ← `conditionType`, `sellerId` ← `sellerId`, `marketplaceIds` ← `marketplaceIds`, `reasonLocale` ← `reasonLocale`
- **Returns**: `RestrictionList`
- **Error**: `SdkException<GetListingsRestrictionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ConditionType1` | `Models/Enums/ConditionType1.cs` |
| `RestrictionList` | `Models/RestrictionList.cs` |
| `GetListingsRestrictionsError` | `Errors/GetListingsRestrictionsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

