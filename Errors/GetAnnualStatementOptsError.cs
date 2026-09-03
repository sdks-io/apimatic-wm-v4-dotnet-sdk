using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetAnnualStatementOptsError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetAnnualStatementOptsError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetAnnualStatementOptsError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetAnnualStatementOptsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetAnnualStatementOptsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetAnnualStatementOptsErrorResponse : IErrorResponse<GetAnnualStatementOptsError>
{
    public static GetAnnualStatementOptsErrorResponse Instance { get; } = new();

    private GetAnnualStatementOptsErrorResponse()
    {
    }

    public Task<GetAnnualStatementOptsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetAnnualStatementOptsError.Create(response, ct);
}
