using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FeedType>))]
public sealed record FeedType : StringEnum<FeedType>
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

    public static FeedType FromValue(string value) => FromValueCore(value);
}
