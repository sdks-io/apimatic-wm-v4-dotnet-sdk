using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<CodeChallengeMethod>))]
public sealed record CodeChallengeMethod : OpenStringEnum<CodeChallengeMethod>
{
    private CodeChallengeMethod(string value) : base(value)
    {
    }

    public static readonly CodeChallengeMethod S256 = new("S256");

    public TResult Match<TResult>(Func<TResult> onS256, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == S256 => onS256(),
            _ => otherwise(Value)
        };

    public void Match(Action onS256, Action<string> otherwise)
    {
        if (this == S256) onS256();
        else otherwise(Value);
    }
}
