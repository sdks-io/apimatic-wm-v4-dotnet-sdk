using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Category>))]
public sealed record Category : OpenStringEnum<Category>
{
    private Category(string value) : base(value)
    {
    }

    public static readonly Category Application = new("APPLICATION");

    public static readonly Category System = new("SYSTEM");

    public static readonly Category Request = new("REQUEST");

    public static readonly Category Data = new("DATA");

    public TResult Match<TResult>(Func<TResult> onApplication,
        Func<TResult> onSystem,
        Func<TResult> onRequest,
        Func<TResult> onData,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Application => onApplication(),
            _ when this == System => onSystem(),
            _ when this == Request => onRequest(),
            _ when this == Data => onData(),
            _ => otherwise(Value)
        };

    public void Match(Action onApplication, Action onSystem, Action onRequest, Action onData, Action<string> otherwise)
    {
        if (this == Application) onApplication();
        else if (this == System) onSystem();
        else if (this == Request) onRequest();
        else if (this == Data) onData();
        else otherwise(Value);
    }
}
