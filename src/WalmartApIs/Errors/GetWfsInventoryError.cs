using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetWfsInventoryError : ApiError
{
    private readonly Optional<V3FulfillmentInventory403Error1> _v3FulfillmentInventory403Error1Value;

    private GetWfsInventoryError(Optional<V3FulfillmentInventory403Error1> v3FulfillmentInventory403Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3FulfillmentInventory403Error1Value = v3FulfillmentInventory403Error1Value;
    }

    private static GetWfsInventoryError AsV3FulfillmentInventory403Error1(V3FulfillmentInventory403Error1 value) =>
        new(Optional<V3FulfillmentInventory403Error1>.Some(value), default);

    private static GetWfsInventoryError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetV3FulfillmentInventory403Error1(out V3FulfillmentInventory403Error1 value) =>
        _v3FulfillmentInventory403Error1Value.TryGetValue(out value);

    private static Task<GetWfsInventoryError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            403 => response.Json<V3FulfillmentInventory403Error1>().As(AsV3FulfillmentInventory403Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetWfsInventoryError> Response { get; } = new(Create);
}
