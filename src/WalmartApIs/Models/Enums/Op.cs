using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Patch operation type (JSON Patch)
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Op>))]
public sealed record Op : OpenStringEnum<Op>
{
    private Op(string value) : base(value)
    {
    }

    public static readonly Op Add = new("add");

    public static readonly Op Replace = new("replace");

    public static readonly Op Delete = new("delete");

    public TResult Match<TResult>(Func<TResult> onAdd,
        Func<TResult> onReplace,
        Func<TResult> onDelete,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Add => onAdd(),
            _ when this == Replace => onReplace(),
            _ when this == Delete => onDelete(),
            _ => otherwise(Value)
        };

    public void Match(Action onAdd, Action onReplace, Action onDelete, Action<string> otherwise)
    {
        if (this == Add) onAdd();
        else if (this == Replace) onReplace();
        else if (this == Delete) onDelete();
        else otherwise(Value);
    }
}
