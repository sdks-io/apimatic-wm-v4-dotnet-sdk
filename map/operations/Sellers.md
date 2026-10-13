<!-- Generated file — do not edit; regenerated with the SDK. -->

# Sellers — operations

Accessor: `client.Sellers` · Source: `src/WalmartApIs/Api/Sellers.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetAccount

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetAccount(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `SellerAccount`
- **Error**: `ApiException<GetAccountError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SellerAccount` | `src/WalmartApIs/Models/SellerAccount.cs` |
| `GetAccountError` | `src/WalmartApIs/Errors/GetAccountError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetMarketplaceParticipations

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetMarketplaceParticipations(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `GetMarketplaceParticipationsResponse`
- **Error**: `ApiException<GetMarketplaceParticipationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetMarketplaceParticipationsResponse` | `src/WalmartApIs/Models/GetMarketplaceParticipationsResponse.cs` |
| `GetMarketplaceParticipationsError` | `src/WalmartApIs/Errors/GetMarketplaceParticipationsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

