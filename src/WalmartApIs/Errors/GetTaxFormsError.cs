using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetTaxFormsError : ApiError
{
    private readonly Optional<V1SettingsGettaxformprofile404Error1> _v1SettingsGettaxformprofile404Error1Value;

    private readonly Optional<V1SettingsGettaxformprofile400Error1> _v1SettingsGettaxformprofile400Error1Value;

    private readonly Optional<V1SettingsGettaxformprofile500Error1> _v1SettingsGettaxformprofile500Error1Value;

    private GetTaxFormsError(Optional<V1SettingsGettaxformprofile404Error1> v1SettingsGettaxformprofile404Error1Value,
        Optional<V1SettingsGettaxformprofile400Error1> v1SettingsGettaxformprofile400Error1Value,
        Optional<V1SettingsGettaxformprofile500Error1> v1SettingsGettaxformprofile500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v1SettingsGettaxformprofile404Error1Value = v1SettingsGettaxformprofile404Error1Value;
        _v1SettingsGettaxformprofile400Error1Value = v1SettingsGettaxformprofile400Error1Value;
        _v1SettingsGettaxformprofile500Error1Value = v1SettingsGettaxformprofile500Error1Value;
    }

    private static GetTaxFormsError AsV1SettingsGettaxformprofile404Error1(V1SettingsGettaxformprofile404Error1 value) =>
        new(Optional<V1SettingsGettaxformprofile404Error1>.Some(value), default, default, default);

    private static GetTaxFormsError AsV1SettingsGettaxformprofile400Error1(V1SettingsGettaxformprofile400Error1 value) =>
        new(default, Optional<V1SettingsGettaxformprofile400Error1>.Some(value), default, default);

    private static GetTaxFormsError AsV1SettingsGettaxformprofile500Error1(V1SettingsGettaxformprofile500Error1 value) =>
        new(default, default, Optional<V1SettingsGettaxformprofile500Error1>.Some(value), default);

    private static GetTaxFormsError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV1SettingsGettaxformprofile404Error1(out V1SettingsGettaxformprofile404Error1 value) =>
        _v1SettingsGettaxformprofile404Error1Value.TryGetValue(out value);

    public bool TryGetV1SettingsGettaxformprofile400Error1(out V1SettingsGettaxformprofile400Error1 value) =>
        _v1SettingsGettaxformprofile400Error1Value.TryGetValue(out value);

    public bool TryGetV1SettingsGettaxformprofile500Error1(out V1SettingsGettaxformprofile500Error1 value) =>
        _v1SettingsGettaxformprofile500Error1Value.TryGetValue(out value);

    private static Task<GetTaxFormsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V1SettingsGettaxformprofile400Error1>().As(AsV1SettingsGettaxformprofile400Error1),
            404 => response.Json<V1SettingsGettaxformprofile404Error1>().As(AsV1SettingsGettaxformprofile404Error1),
            500 => response.Json<V1SettingsGettaxformprofile500Error1>().As(AsV1SettingsGettaxformprofile500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetTaxFormsError> Response { get; } = new(Create);
}
