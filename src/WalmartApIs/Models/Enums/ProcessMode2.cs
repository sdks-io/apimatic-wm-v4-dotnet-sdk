using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ProcessMode2>))]
public sealed record ProcessMode2 : OpenStringEnum<ProcessMode2>
{
    private ProcessMode2(string value) : base(value)
    {
    }

    public static readonly ProcessMode2 Upsert = new("UPSERT");

    public static readonly ProcessMode2 Delete = new("DELETE");

    public TResult Match<TResult>(Func<TResult> onUpsert, Func<TResult> onDelete, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Upsert => onUpsert(),
            _ when this == Delete => onDelete(),
            _ => otherwise(Value)
        };

    public void Match(Action onUpsert, Action onDelete, Action<string> otherwise)
    {
        if (this == Upsert) onUpsert();
        else if (this == Delete) onDelete();
        else otherwise(Value);
    }
}
