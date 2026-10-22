using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<TemplateType>))]
public sealed record TemplateType : OpenStringEnum<TemplateType>
{
    private TemplateType(string value) : base(value)
    {
    }

    public static readonly TemplateType NonMacro = new("NON_MACRO");

    public TResult Match<TResult>(Func<TResult> onNonMacro, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == NonMacro => onNonMacro(),
            _ => otherwise(Value)
        };

    public void Match(Action onNonMacro, Action<string> otherwise)
    {
        if (this == NonMacro) onNonMacro();
        else otherwise(Value);
    }
}
