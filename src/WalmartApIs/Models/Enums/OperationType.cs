using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Type of operation to perform on campaign items. Allowed values: <c>ADD</c> or <c>REMOVE</c>.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<OperationType>))]
public sealed record OperationType : OpenStringEnum<OperationType>
{
    private OperationType(string value) : base(value)
    {
    }

    public static readonly OperationType Add = new("ADD");

    public static readonly OperationType Remove = new("REMOVE");

    public TResult Match<TResult>(Func<TResult> onAdd, Func<TResult> onRemove, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Add => onAdd(),
            _ when this == Remove => onRemove(),
            _ => otherwise(Value)
        };

    public void Match(Action onAdd, Action onRemove, Action<string> otherwise)
    {
        if (this == Add) onAdd();
        else if (this == Remove) onRemove();
        else otherwise(Value);
    }
}
