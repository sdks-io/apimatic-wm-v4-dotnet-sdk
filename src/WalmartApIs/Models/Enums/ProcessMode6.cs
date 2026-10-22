using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ProcessMode6>))]
public sealed record ProcessMode6 : OpenStringEnum<ProcessMode6>
{
    private ProcessMode6(string value) : base(value)
    {
    }

    public static readonly ProcessMode6 Upsert = new("UPSERT");

    public static readonly ProcessMode6 Delete = new("DELETE");

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
