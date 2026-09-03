using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class ListReconciliationDatesError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private ListReconciliationDatesError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static ListReconciliationDatesError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static ListReconciliationDatesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<ListReconciliationDatesError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListReconciliationDatesErrorResponse : IErrorResponse<ListReconciliationDatesError>
{
    public static ListReconciliationDatesErrorResponse Instance { get; } = new();

    private ListReconciliationDatesErrorResponse()
    {
    }

    public Task<ListReconciliationDatesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListReconciliationDatesError.Create(response, ct);
}
