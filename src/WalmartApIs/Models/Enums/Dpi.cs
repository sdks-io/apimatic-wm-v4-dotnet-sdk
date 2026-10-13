using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(IntEnumConverter<Dpi>))]
public sealed record Dpi : OpenIntEnum<Dpi>
{
    private Dpi(long value) : base(value)
    {
    }

    public static readonly Dpi Value203 = new(203L);

    public static readonly Dpi Value300 = new(300L);

    public TResult Match<TResult>(Func<TResult> onValue203, Func<TResult> onValue300, Func<long, TResult> otherwise) =>
        this switch
        {
            _ when this == Value203 => onValue203(),
            _ when this == Value300 => onValue300(),
            _ => otherwise(Value)
        };

    public void Match(Action onValue203, Action onValue300, Action<long> otherwise)
    {
        if (this == Value203) onValue203();
        else if (this == Value300) onValue300();
        else otherwise(Value);
    }
}
