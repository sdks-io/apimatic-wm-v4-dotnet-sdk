using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class ListPackingGroupItemsError : ApiError
{
    private readonly Optional<CommonErrorList> _commonErrorListValue;

    private ListPackingGroupItemsError(Optional<CommonErrorList> commonErrorListValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _commonErrorListValue = commonErrorListValue;
    }

    private static ListPackingGroupItemsError AsCommonErrorList(CommonErrorList value) =>
        new(Optional<CommonErrorList>.Some(value), default);

    private static ListPackingGroupItemsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetCommonErrorList(out CommonErrorList value) => _commonErrorListValue.TryGetValue(out value);

    private static Task<ListPackingGroupItemsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => response.Json<CommonErrorList>().As(AsCommonErrorList),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ListPackingGroupItemsError> Response { get; } = new(Create);
}
