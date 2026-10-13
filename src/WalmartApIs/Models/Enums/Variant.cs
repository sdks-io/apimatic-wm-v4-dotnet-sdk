using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Variant>))]
public sealed record Variant : OpenStringEnum<Variant>
{
    private Variant(string value) : base(value)
    {
    }

    public static readonly Variant Main = new("MAIN");

    public static readonly Variant Pt01 = new("PT01");

    public static readonly Variant Pt02 = new("PT02");

    public static readonly Variant Pt03 = new("PT03");

    public static readonly Variant Pt04 = new("PT04");

    public static readonly Variant Swch = new("SWCH");

    public TResult Match<TResult>(Func<TResult> onMain,
        Func<TResult> onPt01,
        Func<TResult> onPt02,
        Func<TResult> onPt03,
        Func<TResult> onPt04,
        Func<TResult> onSwch,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Main => onMain(),
            _ when this == Pt01 => onPt01(),
            _ when this == Pt02 => onPt02(),
            _ when this == Pt03 => onPt03(),
            _ when this == Pt04 => onPt04(),
            _ when this == Swch => onSwch(),
            _ => otherwise(Value)
        };

    public void Match(Action onMain,
        Action onPt01,
        Action onPt02,
        Action onPt03,
        Action onPt04,
        Action onSwch,
        Action<string> otherwise)
    {
        if (this == Main) onMain();
        else if (this == Pt01) onPt01();
        else if (this == Pt02) onPt02();
        else if (this == Pt03) onPt03();
        else if (this == Pt04) onPt04();
        else if (this == Swch) onSwch();
        else otherwise(Value);
    }
}
