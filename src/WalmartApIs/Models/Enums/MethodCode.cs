using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<MethodCode>))]
public sealed record MethodCode : OpenStringEnum<MethodCode>
{
    private MethodCode(string value) : base(value)
    {
    }

    public static readonly MethodCode Standard = new("Standard");

    public static readonly MethodCode Express = new("Express");

    public static readonly MethodCode SameDay = new("SameDay");

    public static readonly MethodCode Freight = new("Freight");

    public TResult Match<TResult>(Func<TResult> onStandard,
        Func<TResult> onExpress,
        Func<TResult> onSameDay,
        Func<TResult> onFreight,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Standard => onStandard(),
            _ when this == Express => onExpress(),
            _ when this == SameDay => onSameDay(),
            _ when this == Freight => onFreight(),
            _ => otherwise(Value)
        };

    public void Match(Action onStandard, Action onExpress, Action onSameDay, Action onFreight, Action<string> otherwise)
    {
        if (this == Standard) onStandard();
        else if (this == Express) onExpress();
        else if (this == SameDay) onSameDay();
        else if (this == Freight) onFreight();
        else otherwise(Value);
    }
}
