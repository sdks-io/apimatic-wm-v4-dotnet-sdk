using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class UpdateWalmartFundedIncentivesEnrollmentStatusError : ApiError
{
    private readonly Optional<V3Token400Error1> _v3Token400Error1Value;

    private UpdateWalmartFundedIncentivesEnrollmentStatusError(Optional<V3Token400Error1> v3Token400Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3Token400Error1Value = v3Token400Error1Value;
    }

    private static UpdateWalmartFundedIncentivesEnrollmentStatusError AsV3Token400Error1(V3Token400Error1 value) =>
        new(Optional<V3Token400Error1>.Some(value), default);

    private static UpdateWalmartFundedIncentivesEnrollmentStatusError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetV3Token400Error1(out V3Token400Error1 value) => _v3Token400Error1Value.TryGetValue(out value);

    private static Task<UpdateWalmartFundedIncentivesEnrollmentStatusError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            403 or 500 => response.Json<V3Token400Error1>().As(AsV3Token400Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<UpdateWalmartFundedIncentivesEnrollmentStatusError> Response { get; } = new(
        Create);
}
