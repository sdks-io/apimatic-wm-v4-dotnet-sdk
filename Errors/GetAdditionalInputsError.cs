using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetAdditionalInputsError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetAdditionalInputsError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetAdditionalInputsError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetAdditionalInputsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetAdditionalInputsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetAdditionalInputsErrorResponse : IErrorResponse<GetAdditionalInputsError>
{
    public static GetAdditionalInputsErrorResponse Instance { get; } = new();

    private GetAdditionalInputsErrorResponse()
    {
    }

    public Task<GetAdditionalInputsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetAdditionalInputsError.Create(response, ct);
}
