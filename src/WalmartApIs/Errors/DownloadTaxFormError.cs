using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class DownloadTaxFormError : ApiError
{
    private readonly Optional<V1SettingsDownloadtaxformprofile502Error1> _v1SettingsDownloadtaxformprofile502Error1Value;

    private readonly Optional<V1SettingsDownloadtaxformprofile404Error1> _v1SettingsDownloadtaxformprofile404Error1Value;

    private readonly Optional<V1SettingsDownloadtaxformprofile400Error1> _v1SettingsDownloadtaxformprofile400Error1Value;

    private readonly Optional<V1SettingsDownloadtaxformprofile500Error1> _v1SettingsDownloadtaxformprofile500Error1Value;

    private DownloadTaxFormError(Optional<V1SettingsDownloadtaxformprofile502Error1> v1SettingsDownloadtaxformprofile502Error1Value,
        Optional<V1SettingsDownloadtaxformprofile404Error1> v1SettingsDownloadtaxformprofile404Error1Value,
        Optional<V1SettingsDownloadtaxformprofile400Error1> v1SettingsDownloadtaxformprofile400Error1Value,
        Optional<V1SettingsDownloadtaxformprofile500Error1> v1SettingsDownloadtaxformprofile500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v1SettingsDownloadtaxformprofile502Error1Value = v1SettingsDownloadtaxformprofile502Error1Value;
        _v1SettingsDownloadtaxformprofile404Error1Value = v1SettingsDownloadtaxformprofile404Error1Value;
        _v1SettingsDownloadtaxformprofile400Error1Value = v1SettingsDownloadtaxformprofile400Error1Value;
        _v1SettingsDownloadtaxformprofile500Error1Value = v1SettingsDownloadtaxformprofile500Error1Value;
    }

    private static DownloadTaxFormError AsV1SettingsDownloadtaxformprofile502Error1(V1SettingsDownloadtaxformprofile502Error1 value) =>
        new(Optional<V1SettingsDownloadtaxformprofile502Error1>.Some(value), default, default, default, default);

    private static DownloadTaxFormError AsV1SettingsDownloadtaxformprofile404Error1(V1SettingsDownloadtaxformprofile404Error1 value) =>
        new(default, Optional<V1SettingsDownloadtaxformprofile404Error1>.Some(value), default, default, default);

    private static DownloadTaxFormError AsV1SettingsDownloadtaxformprofile400Error1(V1SettingsDownloadtaxformprofile400Error1 value) =>
        new(default, default, Optional<V1SettingsDownloadtaxformprofile400Error1>.Some(value), default, default);

    private static DownloadTaxFormError AsV1SettingsDownloadtaxformprofile500Error1(V1SettingsDownloadtaxformprofile500Error1 value) =>
        new(default, default, default, Optional<V1SettingsDownloadtaxformprofile500Error1>.Some(value), default);

    private static DownloadTaxFormError AsFallback(RawError value) =>
        new(default, default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV1SettingsDownloadtaxformprofile502Error1(out V1SettingsDownloadtaxformprofile502Error1 value) =>
        _v1SettingsDownloadtaxformprofile502Error1Value.TryGetValue(out value);

    public bool TryGetV1SettingsDownloadtaxformprofile404Error1(out V1SettingsDownloadtaxformprofile404Error1 value) =>
        _v1SettingsDownloadtaxformprofile404Error1Value.TryGetValue(out value);

    public bool TryGetV1SettingsDownloadtaxformprofile400Error1(out V1SettingsDownloadtaxformprofile400Error1 value) =>
        _v1SettingsDownloadtaxformprofile400Error1Value.TryGetValue(out value);

    public bool TryGetV1SettingsDownloadtaxformprofile500Error1(out V1SettingsDownloadtaxformprofile500Error1 value) =>
        _v1SettingsDownloadtaxformprofile500Error1Value.TryGetValue(out value);

    private static Task<DownloadTaxFormError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V1SettingsDownloadtaxformprofile400Error1>().As(
                AsV1SettingsDownloadtaxformprofile400Error1),
            404 => response.Json<V1SettingsDownloadtaxformprofile404Error1>().As(
                AsV1SettingsDownloadtaxformprofile404Error1),
            500 => response.Json<V1SettingsDownloadtaxformprofile500Error1>().As(
                AsV1SettingsDownloadtaxformprofile500Error1),
            502 => response.Json<V1SettingsDownloadtaxformprofile502Error1>().As(
                AsV1SettingsDownloadtaxformprofile502Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<DownloadTaxFormError> Response { get; } = new(Create);
}
