using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<IncludedDatum>))]
public sealed record IncludedDatum : OpenStringEnum<IncludedDatum>
{
    private IncludedDatum(string value) : base(value)
    {
    }

    public static readonly IncludedDatum Attributes = new("attributes");

    public static readonly IncludedDatum Dimensions = new("dimensions");

    public static readonly IncludedDatum Identifiers = new("identifiers");

    public static readonly IncludedDatum Images = new("images");

    public static readonly IncludedDatum ProductTypes = new("productTypes");

    public static readonly IncludedDatum Relationships = new("relationships");

    public static readonly IncludedDatum SalesRanks = new("salesRanks");

    public TResult Match<TResult>(Func<TResult> onAttributes,
        Func<TResult> onDimensions,
        Func<TResult> onIdentifiers,
        Func<TResult> onImages,
        Func<TResult> onProductTypes,
        Func<TResult> onRelationships,
        Func<TResult> onSalesRanks,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Attributes => onAttributes(),
            _ when this == Dimensions => onDimensions(),
            _ when this == Identifiers => onIdentifiers(),
            _ when this == Images => onImages(),
            _ when this == ProductTypes => onProductTypes(),
            _ when this == Relationships => onRelationships(),
            _ when this == SalesRanks => onSalesRanks(),
            _ => otherwise(Value)
        };

    public void Match(Action onAttributes,
        Action onDimensions,
        Action onIdentifiers,
        Action onImages,
        Action onProductTypes,
        Action onRelationships,
        Action onSalesRanks,
        Action<string> otherwise)
    {
        if (this == Attributes) onAttributes();
        else if (this == Dimensions) onDimensions();
        else if (this == Identifiers) onIdentifiers();
        else if (this == Images) onImages();
        else if (this == ProductTypes) onProductTypes();
        else if (this == Relationships) onRelationships();
        else if (this == SalesRanks) onSalesRanks();
        else otherwise(Value);
    }
}
