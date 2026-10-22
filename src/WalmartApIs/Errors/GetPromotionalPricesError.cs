using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetPromotionalPricesError : ApiError
{
    private readonly Optional<V3Token500Error1> _v3Token500Error1Value;

    private GetPromotionalPricesError(Optional<V3Token500Error1> v3Token500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3Token500Error1Value = v3Token500Error1Value;
    }

    private static GetPromotionalPricesError AsV3Token500Error1(V3Token500Error1 value) =>
        new(Optional<V3Token500Error1>.Some(value), default);

    private static GetPromotionalPricesError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetV3Token500Error1(out V3Token500Error1 value) => _v3Token500Error1Value.TryGetValue(out value);

    private static Task<GetPromotionalPricesError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            401 => response.Json<V3Token500Error1>().As(AsV3Token500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetPromotionalPricesError> Response { get; } = new(Create);
}
