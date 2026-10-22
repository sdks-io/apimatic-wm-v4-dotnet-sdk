using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetEligibleItemsError : ApiError
{
    private readonly Optional<SemErrorResponse400> _semErrorResponse400Value;

    private GetEligibleItemsError(Optional<SemErrorResponse400> semErrorResponse400Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _semErrorResponse400Value = semErrorResponse400Value;
    }

    private static GetEligibleItemsError AsSemErrorResponse400(SemErrorResponse400 value) =>
        new(Optional<SemErrorResponse400>.Some(value), default);

    private static GetEligibleItemsError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetSemErrorResponse400(out SemErrorResponse400 value) =>
        _semErrorResponse400Value.TryGetValue(out value);

    private static Task<GetEligibleItemsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 500 => response.Json<SemErrorResponse400>().As(AsSemErrorResponse400),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetEligibleItemsError> Response { get; } = new(Create);
}
