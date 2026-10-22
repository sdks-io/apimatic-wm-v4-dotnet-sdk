using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Currency8>))]
public sealed record Currency8 : OpenStringEnum<Currency8>
{
    private Currency8(string value) : base(value)
    {
    }

    public static readonly Currency8 Aed = new("AED");

    public static readonly Currency8 Afn = new("AFN");

    public static readonly Currency8 All = new("ALL");

    public static readonly Currency8 Amd = new("AMD");

    public static readonly Currency8 Ang = new("ANG");

    public static readonly Currency8 Aoa = new("AOA");

    public static readonly Currency8 Ars = new("ARS");

    public static readonly Currency8 Aud = new("AUD");

    public static readonly Currency8 Awg = new("AWG");

    public static readonly Currency8 Azn = new("AZN");

    public static readonly Currency8 Bam = new("BAM");

    public static readonly Currency8 Bbd = new("BBD");

    public static readonly Currency8 Bdt = new("BDT");

    public static readonly Currency8 Bgn = new("BGN");

    public static readonly Currency8 Bhd = new("BHD");

    public static readonly Currency8 Bif = new("BIF");

    public static readonly Currency8 Bmd = new("BMD");

    public static readonly Currency8 Bnd = new("BND");

    public static readonly Currency8 Bob = new("BOB");

    public static readonly Currency8 Brl = new("BRL");

    public static readonly Currency8 Bsd = new("BSD");

    public static readonly Currency8 Btn = new("BTN");

    public static readonly Currency8 Bwp = new("BWP");

    public static readonly Currency8 Byr = new("BYR");

    public static readonly Currency8 Bzd = new("BZD");

    public static readonly Currency8 Cad = new("CAD");

    public static readonly Currency8 Cdf = new("CDF");

    public static readonly Currency8 Chf = new("CHF");

    public static readonly Currency8 Clp = new("CLP");

    public static readonly Currency8 Cny = new("CNY");

    public static readonly Currency8 Cop = new("COP");

    public static readonly Currency8 Crc = new("CRC");

    public static readonly Currency8 Cup = new("CUP");

    public static readonly Currency8 Cve = new("CVE");

    public static readonly Currency8 Czk = new("CZK");

    public static readonly Currency8 Djf = new("DJF");

    public static readonly Currency8 Dkk = new("DKK");

    public static readonly Currency8 Dop = new("DOP");

    public static readonly Currency8 Dzd = new("DZD");

    public static readonly Currency8 Egp = new("EGP");

    public static readonly Currency8 Ern = new("ERN");

    public static readonly Currency8 Etb = new("ETB");

    public static readonly Currency8 Eur = new("EUR");

    public static readonly Currency8 Fjd = new("FJD");

    public static readonly Currency8 Fkp = new("FKP");

    public static readonly Currency8 Gbp = new("GBP");

    public static readonly Currency8 Gel = new("GEL");

    public static readonly Currency8 Ghs = new("GHS");

    public static readonly Currency8 Gip = new("GIP");

    public static readonly Currency8 Gmd = new("GMD");

    public static readonly Currency8 Gnf = new("GNF");

    public static readonly Currency8 Gtq = new("GTQ");

    public static readonly Currency8 Gyd = new("GYD");

    public static readonly Currency8 Hkd = new("HKD");

    public static readonly Currency8 Hnl = new("HNL");

    public static readonly Currency8 Hrk = new("HRK");

    public static readonly Currency8 Htg = new("HTG");

    public static readonly Currency8 Huf = new("HUF");

    public static readonly Currency8 Idr = new("IDR");

    public static readonly Currency8 Ils = new("ILS");

    public static readonly Currency8 Inr = new("INR");

    public static readonly Currency8 Iqd = new("IQD");

    public static readonly Currency8 Irr = new("IRR");

    public static readonly Currency8 Isk = new("ISK");

    public static readonly Currency8 Jmd = new("JMD");

    public static readonly Currency8 Jod = new("JOD");

    public static readonly Currency8 Jpy = new("JPY");

    public static readonly Currency8 Kes = new("KES");

    public static readonly Currency8 Kgs = new("KGS");

    public static readonly Currency8 Khr = new("KHR");

