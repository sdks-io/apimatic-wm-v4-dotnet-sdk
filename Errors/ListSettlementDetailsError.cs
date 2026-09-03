using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class ListSettlementDetailsError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private ListSettlementDetailsError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static ListSettlementDetailsError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static ListSettlementDetailsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<ListSettlementDetailsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 403 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListSettlementDetailsErrorResponse : IErrorResponse<ListSettlementDetailsError>
{
    public static ListSettlementDetailsErrorResponse Instance { get; } = new();

    private ListSettlementDetailsErrorResponse()
    {
    }

    public Task<ListSettlementDetailsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListSettlementDetailsError.Create(response, ct);
}
