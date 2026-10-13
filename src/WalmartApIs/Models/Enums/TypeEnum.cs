using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<TypeEnum>))]
public sealed record TypeEnum : OpenStringEnum<TypeEnum>
{
    private TypeEnum(string value) : base(value)
    {
    }

    public static readonly TypeEnum Variation = new("VARIATION");

    public static readonly TypeEnum Accessory = new("ACCESSORY");

    public static readonly TypeEnum BundleComponent = new("BUNDLE_COMPONENT");

    public TResult Match<TResult>(Func<TResult> onVariation,
        Func<TResult> onAccessory,
        Func<TResult> onBundleComponent,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Variation => onVariation(),
            _ when this == Accessory => onAccessory(),
            _ when this == BundleComponent => onBundleComponent(),
            _ => otherwise(Value)
        };

    public void Match(Action onVariation, Action onAccessory, Action onBundleComponent, Action<string> otherwise)
    {
        if (this == Variation) onVariation();
        else if (this == Accessory) onAccessory();
        else if (this == BundleComponent) onBundleComponent();
        else otherwise(Value);
    }
}
