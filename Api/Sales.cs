using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Api;

public sealed class Sales
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Sales(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    public Task<object> GetOrderMetrics(IReadOnlyList<string> marketplaceIds,
        string interval,
        Granularity granularity,
        string? granularityTimeZone,
        BuyerType? buyerType,
        string? fulfillmentNetwork,
        FirstDayOfWeek? firstDayOfWeek,
        string? asin,
        string? sku,
        string? spApiProgram,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/sales/v4/orderMetrics"),
            [],
            [new Param("marketplaceIds", marketplaceIds),
                new Param("interval", interval),
                new Param("granularity", granularity),
                new Param("granularityTimeZone", granularityTimeZone),
                new Param("buyerType", buyerType),
                new Param("fulfillmentNetwork", fulfillmentNetwork),
                new Param("firstDayOfWeek", firstDayOfWeek),
                new Param("asin", asin),
                new Param("sku", sku),
                new Param("sp-apiProgram", spApiProgram)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            GetOrderMetricsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
