using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Requests.Sales;

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

    public Task<object> GetOrderMetrics(GetOrderMetricsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/sales/v4/orderMetrics"),
            [],
            [
                new Param("marketplaceIds", request.MarketplaceIds),
                new Param("interval", request.Interval),
                new Param("granularity", request.Granularity),
                new Param("granularityTimeZone", request.GranularityTimeZone),
                new Param("buyerType", request.BuyerType),
                new Param("fulfillmentNetwork", request.FulfillmentNetwork),
                new Param("firstDayOfWeek", request.FirstDayOfWeek),
                new Param("asin", request.Asin),
                new Param("sku", request.Sku),
                new Param("sp-apiProgram", request.SpApiProgram),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            GetOrderMetricsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
