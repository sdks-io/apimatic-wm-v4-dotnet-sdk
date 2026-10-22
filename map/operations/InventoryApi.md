<!-- Generated file — do not edit; regenerated with the SDK. -->

# InventoryApi — operations

Accessor: `client.InventoryApi` · Source: `src/WalmartApIs/Api/InventoryApi.cs` · 7 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetInventory

- **Auth**: `options.AccessToken`
- **Signature**: `GetInventory(GetInventoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Sku`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `sku` ← `Sku`, `shipNode` ← `ShipNode`
- **Returns**: `Inventory1`
- **Error**: `ApiException<GetInventoryError>` — **Case A (typed)**
- **Error accessors**: `TryGetInventory1(out Inventory1)` [400, 404] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetInventoryRequest` | `src/WalmartApIs/Requests/InventoryApi/GetInventoryRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `Inventory1` | `src/WalmartApIs/Models/Inventory1.cs` |
| `GetInventoryError` | `src/WalmartApIs/Errors/GetInventoryError.cs` |

### GetMultiNodeInventoryForAllSkuAndAllShipNodes

- **Auth**: `options.AccessToken`
- **Signature**: `GetMultiNodeInventoryForAllSkuAndAllShipNodes(GetMultiNodeInventoryForAllSkuAndAllShipNodesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `limit` ← `Limit`, `nextCursor` ← `NextCursor`
- **Returns**: `MultiNodeInventoryFetchResponseDto`
- **Error**: `ApiException<GetMultiNodeInventoryForAllSkuAndAllShipNodesError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Inventories403Error1(out V3Inventories403Error1)` [403] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetMultiNodeInventoryForAllSkuAndAllShipNodesRequest` | `src/WalmartApIs/Requests/InventoryApi/GetMultiNodeInventoryForAllSkuAndAllShipNodesRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `MultiNodeInventoryFetchResponseDto` | `src/WalmartApIs/Models/MultiNodeInventoryFetchResponseDto.cs` |
| `GetMultiNodeInventoryForAllSkuAndAllShipNodesError` | `src/WalmartApIs/Errors/GetMultiNodeInventoryForAllSkuAndAllShipNodesError.cs` |
| `V3Inventories403Error1` | `src/WalmartApIs/Models/V3Inventories403Error1.cs` |

### GetMultiNodeInventoryForSkuAndAllShipnodes

- **Auth**: `options.AccessToken`
- **Signature**: `GetMultiNodeInventoryForSkuAndAllShipnodes(GetMultiNodeInventoryForSkuAndAllShipnodesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Sku`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `shipNode` ← `ShipNode`
- **Returns**: `InventoriesDto`
- **Error**: `ApiException<GetMultiNodeInventoryForSkuAndAllShipnodesError>` — **Case A (typed)**
- **Error accessors**: `TryGetInventoriesDto(out InventoriesDto)` [400, 404] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetMultiNodeInventoryForSkuAndAllShipnodesRequest` | `src/WalmartApIs/Requests/InventoryApi/GetMultiNodeInventoryForSkuAndAllShipnodesRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `InventoriesDto` | `src/WalmartApIs/Models/InventoriesDto.cs` |
| `GetMultiNodeInventoryForSkuAndAllShipnodesError` | `src/WalmartApIs/Errors/GetMultiNodeInventoryForSkuAndAllShipnodesError.cs` |

### GetWfsInventory

- **Auth**: `options.AccessToken`
- **Signature**: `GetWfsInventory(GetWfsInventoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `sku` ← `Sku`, `fromModifiedDate` ← `FromModifiedDate`, `toModifiedDate` ← `ToModifiedDate`, `limit` ← `Limit`, `offset` ← `Offset`, `shipNodeType` ← `ShipNodeType`
- **Returns**: `V3FulfillmentInventoryResponse`
- **Error**: `ApiException<GetWfsInventoryError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3FulfillmentInventory403Error1(out V3FulfillmentInventory403Error1)` [403] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetWfsInventoryRequest` | `src/WalmartApIs/Requests/InventoryApi/GetWfsInventoryRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3FulfillmentInventoryResponse` | `src/WalmartApIs/Models/V3FulfillmentInventoryResponse.cs` |
| `GetWfsInventoryError` | `src/WalmartApIs/Errors/GetWfsInventoryError.cs` |
| `V3FulfillmentInventory403Error1` | `src/WalmartApIs/Models/V3FulfillmentInventory403Error1.cs` |

### UpdateBulkInventory

- **Auth**: `options.AccessToken`
- **Signature**: `UpdateBulkInventory(UpdateBulkInventoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeedType`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `File`
- **Query params (wire ← C#)**: `feedType` ← `FeedType`, `shipNode` ← `ShipNode`
- **Returns**: `FeedId`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `UpdateBulkInventoryRequest` | `src/WalmartApIs/Requests/InventoryApi/UpdateBulkInventoryRequest.cs` |
| `FeedType1` | `src/WalmartApIs/Models/Enums/FeedType1.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `FeedId` | `src/WalmartApIs/Models/FeedId.cs` |

### UpdateInventoryForAnItem

- **Auth**: `options.AccessToken`
- **Signature**: `UpdateInventoryForAnItem(UpdateInventoryForAnItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Sku`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Query params (wire ← C#)**: `sku` ← `Sku`, `shipNode` ← `ShipNode`
- **Returns**: `Inventory1`
- **Error**: `ApiException<UpdateInventoryForAnItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetInventory1(out Inventory1)` [400, 404] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateInventoryForAnItemRequest` | `src/WalmartApIs/Requests/InventoryApi/UpdateInventoryForAnItemRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3InventoryRequest` | `src/WalmartApIs/Models/V3InventoryRequest.cs` |
| `Inventory1` | `src/WalmartApIs/Models/Inventory1.cs` |
| `UpdateInventoryForAnItemError` | `src/WalmartApIs/Errors/UpdateInventoryForAnItemError.cs` |

### UpdateMultiNodeInventory

- **Auth**: `options.AccessToken`
- **Signature**: `UpdateMultiNodeInventory(UpdateMultiNodeInventoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Sku`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `MultiNodeInventoryUpdateResponseDto`
- **Error**: `ApiException<UpdateMultiNodeInventoryError>` — **Case A (typed)**
- **Error accessors**: `TryGetMultiNodeInventoryUpdateResponseDto(out MultiNodeInventoryUpdateResponseDto)` [400, 404] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateMultiNodeInventoryRequest` | `src/WalmartApIs/Requests/InventoryApi/UpdateMultiNodeInventoryRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3InventoriesRequest` | `src/WalmartApIs/Models/V3InventoriesRequest.cs` |
| `MultiNodeInventoryUpdateResponseDto` | `src/WalmartApIs/Models/MultiNodeInventoryUpdateResponseDto.cs` |
| `UpdateMultiNodeInventoryError` | `src/WalmartApIs/Errors/UpdateMultiNodeInventoryError.cs` |

