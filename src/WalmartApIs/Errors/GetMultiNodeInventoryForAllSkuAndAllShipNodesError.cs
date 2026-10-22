using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetMultiNodeInventoryForAllSkuAndAllShipNodesError : ApiError
{
    private readonly Optional<V3Inventories403Error1> _v3Inventories403Error1Value;

    private GetMultiNodeInventoryForAllSkuAndAllShipNodesError(Optional<V3Inventories403Error1> v3Inventories403Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3Inventories403Error1Value = v3Inventories403Error1Value;
    }

    private static GetMultiNodeInventoryForAllSkuAndAllShipNodesError AsV3Inventories403Error1(V3Inventories403Error1 value) =>
        new(Optional<V3Inventories403Error1>.Some(value), default);

    private static GetMultiNodeInventoryForAllSkuAndAllShipNodesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetV3Inventories403Error1(out V3Inventories403Error1 value) =>
        _v3Inventories403Error1Value.TryGetValue(out value);

    private static Task<GetMultiNodeInventoryForAllSkuAndAllShipNodesError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            403 => response.Json<V3Inventories403Error1>().As(AsV3Inventories403Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetMultiNodeInventoryForAllSkuAndAllShipNodesError> Response { get; } = new(
        Create);
}
