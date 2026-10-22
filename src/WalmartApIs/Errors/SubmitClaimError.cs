using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class SubmitClaimError : ApiError
{
    private readonly Optional<V3ClaimsShipmentProtectionClaim400Error1> _v3ClaimsShipmentProtectionClaim400Error1Value;

    private readonly Optional<V3ClaimsShipmentProtectionClaim401Error1> _v3ClaimsShipmentProtectionClaim401Error1Value;

    private readonly Optional<V3ClaimsShipmentProtectionClaim500Error1> _v3ClaimsShipmentProtectionClaim500Error1Value;

    private SubmitClaimError(Optional<V3ClaimsShipmentProtectionClaim400Error1> v3ClaimsShipmentProtectionClaim400Error1Value,
        Optional<V3ClaimsShipmentProtectionClaim401Error1> v3ClaimsShipmentProtectionClaim401Error1Value,
        Optional<V3ClaimsShipmentProtectionClaim500Error1> v3ClaimsShipmentProtectionClaim500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3ClaimsShipmentProtectionClaim400Error1Value = v3ClaimsShipmentProtectionClaim400Error1Value;
        _v3ClaimsShipmentProtectionClaim401Error1Value = v3ClaimsShipmentProtectionClaim401Error1Value;
        _v3ClaimsShipmentProtectionClaim500Error1Value = v3ClaimsShipmentProtectionClaim500Error1Value;
    }

    private static SubmitClaimError AsV3ClaimsShipmentProtectionClaim400Error1(V3ClaimsShipmentProtectionClaim400Error1 value) =>
        new(Optional<V3ClaimsShipmentProtectionClaim400Error1>.Some(value), default, default, default);

    private static SubmitClaimError AsV3ClaimsShipmentProtectionClaim401Error1(V3ClaimsShipmentProtectionClaim401Error1 value) =>
        new(default, Optional<V3ClaimsShipmentProtectionClaim401Error1>.Some(value), default, default);

    private static SubmitClaimError AsV3ClaimsShipmentProtectionClaim500Error1(V3ClaimsShipmentProtectionClaim500Error1 value) =>
        new(default, default, Optional<V3ClaimsShipmentProtectionClaim500Error1>.Some(value), default);

    private static SubmitClaimError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3ClaimsShipmentProtectionClaim400Error1(out V3ClaimsShipmentProtectionClaim400Error1 value) =>
        _v3ClaimsShipmentProtectionClaim400Error1Value.TryGetValue(out value);

    public bool TryGetV3ClaimsShipmentProtectionClaim401Error1(out V3ClaimsShipmentProtectionClaim401Error1 value) =>
        _v3ClaimsShipmentProtectionClaim401Error1Value.TryGetValue(out value);

    public bool TryGetV3ClaimsShipmentProtectionClaim500Error1(out V3ClaimsShipmentProtectionClaim500Error1 value) =>
        _v3ClaimsShipmentProtectionClaim500Error1Value.TryGetValue(out value);

    private static Task<SubmitClaimError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3ClaimsShipmentProtectionClaim400Error1>().As(
                AsV3ClaimsShipmentProtectionClaim400Error1),
            401 => response.Json<V3ClaimsShipmentProtectionClaim401Error1>().As(
                AsV3ClaimsShipmentProtectionClaim401Error1),
            500 => response.Json<V3ClaimsShipmentProtectionClaim500Error1>().As(
                AsV3ClaimsShipmentProtectionClaim500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<SubmitClaimError> Response { get; } = new(Create);
}
