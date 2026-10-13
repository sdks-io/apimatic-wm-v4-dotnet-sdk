using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The HTTP method associated with the individual APIs being called as part of the batch request.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<HttpMethodEnum>))]
public sealed record HttpMethodEnum : OpenStringEnum<HttpMethodEnum>
{
    private HttpMethodEnum(string value) : base(value)
    {
    }

    public static readonly HttpMethodEnum Get = new("GET");

    public static readonly HttpMethodEnum Put = new("PUT");

    public static readonly HttpMethodEnum Patch = new("PATCH");

    public static readonly HttpMethodEnum Delete = new("DELETE");

    public static readonly HttpMethodEnum Post = new("POST");

    public TResult Match<TResult>(Func<TResult> onGet,
        Func<TResult> onPut,
        Func<TResult> onPatch,
        Func<TResult> onDelete,
        Func<TResult> onPost,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Get => onGet(),
            _ when this == Put => onPut(),
            _ when this == Patch => onPatch(),
            _ when this == Delete => onDelete(),
            _ when this == Post => onPost(),
            _ => otherwise(Value)
        };

    public void Match(Action onGet,
        Action onPut,
        Action onPatch,
        Action onDelete,
        Action onPost,
        Action<string> otherwise)
    {
        if (this == Get) onGet();
        else if (this == Put) onPut();
        else if (this == Patch) onPatch();
        else if (this == Delete) onDelete();
        else if (this == Post) onPost();
        else otherwise(Value);
    }
}
