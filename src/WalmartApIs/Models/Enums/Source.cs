using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Originating source of the rich media asset. Possible values: <c>MARKETPLACE_PARTNER</c>, <c>SELLER_API</c>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Source>))]
public sealed record Source : OpenStringEnum<Source>
{
    private Source(string value) : base(value)
    {
    }

    public static readonly Source MarketplacePartner = new("MARKETPLACE_PARTNER");

    public static readonly Source SellerApi = new("SELLER_API");

    public TResult Match<TResult>(Func<TResult> onMarketplacePartner,
        Func<TResult> onSellerApi,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == MarketplacePartner => onMarketplacePartner(),
            _ when this == SellerApi => onSellerApi(),
            _ => otherwise(Value)
        };

    public void Match(Action onMarketplacePartner, Action onSellerApi, Action<string> otherwise)
    {
        if (this == MarketplacePartner) onMarketplacePartner();
        else if (this == SellerApi) onSellerApi();
        else otherwise(Value);
    }
}
