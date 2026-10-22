using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;
using WalmartApIs.Requests.OnRequestReport;

namespace WalmartApIs.Api;

public sealed class OnRequestReport
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal OnRequestReport(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create report request
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ReportsReportRequestsResponse1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GenerateReportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a new request for report by specifying the <c>reportType</c> and <c>reportVersion</c>.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// <para>
    /// <b>Max reporting window:</b> For <c>ITEM_PERFORMANCE</c> v3, the date range between <c>dataStartTime</c> and <c>dataEndTime</c> must not exceed 2 years (730 days). Exceeding this limit will return a <c>400</c> error.
    /// </para>
    /// <para>
    /// <b>Row limit:</b> There is no limit on the number of rows returned in the report.
    /// </para>
    /// </remarks>
    public Task<V3ReportsReportRequestsResponse1> GenerateReport(GenerateReportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/reports/reportRequests"),
            [],
            [new Param("reportType", request.ReportType), new Param("reportVersion", request.ReportVersion)],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("Accept", request.Accept),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3ReportsReportRequestsResponse1>(),
            GenerateReportError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
