using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Current listing state of the item on Walmart.com.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PublishingStatus>))]
public sealed record PublishingStatus : OpenStringEnum<PublishingStatus>
{
    private PublishingStatus(string value) : base(value)
    {
    }

    public static readonly PublishingStatus Published = new("Published");

    public static readonly PublishingStatus Unpublished = new("Unpublished");

    public static readonly PublishingStatus Processing = new("Processing");

    public static readonly PublishingStatus Stage = new("Stage");

    public static readonly PublishingStatus Error = new("Error");

    public static readonly PublishingStatus WfsIneligible = new("WfsIneligible");

    public TResult Match<TResult>(Func<TResult> onPublished,
        Func<TResult> onUnpublished,
        Func<TResult> onProcessing,
        Func<TResult> onStage,
        Func<TResult> onError,
        Func<TResult> onWfsIneligible,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Published => onPublished(),
            _ when this == Unpublished => onUnpublished(),
            _ when this == Processing => onProcessing(),
            _ when this == Stage => onStage(),
            _ when this == Error => onError(),
            _ when this == WfsIneligible => onWfsIneligible(),
            _ => otherwise(Value)
        };

    public void Match(Action onPublished,
        Action onUnpublished,
        Action onProcessing,
        Action onStage,
        Action onError,
        Action onWfsIneligible,
        Action<string> otherwise)
    {
        if (this == Published) onPublished();
        else if (this == Unpublished) onUnpublished();
        else if (this == Processing) onProcessing();
        else if (this == Stage) onStage();
        else if (this == Error) onError();
        else if (this == WfsIneligible) onWfsIneligible();
        else otherwise(Value);
    }
}
