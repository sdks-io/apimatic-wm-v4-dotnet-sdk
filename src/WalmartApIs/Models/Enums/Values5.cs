using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Values correspond to the parameter used to apply filters to the response. The data in values[] are predefined. An OR operator is used between the values.
/// <para>
/// | Attribute | Associated parameter of enumFilter | Description | Data Type |
/// | --- | --- | --- | --- |
/// | EXISTING_IN_WALMART | ITEM_AVAILABILITY_STATUS | Filters items that already exist on Walmart. | string |
/// | NEW_TO_WALMART | ITEM_AVAILABILITY_STATUS | Filters items that are new to Walmart. | string |
/// | JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC | DEMAND_SALES_TRENDS | Indicates the months of the year when high demand is observed for the recommended item. | string |
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Values5>))]
public sealed record Values5 : OpenStringEnum<Values5>
{
    private Values5(string value) : base(value)
    {
    }

    public static readonly Values5 ExistingInWalmart = new("EXISTING_IN_WALMART");

    public static readonly Values5 NewToWalmart = new("NEW_TO_WALMART");

    public static readonly Values5 MostSearchedFor = new("MOST_SEARCHED_FOR");

    public static readonly Values5 BestSellers = new("BEST_SELLERS");

    public static readonly Values5 DealItems = new("DEAL_ITEMS");

    public static readonly Values5 Jan = new("JAN");

    public static readonly Values5 Feb = new("FEB");

    public static readonly Values5 Mar = new("MAR");

    public static readonly Values5 Apr = new("APR");

    public static readonly Values5 May = new("MAY");

    public static readonly Values5 Jun = new("JUN");

    public static readonly Values5 Jul = new("JUL");

    public static readonly Values5 Aug = new("AUG");

    public static readonly Values5 Sep = new("SEP");

    public static readonly Values5 Oct = new("OCT");

    public static readonly Values5 Nov = new("NOV");

    public static readonly Values5 Dec = new("DEC");

    public TResult Match<TResult>(Func<TResult> onExistingInWalmart,
        Func<TResult> onNewToWalmart,
        Func<TResult> onMostSearchedFor,
        Func<TResult> onBestSellers,
        Func<TResult> onDealItems,
        Func<TResult> onJan,
        Func<TResult> onFeb,
        Func<TResult> onMar,
        Func<TResult> onApr,
        Func<TResult> onMay,
        Func<TResult> onJun,
        Func<TResult> onJul,
        Func<TResult> onAug,
        Func<TResult> onSep,
        Func<TResult> onOct,
        Func<TResult> onNov,
        Func<TResult> onDec,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ExistingInWalmart => onExistingInWalmart(),
            _ when this == NewToWalmart => onNewToWalmart(),
            _ when this == MostSearchedFor => onMostSearchedFor(),
            _ when this == BestSellers => onBestSellers(),
            _ when this == DealItems => onDealItems(),
            _ when this == Jan => onJan(),
            _ when this == Feb => onFeb(),
            _ when this == Mar => onMar(),
            _ when this == Apr => onApr(),
            _ when this == May => onMay(),
            _ when this == Jun => onJun(),
            _ when this == Jul => onJul(),
            _ when this == Aug => onAug(),
            _ when this == Sep => onSep(),
            _ when this == Oct => onOct(),
            _ when this == Nov => onNov(),
            _ when this == Dec => onDec(),
            _ => otherwise(Value)
        };

    public void Match(Action onExistingInWalmart,
        Action onNewToWalmart,
        Action onMostSearchedFor,
        Action onBestSellers,
        Action onDealItems,
        Action onJan,
        Action onFeb,
        Action onMar,
        Action onApr,
        Action onMay,
        Action onJun,
        Action onJul,
        Action onAug,
        Action onSep,
        Action onOct,
        Action onNov,
        Action onDec,
        Action<string> otherwise)
    {
        if (this == ExistingInWalmart) onExistingInWalmart();
        else if (this == NewToWalmart) onNewToWalmart();
        else if (this == MostSearchedFor) onMostSearchedFor();
        else if (this == BestSellers) onBestSellers();
        else if (this == DealItems) onDealItems();
        else if (this == Jan) onJan();
        else if (this == Feb) onFeb();
        else if (this == Mar) onMar();
        else if (this == Apr) onApr();
        else if (this == May) onMay();
        else if (this == Jun) onJun();
        else if (this == Jul) onJul();
        else if (this == Aug) onAug();
        else if (this == Sep) onSep();
        else if (this == Oct) onOct();
        else if (this == Nov) onNov();
        else if (this == Dec) onDec();
        else otherwise(Value);
    }
}
