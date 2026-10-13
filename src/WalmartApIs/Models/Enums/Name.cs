using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Duration category of the investigation.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Name>))]
public sealed record Name : OpenStringEnum<Name>
{
    private Name(string value) : base(value)
    {
    }

    public static readonly Name ResearchingQuantityInShortTerm = new("researchingQuantityInShortTerm");

    public static readonly Name ResearchingQuantityInMidTerm = new("researchingQuantityInMidTerm");

    public static readonly Name ResearchingQuantityInLongTerm = new("researchingQuantityInLongTerm");

    public TResult Match<TResult>(Func<TResult> onResearchingQuantityInShortTerm,
        Func<TResult> onResearchingQuantityInMidTerm,
        Func<TResult> onResearchingQuantityInLongTerm,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ResearchingQuantityInShortTerm => onResearchingQuantityInShortTerm(),
            _ when this == ResearchingQuantityInMidTerm => onResearchingQuantityInMidTerm(),
            _ when this == ResearchingQuantityInLongTerm => onResearchingQuantityInLongTerm(),
            _ => otherwise(Value)
        };

    public void Match(Action onResearchingQuantityInShortTerm,
        Action onResearchingQuantityInMidTerm,
        Action onResearchingQuantityInLongTerm,
        Action<string> otherwise)
    {
        if (this == ResearchingQuantityInShortTerm) onResearchingQuantityInShortTerm();
        else if (this == ResearchingQuantityInMidTerm) onResearchingQuantityInMidTerm();
        else if (this == ResearchingQuantityInLongTerm) onResearchingQuantityInLongTerm();
        else otherwise(Value);
    }
}
