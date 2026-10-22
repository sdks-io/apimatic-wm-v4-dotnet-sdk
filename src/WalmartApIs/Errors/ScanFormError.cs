using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Errors;

public sealed class ScanFormError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private ScanFormError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static ScanFormError AsNoContent(RawError value) => new(Optional<RawError>.Some(value), default);

    private static ScanFormError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    private static Task<ScanFormError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 409 => response.RawBody().As(AsNoContent),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ScanFormError> Response { get; } = new(Create);
}
