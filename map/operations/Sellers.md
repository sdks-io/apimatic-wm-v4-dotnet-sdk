<!-- Generated file — do not edit; regenerated with the SDK. -->

# Sellers — operations

Accessor: `client.Sellers` · Source: `Api/Sellers.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetAccount

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetAccount(RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `SellerAccount`
- **Error**: `SdkException<GetAccountError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SellerAccount` | `Models/SellerAccount.cs` |
| `GetAccountError` | `Errors/GetAccountError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetMarketplaceParticipations

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetMarketplaceParticipations(RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetMarketplaceParticipationsResponse`
- **Error**: `SdkException<GetMarketplaceParticipationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetMarketplaceParticipationsResponse` | `Models/GetMarketplaceParticipationsResponse.cs` |
| `GetMarketplaceParticipationsError` | `Errors/GetMarketplaceParticipationsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

