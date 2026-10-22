using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Attribute on which filter needs to be applied.
/// <para>
/// <b>Supported fields</b>:
/// - <c>campaignId</c>: Filter by campaign identifier(s)
/// - <c>adGroupId</c>: Filter by ad group identifier(s)
/// - <c>creativeId</c>: Filter by creative identifier(s)
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Field1>))]
public sealed record Field1 : OpenStringEnum<Field1>
{
    private Field1(string value) : base(value)
    {
    }

    public static readonly Field1 CampaignId = new("campaignId");

    public static readonly Field1 AdGroupId = new("adGroupId");

    public static readonly Field1 CreativeId = new("creativeId");

    public TResult Match<TResult>(Func<TResult> onCampaignId,
        Func<TResult> onAdGroupId,
        Func<TResult> onCreativeId,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CampaignId => onCampaignId(),
            _ when this == AdGroupId => onAdGroupId(),
            _ when this == CreativeId => onCreativeId(),
            _ => otherwise(Value)
        };

    public void Match(Action onCampaignId, Action onAdGroupId, Action onCreativeId, Action<string> otherwise)
    {
        if (this == CampaignId) onCampaignId();
        else if (this == AdGroupId) onAdGroupId();
        else if (this == CreativeId) onCreativeId();
        else otherwise(Value);
    }
}
