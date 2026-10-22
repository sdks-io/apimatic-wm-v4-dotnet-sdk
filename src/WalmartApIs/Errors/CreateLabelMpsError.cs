using System.Collections.Generic;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CreateLabelMpsError : ApiError
{
    private readonly Optional<IReadOnlyList<Error5>> _listOfError5Value;

    private readonly Optional<V3ShippingMultiPackageLabels500Error1> _v3ShippingMultiPackageLabels500Error1Value;

    private CreateLabelMpsError(Optional<IReadOnlyList<Error5>> listOfError5Value,
        Optional<V3ShippingMultiPackageLabels500Error1> v3ShippingMultiPackageLabels500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _listOfError5Value = listOfError5Value;
        _v3ShippingMultiPackageLabels500Error1Value = v3ShippingMultiPackageLabels500Error1Value;
    }

    private static CreateLabelMpsError AsListOfError5(IReadOnlyList<Error5> value) =>
        new(Optional<IReadOnlyList<Error5>>.Some(value), default, default);

    private static CreateLabelMpsError AsV3ShippingMultiPackageLabels500Error1(V3ShippingMultiPackageLabels500Error1 value) =>
        new(default, Optional<V3ShippingMultiPackageLabels500Error1>.Some(value), default);

    private static CreateLabelMpsError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetListOfError5(out IReadOnlyList<Error5> value) => _listOfError5Value.TryGetValue(out value);

    public bool TryGetV3ShippingMultiPackageLabels500Error1(out V3ShippingMultiPackageLabels500Error1 value) =>
        _v3ShippingMultiPackageLabels500Error1Value.TryGetValue(out value);

    private static Task<CreateLabelMpsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<IReadOnlyList<Error5>>().As(AsListOfError5),
            500 => response.Json<V3ShippingMultiPackageLabels500Error1>().As(AsV3ShippingMultiPackageLabels500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<CreateLabelMpsError> Response { get; } = new(Create);
}