    public static readonly Currency8 Kmf = new("KMF");

    public static readonly Currency8 Kpw = new("KPW");

    public static readonly Currency8 Krw = new("KRW");

    public static readonly Currency8 Kwd = new("KWD");

    public static readonly Currency8 Kyd = new("KYD");

    public static readonly Currency8 Kzt = new("KZT");

    public static readonly Currency8 Lak = new("LAK");

    public static readonly Currency8 Lbp = new("LBP");

    public static readonly Currency8 Lkr = new("LKR");

    public static readonly Currency8 Lrd = new("LRD");

    public static readonly Currency8 Lsl = new("LSL");

    public static readonly Currency8 Ltl = new("LTL");

    public static readonly Currency8 Lvl = new("LVL");

    public static readonly Currency8 Lyd = new("LYD");

    public static readonly Currency8 Mad = new("MAD");

    public static readonly Currency8 Mdl = new("MDL");

    public static readonly Currency8 Mga = new("MGA");

    public static readonly Currency8 Mkd = new("MKD");

    public static readonly Currency8 Mmk = new("MMK");

    public static readonly Currency8 Mnt = new("MNT");

    public static readonly Currency8 Mop = new("MOP");

    public static readonly Currency8 Mro = new("MRO");

    public static readonly Currency8 Mur = new("MUR");

    public static readonly Currency8 Mvr = new("MVR");

    public static readonly Currency8 Mwk = new("MWK");

    public static readonly Currency8 Mxn = new("MXN");

    public static readonly Currency8 Myr = new("MYR");

    public static readonly Currency8 Mzn = new("MZN");

    public static readonly Currency8 Nad = new("NAD");

    public static readonly Currency8 Ngn = new("NGN");

    public static readonly Currency8 Nio = new("NIO");

    public static readonly Currency8 Nok = new("NOK");

    public static readonly Currency8 Npr = new("NPR");

    public static readonly Currency8 Nzd = new("NZD");

    public static readonly Currency8 Omr = new("OMR");

    public static readonly Currency8 Pab = new("PAB");

    public static readonly Currency8 Pen = new("PEN");

    public static readonly Currency8 Pgk = new("PGK");

    public static readonly Currency8 Php = new("PHP");

    public static readonly Currency8 Pkr = new("PKR");

    public static readonly Currency8 Pln = new("PLN");

    public static readonly Currency8 Pyg = new("PYG");

    public static readonly Currency8 Qar = new("QAR");

    public static readonly Currency8 Ron = new("RON");

    public static readonly Currency8 Rsd = new("RSD");

    public static readonly Currency8 Rub = new("RUB");

    public static readonly Currency8 Rur = new("RUR");

    public static readonly Currency8 Rwf = new("RWF");

    public static readonly Currency8 Sar = new("SAR");

    public static readonly Currency8 Sbd = new("SBD");

    public static readonly Currency8 Scr = new("SCR");

    public static readonly Currency8 Sdg = new("SDG");

    public static readonly Currency8 Sek = new("SEK");

    public static readonly Currency8 Sgd = new("SGD");

    public static readonly Currency8 Shp = new("SHP");

    public static readonly Currency8 Sll = new("SLL");

    public static readonly Currency8 Sos = new("SOS");

    public static readonly Currency8 Srd = new("SRD");

    public static readonly Currency8 Std = new("STD");

    public static readonly Currency8 Syp = new("SYP");

    public static readonly Currency8 Szl = new("SZL");

    public static readonly Currency8 Thb = new("THB");

    public static readonly Currency8 Tjs = new("TJS");

    public static readonly Currency8 Tmt = new("TMT");

    public static readonly Currency8 Tnd = new("TND");

    public static readonly Currency8 Top = new("TOP");

    public static readonly Currency8 Try = new("TRY");

    public static readonly Currency8 Ttd = new("TTD");

    public static readonly Currency8 Twd = new("TWD");

    public static readonly Currency8 Tzs = new("TZS");

    public static readonly Currency8 Uah = new("UAH");

    public static readonly Currency8 Ugx = new("UGX");

    public static readonly Currency8 Usd = new("USD");

    public static readonly Currency8 Uyu = new("UYU");

