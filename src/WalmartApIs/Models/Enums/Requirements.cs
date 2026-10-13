using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Requirements>))]
public sealed record Requirements : OpenStringEnum<Requirements>
{
    private Requirements(string value) : base(value)
    {
    }

    public static readonly Requirements Listing = new("LISTING");

    public static readonly Requirements ListingProductOnly = new("LISTING_PRODUCT_ONLY");

    public static readonly Requirements ListingOfferOnly = new("LISTING_OFFER_ONLY");

    public TResult Match<TResult>(Func<TResult> onListing,
        Func<TResult> onListingProductOnly,
        Func<TResult> onListingOfferOnly,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Listing => onListing(),
            _ when this == ListingProductOnly => onListingProductOnly(),
            _ when this == ListingOfferOnly => onListingOfferOnly(),
            _ => otherwise(Value)
        };

    public void Match(Action onListing,
        Action onListingProductOnly,
        Action onListingOfferOnly,
        Action<string> otherwise)
    {
        if (this == Listing) onListing();
        else if (this == ListingProductOnly) onListingProductOnly();
        else if (this == ListingOfferOnly) onListingOfferOnly();
        else otherwise(Value);
    }
}
