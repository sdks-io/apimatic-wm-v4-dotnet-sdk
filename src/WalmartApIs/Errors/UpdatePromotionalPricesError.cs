using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class UpdatePromotionalPricesError : ApiError
{
    private readonly Optional<V3Token500Error1> _v3Token500Error1Value;

    private UpdatePromotionalPricesError(Optional<V3Token500Error1> v3Token500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3Token500Error1Value = v3Token500Error1Value;
    }

    private static UpdatePromotionalPricesError AsV3Token500Error1(V3Token500Error1 value) =>
        new(Optional<V3Token500Error1>.Some(value), default);

    private static UpdatePromotionalPricesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetV3Token500Error1(out V3Token500Error1 value) => _v3Token500Error1Value.TryGetValue(out value);

    private static Task<UpdatePromotionalPricesError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            403 or 500 => response.Json<V3Token500Error1>().As(AsV3Token500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<UpdatePromotionalPricesError> Response { get; } = new(Create);
}