    public static readonly Currency8 Uzs = new("UZS");

    public static readonly Currency8 Vef = new("VEF");

    public static readonly Currency8 Vnd = new("VND");

    public static readonly Currency8 Vuv = new("VUV");

    public static readonly Currency8 Wst = new("WST");

    public static readonly Currency8 Xaf = new("XAF");

    public static readonly Currency8 Xag = new("XAG");

    public static readonly Currency8 Xau = new("XAU");

    public static readonly Currency8 Xba = new("XBA");

    public static readonly Currency8 Xbb = new("XBB");

    public static readonly Currency8 Xbc = new("XBC");

    public static readonly Currency8 Xbd = new("XBD");

    public static readonly Currency8 Xcd = new("XCD");

    public static readonly Currency8 Xdr = new("XDR");

    public static readonly Currency8 Xfu = new("XFU");

    public static readonly Currency8 Xof = new("XOF");

    public static readonly Currency8 Xpd = new("XPD");

    public static readonly Currency8 Xpf = new("XPF");

    public static readonly Currency8 Xpt = new("XPT");

    public static readonly Currency8 Xts = new("XTS");

    public static readonly Currency8 Xxx = new("XXX");

    public static readonly Currency8 Yer = new("YER");

    public static readonly Currency8 Zar = new("ZAR");

    public static readonly Currency8 Zmk = new("ZMK");

    public static readonly Currency8 Zwl = new("ZWL");

