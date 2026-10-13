using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Resource>))]
public sealed record Resource : OpenStringEnum<Resource>
{
    private Resource(string value) : base(value)
    {
    }

    public static readonly Resource Feeds = new("feeds");

    public static readonly Resource Reports = new("reports");

    public TResult Match<TResult>(Func<TResult> onFeeds, Func<TResult> onReports, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Feeds => onFeeds(),
            _ when this == Reports => onReports(),
            _ => otherwise(Value)
        };

    public void Match(Action onFeeds, Action onReports, Action<string> otherwise)
    {
        if (this == Feeds) onFeeds();
        else if (this == Reports) onReports();
        else otherwise(Value);
    }
}
