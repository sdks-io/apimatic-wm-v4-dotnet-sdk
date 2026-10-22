using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Op>))]
public sealed record Op : OpenStringEnum<Op>
{
    private Op(string value) : base(value)
    {
    }

    public static readonly Op EqualsMember = new("equals");

    public static readonly Op Between = new("between");

    public TResult Match<TResult>(Func<TResult> onEqualsMember,
        Func<TResult> onBetween,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == EqualsMember => onEqualsMember(),
            _ when this == Between => onBetween(),
            _ => otherwise(Value)
        };

    public void Match(Action onEqualsMember, Action onBetween, Action<string> otherwise)
    {
        if (this == EqualsMember) onEqualsMember();
        else if (this == Between) onBetween();
        else otherwise(Value);
    }
}
