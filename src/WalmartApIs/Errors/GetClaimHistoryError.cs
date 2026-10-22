using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetClaimHistoryError : ApiError
{
    private readonly Optional<V3ClaimsShipmentProtectionClaimHistory400Error1> _v3ClaimsShipmentProtectionClaimHistory400Error1Value;

    private readonly Optional<V3ClaimsShipmentProtectionClaimHistory404Error1> _v3ClaimsShipmentProtectionClaimHistory404Error1Value;

    private readonly Optional<V3ClaimsShipmentProtectionClaimHistory500Error1> _v3ClaimsShipmentProtectionClaimHistory500Error1Value;

    private GetClaimHistoryError(Optional<V3ClaimsShipmentProtectionClaimHistory400Error1> v3ClaimsShipmentProtectionClaimHistory400Error1Value,
        Optional<V3ClaimsShipmentProtectionClaimHistory404Error1> v3ClaimsShipmentProtectionClaimHistory404Error1Value,
        Optional<V3ClaimsShipmentProtectionClaimHistory500Error1> v3ClaimsShipmentProtectionClaimHistory500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3ClaimsShipmentProtectionClaimHistory400Error1Value = v3ClaimsShipmentProtectionClaimHistory400Error1Value;
        _v3ClaimsShipmentProtectionClaimHistory404Error1Value = v3ClaimsShipmentProtectionClaimHistory404Error1Value;
        _v3ClaimsShipmentProtectionClaimHistory500Error1Value = v3ClaimsShipmentProtectionClaimHistory500Error1Value;
    }

    private static GetClaimHistoryError AsV3ClaimsShipmentProtectionClaimHistory400Error1(V3ClaimsShipmentProtectionClaimHistory400Error1 value) =>
        new(Optional<V3ClaimsShipmentProtectionClaimHistory400Error1>.Some(value), default, default, default);

    private static GetClaimHistoryError AsV3ClaimsShipmentProtectionClaimHistory404Error1(V3ClaimsShipmentProtectionClaimHistory404Error1 value) =>
        new(default, Optional<V3ClaimsShipmentProtectionClaimHistory404Error1>.Some(value), default, default);

    private static GetClaimHistoryError AsV3ClaimsShipmentProtectionClaimHistory500Error1(V3ClaimsShipmentProtectionClaimHistory500Error1 value) =>
        new(default, default, Optional<V3ClaimsShipmentProtectionClaimHistory500Error1>.Some(value), default);

    private static GetClaimHistoryError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3ClaimsShipmentProtectionClaimHistory400Error1(out V3ClaimsShipmentProtectionClaimHistory400Error1 value) =>
        _v3ClaimsShipmentProtectionClaimHistory400Error1Value.TryGetValue(out value);

    public bool TryGetV3ClaimsShipmentProtectionClaimHistory404Error1(out V3ClaimsShipmentProtectionClaimHistory404Error1 value) =>
        _v3ClaimsShipmentProtectionClaimHistory404Error1Value.TryGetValue(out value);

    public bool TryGetV3ClaimsShipmentProtectionClaimHistory500Error1(out V3ClaimsShipmentProtectionClaimHistory500Error1 value) =>
        _v3ClaimsShipmentProtectionClaimHistory500Error1Value.TryGetValue(out value);

    private static Task<GetClaimHistoryError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3ClaimsShipmentProtectionClaimHistory400Error1>().As(
                AsV3ClaimsShipmentProtectionClaimHistory400Error1),
            404 => response.Json<V3ClaimsShipmentProtectionClaimHistory404Error1>().As(
                AsV3ClaimsShipmentProtectionClaimHistory404Error1),
            500 => response.Json<V3ClaimsShipmentProtectionClaimHistory500Error1>().As(
                AsV3ClaimsShipmentProtectionClaimHistory500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetClaimHistoryError> Response { get; } = new(Create);
}
