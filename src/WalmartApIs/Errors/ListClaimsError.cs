using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class ListClaimsError : ApiError
{
    private readonly Optional<V3ClaimsShipmentProtection400Error1> _v3ClaimsShipmentProtection400Error1Value;

    private readonly Optional<V3ClaimsShipmentProtection401Error1> _v3ClaimsShipmentProtection401Error1Value;

    private readonly Optional<V3ClaimsShipmentProtection500Error1> _v3ClaimsShipmentProtection500Error1Value;

    private ListClaimsError(Optional<V3ClaimsShipmentProtection400Error1> v3ClaimsShipmentProtection400Error1Value,
        Optional<V3ClaimsShipmentProtection401Error1> v3ClaimsShipmentProtection401Error1Value,
        Optional<V3ClaimsShipmentProtection500Error1> v3ClaimsShipmentProtection500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3ClaimsShipmentProtection400Error1Value = v3ClaimsShipmentProtection400Error1Value;
        _v3ClaimsShipmentProtection401Error1Value = v3ClaimsShipmentProtection401Error1Value;
        _v3ClaimsShipmentProtection500Error1Value = v3ClaimsShipmentProtection500Error1Value;
    }

    private static ListClaimsError AsV3ClaimsShipmentProtection400Error1(V3ClaimsShipmentProtection400Error1 value) =>
        new(Optional<V3ClaimsShipmentProtection400Error1>.Some(value), default, default, default);

    private static ListClaimsError AsV3ClaimsShipmentProtection401Error1(V3ClaimsShipmentProtection401Error1 value) =>
        new(default, Optional<V3ClaimsShipmentProtection401Error1>.Some(value), default, default);

    private static ListClaimsError AsV3ClaimsShipmentProtection500Error1(V3ClaimsShipmentProtection500Error1 value) =>
        new(default, default, Optional<V3ClaimsShipmentProtection500Error1>.Some(value), default);

    private static ListClaimsError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3ClaimsShipmentProtection400Error1(out V3ClaimsShipmentProtection400Error1 value) =>
        _v3ClaimsShipmentProtection400Error1Value.TryGetValue(out value);

    public bool TryGetV3ClaimsShipmentProtection401Error1(out V3ClaimsShipmentProtection401Error1 value) =>
        _v3ClaimsShipmentProtection401Error1Value.TryGetValue(out value);

    public bool TryGetV3ClaimsShipmentProtection500Error1(out V3ClaimsShipmentProtection500Error1 value) =>
        _v3ClaimsShipmentProtection500Error1Value.TryGetValue(out value);

    private static Task<ListClaimsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3ClaimsShipmentProtection400Error1>().As(AsV3ClaimsShipmentProtection400Error1),
            401 => response.Json<V3ClaimsShipmentProtection401Error1>().As(AsV3ClaimsShipmentProtection401Error1),
            500 => response.Json<V3ClaimsShipmentProtection500Error1>().As(AsV3ClaimsShipmentProtection500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ListClaimsError> Response { get; } = new(Create);
}
