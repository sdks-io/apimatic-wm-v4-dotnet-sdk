using System.Collections.Generic;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetCompetitiveSummaryError : ApiError
{
    private readonly Optional<IReadOnlyList<Error3>> _listOfError3Value;

    private GetCompetitiveSummaryError(Optional<IReadOnlyList<Error3>> listOfError3Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _listOfError3Value = listOfError3Value;
    }

    private static GetCompetitiveSummaryError AsListOfError3(IReadOnlyList<Error3> value) =>
        new(Optional<IReadOnlyList<Error3>>.Some(value), default);

    private static GetCompetitiveSummaryError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetListOfError3(out IReadOnlyList<Error3> value) => _listOfError3Value.TryGetValue(out value);

    private static Task<GetCompetitiveSummaryError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => response.Json<IReadOnlyList<Error3>>().As(AsListOfError3),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetCompetitiveSummaryError> Response { get; } = new(Create);
}
