using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Category classifying the origin of the error.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Category1>))]
public sealed record Category1 : OpenStringEnum<Category1>
{
    private Category1(string value) : base(value)
    {
    }

    public static readonly Category1 Application = new("APPLICATION");

    public static readonly Category1 Service = new("SERVICE");

    public static readonly Category1 Request = new("REQUEST");

    public static readonly Category1 Data = new("DATA");

    public TResult Match<TResult>(Func<TResult> onApplication,
        Func<TResult> onService,
        Func<TResult> onRequest,
        Func<TResult> onData,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Application => onApplication(),
            _ when this == Service => onService(),
            _ when this == Request => onRequest(),
            _ when this == Data => onData(),
            _ => otherwise(Value)
        };

    public void Match(Action onApplication, Action onService, Action onRequest, Action onData, Action<string> otherwise)
    {
        if (this == Application) onApplication();
        else if (this == Service) onService();
        else if (this == Request) onRequest();
        else if (this == Data) onData();
        else otherwise(Value);
    }
}
