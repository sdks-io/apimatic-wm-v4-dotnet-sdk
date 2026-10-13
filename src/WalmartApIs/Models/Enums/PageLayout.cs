using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<PageLayout>))]
public sealed record PageLayout : OpenStringEnum<PageLayout>
{
    private PageLayout(string value) : base(value)
    {
    }

    public static readonly PageLayout Default = new("DEFAULT");

    public static readonly PageLayout FourInOne = new("FOUR_IN_ONE");

    public TResult Match<TResult>(Func<TResult> onDefault,
        Func<TResult> onFourInOne,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Default => onDefault(),
            _ when this == FourInOne => onFourInOne(),
            _ => otherwise(Value)
        };

    public void Match(Action onDefault, Action onFourInOne, Action<string> otherwise)
    {
        if (this == Default) onDefault();
        else if (this == FourInOne) onFourInOne();
        else otherwise(Value);
    }
}
