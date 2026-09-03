using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class ListSettlementPeriodsError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private ListSettlementPeriodsError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static ListSettlementPeriodsError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static ListSettlementPeriodsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<ListSettlementPeriodsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListSettlementPeriodsErrorResponse : IErrorResponse<ListSettlementPeriodsError>
{
    public static ListSettlementPeriodsErrorResponse Instance { get; } = new();

    private ListSettlementPeriodsErrorResponse()
    {
    }

    public Task<ListSettlementPeriodsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListSettlementPeriodsError.Create(response, ct);
}
