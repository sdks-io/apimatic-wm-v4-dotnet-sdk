using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Market | Translation |
/// | --- | ----------- |
/// | US | ["Create", "Delete","Replace All"]|
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PromotionSettingAction1>))]
public sealed record PromotionSettingAction1 : OpenStringEnum<PromotionSettingAction1>
{
    private PromotionSettingAction1(string value) : base(value)
    {
    }

    public static readonly PromotionSettingAction1 Create = new("Create");

    public static readonly PromotionSettingAction1 Delete = new("Delete");

    public static readonly PromotionSettingAction1 ReplaceAll = new("Replace All");

    public TResult Match<TResult>(Func<TResult> onCreate,
        Func<TResult> onDelete,
        Func<TResult> onReplaceAll,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Create => onCreate(),
            _ when this == Delete => onDelete(),
            _ when this == ReplaceAll => onReplaceAll(),
            _ => otherwise(Value)
        };

    public void Match(Action onCreate, Action onDelete, Action onReplaceAll, Action<string> otherwise)
    {
        if (this == Create) onCreate();
        else if (this == Delete) onDelete();
        else if (this == ReplaceAll) onReplaceAll();
        else otherwise(Value);
    }
}
