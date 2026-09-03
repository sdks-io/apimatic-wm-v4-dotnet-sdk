using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Extensions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;

namespace WalmartApIs.Api;

/// <summary>
/// Reconciliation report availability and download.
/// </summary>
public sealed class Reconciliation
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Reconciliation(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Check if a report is available for a given period
    /// </summary>
    /// <param name="partnerId">Numeric partner/seller ID</param>
    /// <param name="date">Report date in yyyy-MM-dd format</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReportAvailabilityResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CheckDownloadReportByPeriodError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Checks which reconciliation report versions (legacy, v1/WFS) are available
    /// for a given partner and date. Delegates to mp-payment-reporting
    /// GET /v3/report/reconreport/reconReportAvailability.
    /// Note: the upstream date param is named <c>date</c> (not <c>reportDate</c>).
    /// </remarks>
    public Task<ReportAvailabilityResponse> CheckDownloadReportByPeriod(string partnerId,
        DateTimeOffset date,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/payment/checkDownloadReportByPeriod"),
            [],
            [new Param("partnerId", partnerId), new Param("date", date.ToDate())],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ReportAvailabilityResponse>(),
            CheckDownloadReportByPeriodErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Download reconciliation report as ZIP
    /// </summary>
    /// <param name="partnerId">Numeric partner/seller ID</param>
    /// <param name="reportDate">Report date in MMddyyyy format (e.g. 06172026)</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BinaryContent"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DownloadReconciliationReportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Downloads a reconciliation report ZIP for the given partner and date.
    /// Delegates to mp-payment-reporting GET /v1/mt/report/reconreport/reconFile (Azure MT storage).
    /// </remarks>
    public Task<BinaryContent> DownloadReconciliationReport(string partnerId,
        string reportDate,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/payment/reconciliation/download"),
            [],
            [new Param("partnerId", partnerId), new Param("reportDate", reportDate)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            BinaryResponse.Instance,
            DownloadReconciliationReportErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// List available reconciliation report dates
    /// </summary>
    /// <param name="partnerId">Numeric partner/seller ID</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReportAvailabilityResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListReconciliationDatesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the set of available reconciliation report dates for a partner.
    /// Delegates to mp-payment-reporting GET /v3/report/reconreport/availableReconFiles.
    /// </remarks>
    public Task<ReportAvailabilityResponse> ListReconciliationDates(string partnerId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/disbursements/v4/payment/reconciliation/dateList"),
            [],
            [new Param("partnerId", partnerId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ReportAvailabilityResponse>(),
            ListReconciliationDatesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
