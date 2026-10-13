using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FeedType>))]
public sealed record FeedType : OpenStringEnum<FeedType>
{
    private FeedType(string value) : base(value)
    {
    }

    public static readonly FeedType ListingsFeed = new("LISTINGS_FEED");

    public static readonly FeedType InventoryFeed = new("INVENTORY_FEED");

    public static readonly FeedType PricingFeed = new("PRICING_FEED");

    public static readonly FeedType ItemSetupFeed = new("ITEM_SETUP_FEED");

    public static readonly FeedType OrderAcknowledgementFeed = new("ORDER_ACKNOWLEDGEMENT_FEED");

    public static readonly FeedType OrderFulfillmentFeed = new("ORDER_FULFILLMENT_FEED");

    public static readonly FeedType OrderCancellationFeed = new("ORDER_CANCELLATION_FEED");

    public static readonly FeedType RetireItemFeed = new("RETIRE_ITEM_FEED");

    public TResult Match<TResult>(Func<TResult> onListingsFeed,
        Func<TResult> onInventoryFeed,
        Func<TResult> onPricingFeed,
        Func<TResult> onItemSetupFeed,
        Func<TResult> onOrderAcknowledgementFeed,
        Func<TResult> onOrderFulfillmentFeed,
        Func<TResult> onOrderCancellationFeed,
        Func<TResult> onRetireItemFeed,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ListingsFeed => onListingsFeed(),
            _ when this == InventoryFeed => onInventoryFeed(),
            _ when this == PricingFeed => onPricingFeed(),
            _ when this == ItemSetupFeed => onItemSetupFeed(),
            _ when this == OrderAcknowledgementFeed => onOrderAcknowledgementFeed(),
            _ when this == OrderFulfillmentFeed => onOrderFulfillmentFeed(),
            _ when this == OrderCancellationFeed => onOrderCancellationFeed(),
            _ when this == RetireItemFeed => onRetireItemFeed(),
            _ => otherwise(Value)
        };

    public void Match(Action onListingsFeed,
        Action onInventoryFeed,
        Action onPricingFeed,
        Action onItemSetupFeed,
        Action onOrderAcknowledgementFeed,
        Action onOrderFulfillmentFeed,
        Action onOrderCancellationFeed,
        Action onRetireItemFeed,
        Action<string> otherwise)
    {
        if (this == ListingsFeed) onListingsFeed();
        else if (this == InventoryFeed) onInventoryFeed();
        else if (this == PricingFeed) onPricingFeed();
        else if (this == ItemSetupFeed) onItemSetupFeed();
        else if (this == OrderAcknowledgementFeed) onOrderAcknowledgementFeed();
        else if (this == OrderFulfillmentFeed) onOrderFulfillmentFeed();
        else if (this == OrderCancellationFeed) onOrderCancellationFeed();
        else if (this == RetireItemFeed) onRetireItemFeed();
        else otherwise(Value);
    }
}
