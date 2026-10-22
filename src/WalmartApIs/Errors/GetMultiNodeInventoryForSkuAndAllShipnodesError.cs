using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetMultiNodeInventoryForSkuAndAllShipnodesError : ApiError
{
    private readonly Optional<InventoriesDto> _inventoriesDtoValue;

    private GetMultiNodeInventoryForSkuAndAllShipnodesError(Optional<InventoriesDto> inventoriesDtoValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _inventoriesDtoValue = inventoriesDtoValue;
    }

    private static GetMultiNodeInventoryForSkuAndAllShipnodesError AsInventoriesDto(InventoriesDto value) =>
        new(Optional<InventoriesDto>.Some(value), default);

    private static GetMultiNodeInventoryForSkuAndAllShipnodesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetInventoriesDto(out InventoriesDto value) => _inventoriesDtoValue.TryGetValue(out value);

    private static Task<GetMultiNodeInventoryForSkuAndAllShipnodesError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 404 => response.Json<InventoriesDto>().As(AsInventoriesDto),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetMultiNodeInventoryForSkuAndAllShipnodesError> Response { get; } = new(Create);
}
