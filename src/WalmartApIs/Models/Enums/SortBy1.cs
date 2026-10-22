using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<SortBy1>))]
public sealed record SortBy1 : OpenStringEnum<SortBy1>
{
    private SortBy1(string value) : base(value)
    {
    }

    public static readonly SortBy1 ItemId = new("ITEM_ID");

    public static readonly SortBy1 ProductName = new("PRODUCT_NAME");

    public static readonly SortBy1 CurrentPrice = new("CURRENT_PRICE");

    public static readonly SortBy1 ExpirationDate = new("EXPIRATION_DATE");

    public static readonly SortBy1 EnrollmentDate = new("ENROLLMENT_DATE");

    public TResult Match<TResult>(Func<TResult> onItemId,
        Func<TResult> onProductName,
        Func<TResult> onCurrentPrice,
        Func<TResult> onExpirationDate,
        Func<TResult> onEnrollmentDate,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ItemId => onItemId(),
            _ when this == ProductName => onProductName(),
            _ when this == CurrentPrice => onCurrentPrice(),
            _ when this == ExpirationDate => onExpirationDate(),
            _ when this == EnrollmentDate => onEnrollmentDate(),
            _ => otherwise(Value)
        };

    public void Match(Action onItemId,
        Action onProductName,
        Action onCurrentPrice,
        Action onExpirationDate,
        Action onEnrollmentDate,
        Action<string> otherwise)
    {
        if (this == ItemId) onItemId();
        else if (this == ProductName) onProductName();
        else if (this == CurrentPrice) onCurrentPrice();
        else if (this == ExpirationDate) onExpirationDate();
        else if (this == EnrollmentDate) onEnrollmentDate();
        else otherwise(Value);
    }
}
