using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Op2>))]
public sealed record Op2 : OpenStringEnum<Op2>
{
    private Op2(string value) : base(value)
    {
    }

    public static readonly Op2 EqualsMember = new("equals");

    public static readonly Op2 Between = new("between");

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
