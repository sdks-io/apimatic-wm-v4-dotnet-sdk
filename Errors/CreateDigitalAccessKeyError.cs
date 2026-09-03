using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CreateDigitalAccessKeyError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private CreateDigitalAccessKeyError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static CreateDigitalAccessKeyError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static CreateDigitalAccessKeyError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<CreateDigitalAccessKeyError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateDigitalAccessKeyErrorResponse : IErrorResponse<CreateDigitalAccessKeyError>
{
    public static CreateDigitalAccessKeyErrorResponse Instance { get; } = new();

    private CreateDigitalAccessKeyErrorResponse()
    {
    }

    public Task<CreateDigitalAccessKeyError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateDigitalAccessKeyError.Create(response, ct);
}
