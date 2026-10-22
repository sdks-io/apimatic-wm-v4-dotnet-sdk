using System.Collections.Generic;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetShippingEstimateError : ApiError
{
    private readonly Optional<IReadOnlyList<V3ShippingLabelsShippingEstimates400Error1>> _listOfV3ShippingLabelsShippingEstimates400Error1Value;

    private GetShippingEstimateError(Optional<IReadOnlyList<V3ShippingLabelsShippingEstimates400Error1>> listOfV3ShippingLabelsShippingEstimates400Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _listOfV3ShippingLabelsShippingEstimates400Error1Value = listOfV3ShippingLabelsShippingEstimates400Error1Value;
    }

    private static GetShippingEstimateError AsListOfV3ShippingLabelsShippingEstimates400Error1(IReadOnlyList<V3ShippingLabelsShippingEstimates400Error1> value) =>
        new(Optional<IReadOnlyList<V3ShippingLabelsShippingEstimates400Error1>>.Some(value), default);

    private static GetShippingEstimateError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetListOfV3ShippingLabelsShippingEstimates400Error1(out IReadOnlyList<V3ShippingLabelsShippingEstimates400Error1> value) =>
        _listOfV3ShippingLabelsShippingEstimates400Error1Value.TryGetValue(out value);

    private static Task<GetShippingEstimateError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<IReadOnlyList<V3ShippingLabelsShippingEstimates400Error1>>().As(
                AsListOfV3ShippingLabelsShippingEstimates400Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetShippingEstimateError> Response { get; } = new(Create);
}
