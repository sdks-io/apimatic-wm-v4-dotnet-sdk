using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CreateQueryError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private CreateQueryError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static CreateQueryError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static CreateQueryError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<CreateQueryError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateQueryErrorResponse : IErrorResponse<CreateQueryError>
{
    public static CreateQueryErrorResponse Instance { get; } = new();

    private CreateQueryErrorResponse()
    {
    }

    public Task<CreateQueryError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateQueryError.Create(response, ct);
}
