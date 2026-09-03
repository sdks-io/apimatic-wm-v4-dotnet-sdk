using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CreateLegalDisclosureError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private CreateLegalDisclosureError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static CreateLegalDisclosureError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static CreateLegalDisclosureError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<CreateLegalDisclosureError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateLegalDisclosureErrorResponse : IErrorResponse<CreateLegalDisclosureError>
{
    public static CreateLegalDisclosureErrorResponse Instance { get; } = new();

    private CreateLegalDisclosureErrorResponse()
    {
    }

    public Task<CreateLegalDisclosureError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateLegalDisclosureError.Create(response, ct);
}