    public TResult Match<TResult>(Func<TResult> onAed,
        Func<TResult> onAfn,
        Func<TResult> onAll,
        Func<TResult> onAmd,
        Func<TResult> onAng,
        Func<TResult> onAoa,
        Func<TResult> onArs,
        Func<TResult> onAud,
        Func<TResult> onAwg,
        Func<TResult> onAzn,
        Func<TResult> onBam,
        Func<TResult> onBbd,
        Func<TResult> onBdt,
        Func<TResult> onBgn,
        Func<TResult> onBhd,
        Func<TResult> onBif,
        Func<TResult> onBmd,
        Func<TResult> onBnd,
        Func<TResult> onBob,
        Func<TResult> onBrl,
        Func<TResult> onBsd,
        Func<TResult> onBtn,
        Func<TResult> onBwp,
        Func<TResult> onByr,
        Func<TResult> onBzd,
        Func<TResult> onCad,
        Func<TResult> onCdf,
        Func<TResult> onChf,
        Func<TResult> onClp,
        Func<TResult> onCny,
        Func<TResult> onCop,
        Func<TResult> onCrc,
        Func<TResult> onCup,
        Func<TResult> onCve,
        Func<TResult> onCzk,
        Func<TResult> onDjf,
        Func<TResult> onDkk,
        Func<TResult> onDop,
        Func<TResult> onDzd,
        Func<TResult> onEgp,
        Func<TResult> onErn,
        Func<TResult> onEtb,
        Func<TResult> onEur,
        Func<TResult> onFjd,
        Func<TResult> onFkp,
        Func<TResult> onGbp,
        Func<TResult> onGel,
        Func<TResult> onGhs,
        Func<TResult> onGip,
        Func<TResult> onGmd,
        Func<TResult> onGnf,
        Func<TResult> onGtq,
        Func<TResult> onGyd,
        Func<TResult> onHkd,
        Func<TResult> onHnl,
        Func<TResult> onHrk,
        Func<TResult> onHtg,
        Func<TResult> onHuf,
        Func<TResult> onIdr,
        Func<TResult> onIls,
        Func<TResult> onInr,
        Func<TResult> onIqd,
        Func<TResult> onIrr,
        Func<TResult> onIsk,
        Func<TResult> onJmd,
        Func<TResult> onJod,
        Func<TResult> onJpy,
        Func<TResult> onKes,
        Func<TResult> onKgs,
        Func<TResult> onKhr,
        Func<TResult> onKmf,
        Func<TResult> onKpw,
        Func<TResult> onKrw,
        Func<TResult> onKwd,
        Func<TResult> onKyd,
        Func<TResult> onKzt,
        Func<TResult> onLak,
        Func<TResult> onLbp,
        Func<TResult> onLkr,
        Func<TResult> onLrd,
        Func<TResult> onLsl,
        Func<TResult> onLtl,
        Func<TResult> onLvl,
        Func<TResult> onLyd,
        Func<TResult> onMad,
        Func<TResult> onMdl,
        Func<TResult> onMga,
        Func<TResult> onMkd,
        Func<TResult> onMmk,
        Func<TResult> onMnt,
        Func<TResult> onMop,
        Func<TResult> onMro,
        Func<TResult> onMur,
        Func<TResult> onMvr,
        Func<TResult> onMwk,
        Func<TResult> onMxn,
        Func<TResult> onMyr,
        Func<TResult> onMzn,
        Func<TResult> onNad,
        Func<TResult> onNgn,
        Func<TResult> onNio,
        Func<TResult> onNok,
        Func<TResult> onNpr,
        Func<TResult> onNzd,
        Func<TResult> onOmr,
        Func<TResult> onPab,
        Func<TResult> onPen,
        Func<TResult> onPgk,
        Func<TResult> onPhp,
        Func<TResult> onPkr,
        Func<TResult> onPln,
        Func<TResult> onPyg,
        Func<TResult> onQar,
        Func<TResult> onRon,
        Func<TResult> onRsd,
        Func<TResult> onRub,
        Func<TResult> onRur,
        Func<TResult> onRwf,
        Func<TResult> onSar,
        Func<TResult> onSbd,
        Func<TResult> onScr,
        Func<TResult> onSdg,
        Func<TResult> onSek,
        Func<TResult> onSgd,
        Func<TResult> onShp,
        Func<TResult> onSll,
        Func<TResult> onSos,
        Func<TResult> onSrd,
        Func<TResult> onStd,
        Func<TResult> onSyp,
        Func<TResult> onSzl,
        Func<TResult> onThb,
        Func<TResult> onTjs,
        Func<TResult> onTmt,
        Func<TResult> onTnd,
        Func<TResult> onTop,
        Func<TResult> onTry,
        Func<TResult> onTtd,
        Func<TResult> onTwd,
        Func<TResult> onTzs,
        Func<TResult> onUah,
        Func<TResult> onUgx,
        Func<TResult> onUsd,
        Func<TResult> onUyu,
        Func<TResult> onUzs,
        Func<TResult> onVef,
        Func<TResult> onVnd,
        Func<TResult> onVuv,
        Func<TResult> onWst,
        Func<TResult> onXaf,
        Func<TResult> onXag,
        Func<TResult> onXau,
        Func<TResult> onXba,
        Func<TResult> onXbb,
        Func<TResult> onXbc,
        Func<TResult> onXbd,
        Func<TResult> onXcd,
        Func<TResult> onXdr,
        Func<TResult> onXfu,
        Func<TResult> onXof,
        Func<TResult> onXpd,
        Func<TResult> onXpf,
        Func<TResult> onXpt,
        Func<TResult> onXts,
        Func<TResult> onXxx,
        Func<TResult> onYer,
        Func<TResult> onZar,
        Func<TResult> onZmk,
        Func<TResult> onZwl,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Aed => onAed(),
            _ when this == Afn => onAfn(),
            _ when this == All => onAll(),
            _ when this == Amd => onAmd(),
            _ when this == Ang => onAng(),
            _ when this == Aoa => onAoa(),
            _ when this == Ars => onArs(),
            _ when this == Aud => onAud(),
            _ when this == Awg => onAwg(),
            _ when this == Azn => onAzn(),
            _ when this == Bam => onBam(),
            _ when this == Bbd => onBbd(),
            _ when this == Bdt => onBdt(),
            _ when this == Bgn => onBgn(),
            _ when this == Bhd => onBhd(),
            _ when this == Bif => onBif(),
            _ when this == Bmd => onBmd(),
            _ when this == Bnd => onBnd(),
            _ when this == Bob => onBob(),
            _ when this == Brl => onBrl(),
            _ when this == Bsd => onBsd(),
            _ when this == Btn => onBtn(),
            _ when this == Bwp => onBwp(),
            _ when this == Byr => onByr(),
            _ when this == Bzd => onBzd(),
            _ when this == Cad => onCad(),
            _ when this == Cdf => onCdf(),
            _ when this == Chf => onChf(),
            _ when this == Clp => onClp(),
            _ when this == Cny => onCny(),
            _ when this == Cop => onCop(),
            _ when this == Crc => onCrc(),
            _ when this == Cup => onCup(),
            _ when this == Cve => onCve(),
            _ when this == Czk => onCzk(),
            _ when this == Djf => onDjf(),
            _ when this == Dkk => onDkk(),
            _ when this == Dop => onDop(),
            _ when this == Dzd => onDzd(),
            _ when this == Egp => onEgp(),
            _ when this == Ern => onErn(),
            _ when this == Etb => onEtb(),
            _ when this == Eur => onEur(),
            _ when this == Fjd => onFjd(),
            _ when this == Fkp => onFkp(),
            _ when this == Gbp => onGbp(),
            _ when this == Gel => onGel(),
            _ when this == Ghs => onGhs(),
            _ when this == Gip => onGip(),
            _ when this == Gmd => onGmd(),
            _ when this == Gnf => onGnf(),
            _ when this == Gtq => onGtq(),
            _ when this == Gyd => onGyd(),
            _ when this == Hkd => onHkd(),
            _ when this == Hnl => onHnl(),
            _ when this == Hrk => onHrk(),
            _ when this == Htg => onHtg(),
            _ when this == Huf => onHuf(),
            _ when this == Idr => onIdr(),
            _ when this == Ils => onIls(),
            _ when this == Inr => onInr(),
            _ when this == Iqd => onIqd(),
            _ when this == Irr => onIrr(),
            _ when this == Isk => onIsk(),
            _ when this == Jmd => onJmd(),
            _ when this == Jod => onJod(),
            _ when this == Jpy => onJpy(),
            _ when this == Kes => onKes(),
            _ when this == Kgs => onKgs(),
            _ when this == Khr => onKhr(),
            _ when this == Kmf => onKmf(),
            _ when this == Kpw => onKpw(),
            _ when this == Krw => onKrw(),
            _ when this == Kwd => onKwd(),
            _ when this == Kyd => onKyd(),
            _ when this == Kzt => onKzt(),
            _ when this == Lak => onLak(),
            _ when this == Lbp => onLbp(),
            _ when this == Lkr => onLkr(),
            _ when this == Lrd => onLrd(),
            _ when this == Lsl => onLsl(),
            _ when this == Ltl => onLtl(),
            _ when this == Lvl => onLvl(),
            _ when this == Lyd => onLyd(),
            _ when this == Mad => onMad(),
            _ when this == Mdl => onMdl(),
            _ when this == Mga => onMga(),
            _ when this == Mkd => onMkd(),
            _ when this == Mmk => onMmk(),
            _ when this == Mnt => onMnt(),
            _ when this == Mop => onMop(),
            _ when this == Mro => onMro(),
            _ when this == Mur => onMur(),
            _ when this == Mvr => onMvr(),
            _ when this == Mwk => onMwk(),
            _ when this == Mxn => onMxn(),
            _ when this == Myr => onMyr(),
            _ when this == Mzn => onMzn(),
            _ when this == Nad => onNad(),
            _ when this == Ngn => onNgn(),
            _ when this == Nio => onNio(),
            _ when this == Nok => onNok(),
            _ when this == Npr => onNpr(),
            _ when this == Nzd => onNzd(),
            _ when this == Omr => onOmr(),
            _ when this == Pab => onPab(),
            _ when this == Pen => onPen(),
            _ when this == Pgk => onPgk(),
            _ when this == Php => onPhp(),
            _ when this == Pkr => onPkr(),
            _ when this == Pln => onPln(),
            _ when this == Pyg => onPyg(),
            _ when this == Qar => onQar(),
            _ when this == Ron => onRon(),
            _ when this == Rsd => onRsd(),
            _ when this == Rub => onRub(),
            _ when this == Rur => onRur(),
            _ when this == Rwf => onRwf(),
            _ when this == Sar => onSar(),
            _ when this == Sbd => onSbd(),
            _ when this == Scr => onScr(),
            _ when this == Sdg => onSdg(),
            _ when this == Sek => onSek(),
            _ when this == Sgd => onSgd(),
            _ when this == Shp => onShp(),
            _ when this == Sll => onSll(),
            _ when this == Sos => onSos(),
            _ when this == Srd => onSrd(),
            _ when this == Std => onStd(),
            _ when this == Syp => onSyp(),
            _ when this == Szl => onSzl(),
            _ when this == Thb => onThb(),
            _ when this == Tjs => onTjs(),
            _ when this == Tmt => onTmt(),
            _ when this == Tnd => onTnd(),
            _ when this == Top => onTop(),
            _ when this == Try => onTry(),
            _ when this == Ttd => onTtd(),
            _ when this == Twd => onTwd(),
            _ when this == Tzs => onTzs(),
            _ when this == Uah => onUah(),
            _ when this == Ugx => onUgx(),
            _ when this == Usd => onUsd(),
            _ when this == Uyu => onUyu(),
            _ when this == Uzs => onUzs(),
            _ when this == Vef => onVef(),
            _ when this == Vnd => onVnd(),
            _ when this == Vuv => onVuv(),
            _ when this == Wst => onWst(),
            _ when this == Xaf => onXaf(),
            _ when this == Xag => onXag(),
            _ when this == Xau => onXau(),
            _ when this == Xba => onXba(),
            _ when this == Xbb => onXbb(),
            _ when this == Xbc => onXbc(),
            _ when this == Xbd => onXbd(),
            _ when this == Xcd => onXcd(),
            _ when this == Xdr => onXdr(),
            _ when this == Xfu => onXfu(),
            _ when this == Xof => onXof(),
            _ when this == Xpd => onXpd(),
            _ when this == Xpf => onXpf(),
            _ when this == Xpt => onXpt(),
            _ when this == Xts => onXts(),
            _ when this == Xxx => onXxx(),
            _ when this == Yer => onYer(),
            _ when this == Zar => onZar(),
            _ when this == Zmk => onZmk(),
            _ when this == Zwl => onZwl(),
            _ => otherwise(Value)
        };

