using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class UpdateInventoryForAnItemError : ApiError
{
    private readonly Optional<Inventory1> _inventory1Value;

    private UpdateInventoryForAnItemError(Optional<Inventory1> inventory1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _inventory1Value = inventory1Value;
    }

    private static UpdateInventoryForAnItemError AsInventory1(Inventory1 value) =>
        new(Optional<Inventory1>.Some(value), default);

    private static UpdateInventoryForAnItemError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetInventory1(out Inventory1 value) => _inventory1Value.TryGetValue(out value);

    private static Task<UpdateInventoryForAnItemError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 404 => response.Json<Inventory1>().As(AsInventory1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<UpdateInventoryForAnItemError> Response { get; } = new(Create);
}
