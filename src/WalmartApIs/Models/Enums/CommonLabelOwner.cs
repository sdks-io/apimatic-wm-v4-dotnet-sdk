using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Specifies who will label the items. Options include <c>SELLER</c> and <c>NONE</c>., The owner of the preparations, if special preparations are required., Specifies who will label the items. Options include <c>SELLER</c> and <c>NONE</c>., The owner of the preparations, if special preparations are required., Specifies who will label the items. Options include <c>SELLER</c> and <c>NONE</c>., The owner of the preparations, if special preparations are required.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonLabelOwner>))]
public sealed record CommonLabelOwner : OpenStringEnum<CommonLabelOwner>
{
    private CommonLabelOwner(string value) : base(value)
    {
    }

    public static readonly CommonLabelOwner Seller = new("SELLER");

    public static readonly CommonLabelOwner None = new("NONE");

    public TResult Match<TResult>(Func<TResult> onSeller, Func<TResult> onNone, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Seller => onSeller(),
            _ when this == None => onNone(),
            _ => otherwise(Value)
        };

    public void Match(Action onSeller, Action onNone, Action<string> otherwise)
    {
        if (this == Seller) onSeller();
        else if (this == None) onNone();
        else otherwise(Value);
    }
}