    public void Match(Action onAed,
        Action onAfn,
        Action onAll,
        Action onAmd,
        Action onAng,
        Action onAoa,
        Action onArs,
        Action onAud,
        Action onAwg,
        Action onAzn,
        Action onBam,
        Action onBbd,
        Action onBdt,
        Action onBgn,
        Action onBhd,
        Action onBif,
        Action onBmd,
        Action onBnd,
        Action onBob,
        Action onBrl,
        Action onBsd,
        Action onBtn,
        Action onBwp,
        Action onByr,
        Action onBzd,
        Action onCad,
        Action onCdf,
        Action onChf,
        Action onClp,
        Action onCny,
        Action onCop,
        Action onCrc,
        Action onCup,
        Action onCve,
        Action onCzk,
        Action onDjf,
        Action onDkk,
        Action onDop,
        Action onDzd,
        Action onEgp,
        Action onErn,
        Action onEtb,
        Action onEur,
        Action onFjd,
        Action onFkp,
        Action onGbp,
        Action onGel,
        Action onGhs,
        Action onGip,
        Action onGmd,
        Action onGnf,
        Action onGtq,
        Action onGyd,
        Action onHkd,
        Action onHnl,
        Action onHrk,
        Action onHtg,
        Action onHuf,
        Action onIdr,
        Action onIls,
        Action onInr,
        Action onIqd,
        Action onIrr,
        Action onIsk,
        Action onJmd,
        Action onJod,
        Action onJpy,
        Action onKes,
        Action onKgs,
        Action onKhr,
        Action onKmf,
        Action onKpw,
        Action onKrw,
        Action onKwd,
        Action onKyd,
        Action onKzt,
        Action onLak,
        Action onLbp,
        Action onLkr,
        Action onLrd,
        Action onLsl,
        Action onLtl,
        Action onLvl,
        Action onLyd,
        Action onMad,
        Action onMdl,
        Action onMga,
        Action onMkd,
        Action onMmk,
        Action onMnt,
        Action onMop,
        Action onMro,
        Action onMur,
        Action onMvr,
        Action onMwk,
        Action onMxn,
        Action onMyr,
        Action onMzn,
        Action onNad,
        Action onNgn,
        Action onNio,
        Action onNok,
        Action onNpr,
        Action onNzd,
        Action onOmr,
        Action onPab,
        Action onPen,
        Action onPgk,
        Action onPhp,
        Action onPkr,
        Action onPln,
        Action onPyg,
        Action onQar,
        Action onRon,
        Action onRsd,
        Action onRub,
        Action onRur,
        Action onRwf,
        Action onSar,
        Action onSbd,
        Action onScr,
        Action onSdg,
        Action onSek,
        Action onSgd,
        Action onShp,
        Action onSll,
        Action onSos,
        Action onSrd,
        Action onStd,
        Action onSyp,
        Action onSzl,
        Action onThb,
        Action onTjs,
        Action onTmt,
        Action onTnd,
        Action onTop,
        Action onTry,
        Action onTtd,
        Action onTwd,
        Action onTzs,
        Action onUah,
        Action onUgx,
        Action onUsd,
        Action onUyu,
        Action onUzs,
        Action onVef,
        Action onVnd,
        Action onVuv,
        Action onWst,
        Action onXaf,
        Action onXag,
        Action onXau,
        Action onXba,
        Action onXbb,
        Action onXbc,
        Action onXbd,
        Action onXcd,
        Action onXdr,
        Action onXfu,
        Action onXof,
        Action onXpd,
        Action onXpf,
        Action onXpt,
        Action onXts,
        Action onXxx,
        Action onYer,
        Action onZar,
        Action onZmk,
        Action onZwl,
        Action<string> otherwise)
    {
        if (this == Aed) onAed();
        else if (this == Afn) onAfn();
        else if (this == All) onAll();
        else if (this == Amd) onAmd();
        else if (this == Ang) onAng();
        else if (this == Aoa) onAoa();
        else if (this == Ars) onArs();
        else if (this == Aud) onAud();
        else if (this == Awg) onAwg();
        else if (this == Azn) onAzn();
        else if (this == Bam) onBam();
        else if (this == Bbd) onBbd();
        else if (this == Bdt) onBdt();
        else if (this == Bgn) onBgn();
        else if (this == Bhd) onBhd();
        else if (this == Bif) onBif();
        else if (this == Bmd) onBmd();
        else if (this == Bnd) onBnd();
        else if (this == Bob) onBob();
        else if (this == Brl) onBrl();
        else if (this == Bsd) onBsd();
        else if (this == Btn) onBtn();
        else if (this == Bwp) onBwp();
        else if (this == Byr) onByr();
        else if (this == Bzd) onBzd();
        else if (this == Cad) onCad();
        else if (this == Cdf) onCdf();
        else if (this == Chf) onChf();
        else if (this == Clp) onClp();
        else if (this == Cny) onCny();
        else if (this == Cop) onCop();
        else if (this == Crc) onCrc();
        else if (this == Cup) onCup();
        else if (this == Cve) onCve();
        else if (this == Czk) onCzk();
        else if (this == Djf) onDjf();
        else if (this == Dkk) onDkk();
        else if (this == Dop) onDop();
        else if (this == Dzd) onDzd();
        else if (this == Egp) onEgp();
        else if (this == Ern) onErn();
        else if (this == Etb) onEtb();
        else if (this == Eur) onEur();
        else if (this == Fjd) onFjd();
        else if (this == Fkp) onFkp();
        else if (this == Gbp) onGbp();
        else if (this == Gel) onGel();
        else if (this == Ghs) onGhs();
        else if (this == Gip) onGip();
        else if (this == Gmd) onGmd();
        else if (this == Gnf) onGnf();
        else if (this == Gtq) onGtq();
        else if (this == Gyd) onGyd();
        else if (this == Hkd) onHkd();
        else if (this == Hnl) onHnl();
        else if (this == Hrk) onHrk();
        else if (this == Htg) onHtg();
        else if (this == Huf) onHuf();
        else if (this == Idr) onIdr();
        else if (this == Ils) onIls();
        else if (this == Inr) onInr();
        else if (this == Iqd) onIqd();
        else if (this == Irr) onIrr();
        else if (this == Isk) onIsk();
        else if (this == Jmd) onJmd();
        else if (this == Jod) onJod();
        else if (this == Jpy) onJpy();
        else if (this == Kes) onKes();
        else if (this == Kgs) onKgs();
        else if (this == Khr) onKhr();
        else if (this == Kmf) onKmf();
        else if (this == Kpw) onKpw();
        else if (this == Krw) onKrw();
        else if (this == Kwd) onKwd();
        else if (this == Kyd) onKyd();
        else if (this == Kzt) onKzt();
        else if (this == Lak) onLak();
        else if (this == Lbp) onLbp();
        else if (this == Lkr) onLkr();
        else if (this == Lrd) onLrd();
        else if (this == Lsl) onLsl();
        else if (this == Ltl) onLtl();
        else if (this == Lvl) onLvl();
        else if (this == Lyd) onLyd();
        else if (this == Mad) onMad();
        else if (this == Mdl) onMdl();
        else if (this == Mga) onMga();
        else if (this == Mkd) onMkd();
        else if (this == Mmk) onMmk();
        else if (this == Mnt) onMnt();
        else if (this == Mop) onMop();
        else if (this == Mro) onMro();
        else if (this == Mur) onMur();
        else if (this == Mvr) onMvr();
        else if (this == Mwk) onMwk();
        else if (this == Mxn) onMxn();
        else if (this == Myr) onMyr();
        else if (this == Mzn) onMzn();
        else if (this == Nad) onNad();
        else if (this == Ngn) onNgn();
        else if (this == Nio) onNio();
        else if (this == Nok) onNok();
        else if (this == Npr) onNpr();
        else if (this == Nzd) onNzd();
        else if (this == Omr) onOmr();
        else if (this == Pab) onPab();
        else if (this == Pen) onPen();
        else if (this == Pgk) onPgk();
        else if (this == Php) onPhp();
        else if (this == Pkr) onPkr();
        else if (this == Pln) onPln();
        else if (this == Pyg) onPyg();
        else if (this == Qar) onQar();
        else if (this == Ron) onRon();
        else if (this == Rsd) onRsd();
        else if (this == Rub) onRub();
        else if (this == Rur) onRur();
        else if (this == Rwf) onRwf();
        else if (this == Sar) onSar();
        else if (this == Sbd) onSbd();
        else if (this == Scr) onScr();
        else if (this == Sdg) onSdg();
        else if (this == Sek) onSek();
        else if (this == Sgd) onSgd();
        else if (this == Shp) onShp();
        else if (this == Sll) onSll();
        else if (this == Sos) onSos();
        else if (this == Srd) onSrd();
        else if (this == Std) onStd();
        else if (this == Syp) onSyp();
        else if (this == Szl) onSzl();
        else if (this == Thb) onThb();
        else if (this == Tjs) onTjs();
        else if (this == Tmt) onTmt();
        else if (this == Tnd) onTnd();
        else if (this == Top) onTop();
        else if (this == Try) onTry();
        else if (this == Ttd) onTtd();
        else if (this == Twd) onTwd();
        else if (this == Tzs) onTzs();
        else if (this == Uah) onUah();
        else if (this == Ugx) onUgx();
        else if (this == Usd) onUsd();
        else if (this == Uyu) onUyu();
        else if (this == Uzs) onUzs();
        else if (this == Vef) onVef();
        else if (this == Vnd) onVnd();
        else if (this == Vuv) onVuv();
        else if (this == Wst) onWst();
        else if (this == Xaf) onXaf();
        else if (this == Xag) onXag();
        else if (this == Xau) onXau();
        else if (this == Xba) onXba();
        else if (this == Xbb) onXbb();
        else if (this == Xbc) onXbc();
        else if (this == Xbd) onXbd();
        else if (this == Xcd) onXcd();
        else if (this == Xdr) onXdr();
        else if (this == Xfu) onXfu();
        else if (this == Xof) onXof();
        else if (this == Xpd) onXpd();
        else if (this == Xpf) onXpf();
        else if (this == Xpt) onXpt();
        else if (this == Xts) onXts();
        else if (this == Xxx) onXxx();
        else if (this == Yer) onYer();
        else if (this == Zar) onZar();
        else if (this == Zmk) onZmk();
        else if (this == Zwl) onZwl();
        else otherwise(Value);
    }
}
