using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetInventoryError : ApiError
{
    private readonly Optional<Inventory1> _inventory1Value;

    private GetInventoryError(Optional<Inventory1> inventory1Value, Optional<RawError> fallback) : base(fallback)
    {
        _inventory1Value = inventory1Value;
    }

    private static GetInventoryError AsInventory1(Inventory1 value) => new(Optional<Inventory1>.Some(value), default);

    private static GetInventoryError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetInventory1(out Inventory1 value) => _inventory1Value.TryGetValue(out value);

    private static Task<GetInventoryError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 404 => response.Json<Inventory1>().As(AsInventory1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetInventoryError> Response { get; } = new(Create);
}
