using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class UpdateMultiNodeInventoryError : ApiError
{
    private readonly Optional<MultiNodeInventoryUpdateResponseDto> _multiNodeInventoryUpdateResponseDtoValue;

    private UpdateMultiNodeInventoryError(Optional<MultiNodeInventoryUpdateResponseDto> multiNodeInventoryUpdateResponseDtoValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _multiNodeInventoryUpdateResponseDtoValue = multiNodeInventoryUpdateResponseDtoValue;
    }

    private static UpdateMultiNodeInventoryError AsMultiNodeInventoryUpdateResponseDto(MultiNodeInventoryUpdateResponseDto value) =>
        new(Optional<MultiNodeInventoryUpdateResponseDto>.Some(value), default);

    private static UpdateMultiNodeInventoryError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetMultiNodeInventoryUpdateResponseDto(out MultiNodeInventoryUpdateResponseDto value) =>
        _multiNodeInventoryUpdateResponseDtoValue.TryGetValue(out value);

    private static Task<UpdateMultiNodeInventoryError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 404 => response.Json<MultiNodeInventoryUpdateResponseDto>().As(
                AsMultiNodeInventoryUpdateResponseDto),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<UpdateMultiNodeInventoryError> Response { get; } = new(Create);
}
