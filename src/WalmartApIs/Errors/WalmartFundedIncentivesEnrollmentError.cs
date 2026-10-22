using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class WalmartFundedIncentivesEnrollmentError : ApiError
{
    private readonly Optional<V3Token400Error1> _v3Token400Error1Value;

    private WalmartFundedIncentivesEnrollmentError(Optional<V3Token400Error1> v3Token400Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3Token400Error1Value = v3Token400Error1Value;
    }

    private static WalmartFundedIncentivesEnrollmentError AsV3Token400Error1(V3Token400Error1 value) =>
        new(Optional<V3Token400Error1>.Some(value), default);

    private static WalmartFundedIncentivesEnrollmentError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetV3Token400Error1(out V3Token400Error1 value) => _v3Token400Error1Value.TryGetValue(out value);

    private static Task<WalmartFundedIncentivesEnrollmentError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            403 or 500 => response.Json<V3Token400Error1>().As(AsV3Token400Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<WalmartFundedIncentivesEnrollmentError> Response { get; } = new(Create);
}
