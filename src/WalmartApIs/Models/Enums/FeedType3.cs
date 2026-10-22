using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FeedType3>))]
public sealed record FeedType3 : OpenStringEnum<FeedType3>
{
    private FeedType3(string value) : base(value)
    {
    }

    public static readonly FeedType3 ProgramActions = new("PROGRAM_ACTIONS");

    public TResult Match<TResult>(Func<TResult> onProgramActions, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ProgramActions => onProgramActions(),
            _ => otherwise(Value)
        };

    public void Match(Action onProgramActions, Action<string> otherwise)
    {
        if (this == ProgramActions) onProgramActions();
        else otherwise(Value);
    }
}
